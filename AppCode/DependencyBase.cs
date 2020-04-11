using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Futurez.XrmToolBox
{
    public interface IChildDependencies 
    {
        List<DependencyItem> ProcessDependencies(List<object> itemsList, string entityName, string websiteId);
    }

    public class DependencyBase
    {
        internal IOrganizationService _service;
        internal Utility _utility;
        internal string _baseServerUrl;

        public DependencyBase(IOrganizationService service, Utility utility, string baseServerUrl)
        {
            _service = service;
            _utility = utility;
            _baseServerUrl = baseServerUrl;
        }
        internal void ProcessQuery(string queryName, string searchValue, List<DependencyItem> dependencyItems)
        {
            ProcessQuery(queryName, new List<string>() { searchValue }, dependencyItems);
        }

        internal void ProcessQuery(string queryName, List<string> searchValues, List<DependencyItem> dependencyItems)
        {
            var element = new XElement(_utility.GetFetchXmlElement(queryName).Parent);

            ProcessQuery(element, searchValues, dependencyItems);
        }

        /// <summary>
        /// Process a query for the list of search values
        /// </summary>
        /// <param name="queryName"></param>
        /// <param name="searchValues"></param>
        /// <param name="dependencyItems"></param>
        internal void ProcessEntityQuery(string queryName, string entityName, string websiteId, List<string> searchValues, List<DependencyItem> dependencyItems)
        {
            var element = GetQueryElement(queryName, websiteId);

            // need to set the parent in the fetch
            element.Element("fetch")
                .Descendants("condition")
                .Where(c => c.Attribute("attribute").Value == "adx_entityname")
                .FirstOrDefault()
                .SetAttributeValue("value", entityName);

            // now handle the standard processing 
            ProcessQuery(element, searchValues, dependencyItems);
        }

        /// <summary>
        /// Process the query for the list of search values
        /// </summary>
        /// <param name="queryName"></param>
        /// <param name="searchValues"></param>
        /// <param name="dependencyItems"></param>
        internal void ProcessQuery(XElement element, List<string> searchValues, List<DependencyItem> dependencyItems)
        {
            var displayName = element.Attribute("name").Value;
            var primaryfield = element.Attribute("primaryfield").Value;
            var fetch = element.Element("fetch");

            var conditionAttrs = new List<string>();

            // grab the filter element that we want to update
            var filter = fetch.Element("entity")
                              .Elements("filter")
                              .Where(a => a.Attribute("filter").Value == "true")
                              .FirstOrDefault();

            // clone the conditions so we are not updating the doc each time 
            var conditions = filter
                .Descendants("condition")
                .Where(c => c.Attribute("operator").Value != "null")
                .Select(c => new XElement(c))
                .ToArray();

            // clear the items
            filter.Elements("condition")
                .Where(c => c.Attribute("operator").Value != "null")
                .Remove();
            
            // for each of the conditions we have in our fetch, add the condition value
            foreach (var cond in conditions)
            {
                // save the list of conditions so we can filter later
                var name = cond.Attribute("attribute").Value;

                if (!conditionAttrs.Contains(name)) { 
                    conditionAttrs.Add(name); 
                }
                // update the condition operators
                foreach (var search in searchValues)
                {
                    // apply the filter based on the operator.  like needs the mask 
                    if (cond.Attribute("operator").Value == "like") {
                        cond.SetAttributeValue("value", $"%{search}%");
                    }
                    else {
                        cond.SetAttributeValue("value", search);
                    }
                    filter.Add(new XElement(cond));
                }
            }
            var response = _service.RetrieveMultiple(new FetchExpression(fetch.ToString()));

            // iterate on the returned results
            // for each item being searched, check to see if what we are looking for is in the list of attributes
            // being returned.  one search item may match multople attributes
            foreach (var item in response.Entities)
            {
                // var re = new Regex($"(^|['\"\s\n\r\t\.]){}(['\"\s\n\r\t\.]|$)");
                var values = new List<string>();
                var findResults = new List<FindResult>();

                foreach (var i in item.Attributes.Where(a => conditionAttrs.Contains(a.Key)))
                {
                    foreach (var s in searchValues)
                    {
                        // now check each condition.  if the find is not an exact match, check the regex to see if the correct match exists.  
                        var match = (s == i.Value?.ToString());
                        if (!match) {
                            var re = new Regex($"(^|[^a-z])*{s}([^a-z]|$)");
                            match = re.IsMatch(i.Value?.ToString());
                        }
                        if (match)
                        {
                            findResults.Add(new FindResult()
                            {
                                SearchValues = searchValues,
                                AttributeName = i.Key,
                                AttributeValue = i.Value?.ToString()
                            });
                        }
                    }
                }
                if (findResults.Count > 0)
                {
                    dependencyItems.Add(new DependencyItem(item.LogicalName, item.Id, _baseServerUrl)
                    {
                        RecordPrimaryField = item[primaryfield].ToString(),
                        DisplayName = displayName,
                        FindResults = findResults,
                        DependencySummary = string.Join(Environment.NewLine, findResults.Select(x => x.ToString()))
                    });
                }
            }
        }

        /// <summary>
        /// Helper method to get a fetch element from the config and prep the website Id
        /// </summary>
        /// <param name="queryName"></param>
        /// <param name="websiteId"></param>
        /// <returns></returns>
        internal XElement GetQueryElement(string queryName, string websiteId)
        {
            // clone it so we are not updating the source
            var element = new XElement(_utility.GetFetchXmlElement(queryName).Parent);

            // need to set the parent in the fetch
            var cond = element.Element("fetch")
                .Descendants("condition")
                .Where(c => c.Attribute("attribute").Value == "adx_websiteid")
                .FirstOrDefault();

            // if the website ID is passed, then add it as a filter
            if (websiteId != null)
            {
                cond.SetAttributeValue("value", websiteId);
            }
            else
            {
                // if this is the only condition, remove the filter
                var filter = cond.Parent as XElement;
                if (filter.Elements("condition").ToList().Count == 1) {
                    filter.Remove();
                }
                else {
                    cond.Remove();
                }
            }
            return element;
        }
    }
}
