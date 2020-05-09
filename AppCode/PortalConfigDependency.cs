using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xrm.Sdk;

namespace Futurez.XrmToolBox
{
    /// <summary>
    /// Shared depencency checker class that handles common searches for Configruation types
    /// </summary>
    public class PortalConfigDependency : DependencyBase, IDependenciesProcessor
    {
        /// <summary>
        /// common regex for by name or id.  ex: snippets[name], weblinks[name/id]
        /// </summary>
        internal const string REGEX_NAME_OR_ID = "(\\s*" + LIQUID_CDS_TAG + "\\s*\\[{1}\\s*(\"|')?" + SRCH_SLUG + "(\"|')?\\s*]{1}.*-?(}}|%}){1})";

        /// <summary>
        /// common regex for by name or id.  ex: webform name:'name', entityform name:"name/id"
        /// </summary>
        internal const string REGEX_NAME_PARAM = "(\\s*" + LIQUID_CDS_TAG + "\\s*(name\\s*:){1}\\s*(\"|')?\\s*" + SRCH_SLUG + "\\s*(\"|')?\\s*-?%}{1})";

        public PortalConfigDependency(IOrganizationService service, Utility utility, string baseServerUrl) :
            base(service, utility, baseServerUrl)
        {
        }
        /// <summary>
        /// Common method for searching records using FetchXml
        /// </summary>
        /// <param name="websiteId"></param>
        /// <param name="itemsList"></param>
        /// <returns></returns>
        public virtual List<DependencyItem> ProcessDependencies(string websiteId, List<Entity> itemsList, bool searchNameOnly = true, string regex = null)
        {
            var dependencyItems = new List<DependencyItem>();
            var searchList = itemsList.Select(a => $"{a.Attributes["adx_name"]}").ToList();

            // add the IDs to the list of search elements 
            if (!searchNameOnly) {
                searchList.AddRange(itemsList.Select(a => $"{a.Id}").ToList());
            }

            // common method for portal config searches
            ProcessSearches(websiteId, searchList, dependencyItems, regex);

            return dependencyItems;
        }

        /// <summary>
        /// common method for portal config searches, covers target entity queries
        /// </summary>
        /// <param name="websiteId"></param>
        /// <param name="searchList"></param>
        /// <param name="dependencyItems"></param>
        internal void ProcessSearches(string websiteId, List<string> searchList, List<DependencyItem> dependencyItems, string regex = null) {

            // var element = GetQueryElement("shared_webtemplate", websiteId);
            ProcessQuery("shared_webtemplate", websiteId, searchList, dependencyItems, regex);

            // element = GetQueryElement("shared_webpage", websiteId);
            ProcessQuery("shared_webpage", websiteId, searchList, dependencyItems, regex);

            // element = GetQueryElement("config_entityform", websiteId);
            ProcessQuery("config_entityform", websiteId, searchList, dependencyItems, regex);

            // element = GetQueryElement("shared_contentsnippet", websiteId);
            ProcessQuery("shared_contentsnippet", websiteId, searchList, dependencyItems, regex);

            // element = GetQueryElement("config_webformstep", websiteId);
            ProcessQuery("config_webformstep", websiteId, searchList, dependencyItems, regex);
        }

        public List<DependencyItem> ProcessDependencies(string entityName, string websiteId = null, List<object> itemsList = null, bool searchNameOnly = true, string regex = null)
        {
            throw new NotImplementedException();
        }
    }
}