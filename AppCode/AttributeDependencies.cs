using System.Linq;
using System.Collections.Generic;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace Futurez.XrmToolBox
{
    /// <summary>
    /// Hanldes retrieving dependencies for Attributes
    /// </summary>
    public class AttributeDependencies : DependencyBase, IDependenciesProcessor
    {
        public AttributeDependencies(IOrganizationService service, Utility utility, string baseServerUrl) :
            base(service, utility, baseServerUrl) {
        }

        /// <summary>
        /// Process the dependencies for the Attributes
        /// </summary>
        /// <param name="entityName">Name of the Entity being searched</param>
        /// <param name="websiteId">ID of the website being searched</param>
        /// <param name="itemsList">List of search items </param>
        /// <returns>List of DependencyItems found in the Portal entities</returns>
        public List<DependencyItem> ProcessDependencies(string entityName, string websiteId, List<object> itemsList)
        {
            var attributes = itemsList.ConvertAll<AttributeMetadata>(a => a as AttributeMetadata);
            var dependencyItems = new List<DependencyItem>();
            var attNames = attributes.Select(a => a.LogicalName).ToList();
            var entName = attributes[0].EntityLogicalName;

            // load the fetch for Web Template search
            var element = GetQueryElement("shared_webtemplate", websiteId);
            ProcessQuery(element, attNames, dependencyItems);

            element = GetQueryElement("shared_contentsnippet", websiteId);
            ProcessQuery(element, attNames, dependencyItems);

            // special query for entity forms and attributes
            ProcessEntityQuery("attribute_entityform", entName, websiteId, attNames, dependencyItems);
            ProcessEntityQuery("attribute_entitylist", entName, websiteId, attNames, dependencyItems);
            ProcessEntityQuery("attribute_webformstep", entName, websiteId, attNames, dependencyItems);
            
            return dependencyItems;
        }
    }
}
