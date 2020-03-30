using System.Linq;
using System.Collections.Generic;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Deployment;

namespace Futurez.XrmToolBox
{
    public class AttributeDependencies : DependencyBase
    {

        public AttributeDependencies(IOrganizationService service, Utility utility, string baseServerUrl) :
            base(service, utility, baseServerUrl)
        {
        }

        public List<DependencyItem> LoadDependencies(List<AttributeMetadata> attributes)
        {
            var dependencyItems = new List<DependencyItem>();
            var attNames = attributes.Select(a => a.LogicalName).ToList();

            // load the fetch for Web Template search
            ProcessQuery("general_webtemplate", attNames, dependencyItems);

            // special query for entity forms and attributes
            ProcessEntityFormQuery(attributes, dependencyItems);

            return dependencyItems;
        }

        /// <summary>
        /// Process the query for the list of search values
        /// </summary>
        /// <param name="queryName"></param>
        /// <param name="searchValues"></param>
        /// <param name="dependencyItems"></param>
        private void ProcessEntityFormQuery(List<AttributeMetadata> attribs, List<DependencyItem> dependencyItems)
        {
            // clone it so we are not updating the source
            var element = new XElement(_utility.GetFetchXmlElement("attribute_entityform").Parent);

            // need to set the parent in the fetch
            var entName = attribs[0].EntityLogicalName;
            var attNames = attribs.Select(a => a.LogicalName).ToList();

            element.Element("fetch")
                .Descendants("condition")
                .Where(c => c.Attribute("attribute").Value == "adx_entityname")
                .FirstOrDefault()
                .SetAttributeValue("value", entName);

            // now handle the standard processing 
            ProcessQuery(element, attNames, dependencyItems);
        }
    }
}
