using System.Linq;
using System.Collections.Generic;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace Futurez.XrmToolBox
{
    public class AttributeDependencies : DependencyBase, IChildDependencies
    {
        public AttributeDependencies(IOrganizationService service, Utility utility, string baseServerUrl) :
            base(service, utility, baseServerUrl) {
        }

        /// <summary>
        /// Process the dependencies for the Attributes
        /// </summary>
        /// <param name="itemsList"></param>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public List<DependencyItem> ProcessDependencies(List<object> itemsList, string entityName, string websiteId)
        {
            var attributes = itemsList.ConvertAll<AttributeMetadata>(a => a as AttributeMetadata);
            var dependencyItems = new List<DependencyItem>();
            var attNames = attributes.Select(a => a.LogicalName).ToList();
            var entName = attributes[0].EntityLogicalName;

            // load the fetch for Web Template search
            var element = GetQueryElement("general_webtemplate", websiteId);
            ProcessQuery(element, attNames, dependencyItems);

            // special query for entity forms and attributes
            // ProcessEntityFormQuery(attributes, dependencyItems);
            ProcessEntityQuery("attribute_entityform", entName, websiteId, attNames, dependencyItems);
            ProcessEntityQuery("attribute_entitylist", entName, websiteId, attNames, dependencyItems);

            return dependencyItems;
        }
    }
}
