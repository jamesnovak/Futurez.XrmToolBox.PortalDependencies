using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Futurez.XrmToolBox
{
    public interface IDependenciesProcessor
    {
        List<DependencyItem> ProcessDependencies(string entityName, string websiteId, List<object> itemsList, bool searchNameOnly = true, string regex = null);
        List<DependencyItem> ProcessDependencies(string websiteId, List<Entity> itemsList, bool searchNameOnly = true, string regex = null);
    }

    public class DependencyBase
    {
        internal const string SRCH_SLUG = "{_search_value_}";
        internal const string LIQUID_CDS_TAG = "{_cds_tag_}";

        internal IOrganizationService _service;
        internal Utility _utility;
        internal string _baseServerUrl;

        public List<string> EntitiesSearched { get; internal set; } = new List<string>();

        public DependencyBase(IOrganizationService service, Utility utility, string baseServerUrl)
        {
            _service = service;
            _utility = utility;
            _baseServerUrl = baseServerUrl;
        }

        /// <summary>
        /// Helper method that retreieves the element 
        /// </summary>
        /// <param name="queryName"></param>
        /// <param name="websiteId"></param>
        /// <param name="searchValues"></param>
        /// <param name="dependencyItems"></param>
        /// <param name="regex"></param>
        internal void ProcessQuery(string queryName, string websiteId, List<string> searchValues, List<DependencyItem> dependencyItems, string regex = null)
        {
            var element = GetQueryElement(queryName, websiteId);

            ProcessQuery(element, searchValues, dependencyItems, regex);
        }

        /// <summary>
        /// Process a query for the list of search values
        /// </summary>
        /// <param name="queryName"></param>
        /// <param name="searchValues"></param>
        /// <param name="dependencyItems"></param>
        internal void ProcessEntityQuery(string queryName, string entityName, string websiteId, List<string> searchValues, List<DependencyItem> dependencyItems, string regex = null)
        {
            var element = GetQueryElement(queryName, websiteId);

            // need to set the parent in the fetch
            element.Element("fetch")
                .Descendants("condition")
                .Where(c => c.Attribute("attribute").Value == "adx_entityname" ||
                            c.Attribute("attribute").Value == "adx_targetentitylogicalname")
                .FirstOrDefault()
                .SetAttributeValue("value", entityName);

            // now handle the standard processing 
            ProcessQuery(element, searchValues, dependencyItems, regex);
        }

        /// <summary>
        /// Process the query for the list of search values
        /// </summary>
        /// <param name="element"></param>
        /// <param name="searchValues"></param>
        /// <param name="dependencyItems"></param>
        /// <param name="regex">optional regex for further filtering</param>
        internal void ProcessQuery(XElement element, List<string> searchValues, List<DependencyItem> dependencyItems, string regex = null)
        {
            var displayName = element.Attribute("name").Value;
            var primaryfield = element.Attribute("primaryfield").Value;
            var fetch = element.Element("fetch");

            if (regex == null) {
                regex = $"(^|[^a-z])*{SRCH_SLUG}([^a-z]|$)";
            }

            // make sure we are only searchin for the values once!
            searchValues = searchValues.Distinct().ToList();

            // capture the items being searched 
            EntitiesSearched.Add(displayName);

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
                var values = new List<string>();
                var findResults = new List<FindResult>();

                foreach (var i in item.Attributes.Where(a => conditionAttrs.Contains(a.Key)))
                {
                    foreach (var s in searchValues)
                    {
                        // now check each condition.  if the find is not an exact match, check the regex to see if the correct match exists.  
                        var match = (s == i.Value?.ToString());
                        if (!match) {
                            var srch = s.Replace("(", @"\(")
                                        .Replace(")", @"\)")
                                        .Replace(@"[", @"\[")
                                        .Replace(@"]", @"\]")
                                        .Replace(@"/", @"\/");
                            var reg = regex.Replace(SRCH_SLUG, srch);
                            var re = new Regex(reg);

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

        /// <summary>
        /// Apply some additional filters using regex
        /// </summary>
        /// <param name="re"></param>
        /// <param name="dependencyItems"></param>
        internal void AdditionalRegExFilter(string regex, List<DependencyItem> dependencyItems) 
        {
            for (var i = dependencyItems.Count - 1; i >= 0; i--)
            {
                var include = false;
                var dep = dependencyItems[i];

                foreach (var res in dep.FindResults)
                {

                    foreach (var srch in res.SearchValues)
                    {

                        var reg = regex.Replace("{search_value}", srch);
                        var re = new Regex(regex);

                        if (re.IsMatch(res.AttributeValue))
                        {
                            include = true;
                            break;
                        }

                    }
                }
                if (!include)
                {
                    dependencyItems.Remove(dep);
                }
            }
        }
    }
}
