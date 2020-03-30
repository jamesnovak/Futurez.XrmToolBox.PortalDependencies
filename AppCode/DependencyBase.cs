using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Xml.Linq;
using Microsoft.IdentityModel.Web;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Futurez.XrmToolBox
{
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

            var filter = fetch.Element("entity")
                              .Element("filter");

            var conditions = filter
                .Elements("condition")
                .Where(c => c.Attribute("operator").Value != "null")
                .Select(c => new XElement(c))
                .ToArray();

            filter.Elements("condition")
                .Where(c => c.Attribute("operator").Value != "null")
                .Remove();
            
            foreach (var cond in conditions)
            {
                // save the list of conditions so we can filter later
                var name = cond.Attribute("attribute").Value;

                if (!conditionAttrs.Contains(name)) { 
                    conditionAttrs.Add(name); 
                }

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

            foreach (var item in response.Entities)
            {
                var values = new List<string>();
                var findResults = new List<FindResult>();

                foreach (var i in item.Attributes.Where(a => conditionAttrs.Contains(a.Key)))
                {
                    // see which search value was found here 
                    //var search = searchValues
                    //    .Where(t => (bool)i.Value?.ToString().Contains(t))
                    //    .Select(t => t).ToList();

                    findResults.Add(new FindResult() {
                                        SearchValues = searchValues,
                                        AttributeName = i.Key,
                                        AttributeValue = i.Value?.ToString()
                                    });
                }

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
}
