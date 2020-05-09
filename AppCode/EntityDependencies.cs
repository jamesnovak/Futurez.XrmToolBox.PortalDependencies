using System.Collections.Generic;

using Microsoft.Xrm.Sdk;

namespace Futurez.XrmToolBox
{
    public class EntityDependencies: DependencyBase, IDependenciesProcessor
    {
        public EntityDependencies(IOrganizationService service, Utility utility, string baseServerUrl) : 
            base(service, utility, baseServerUrl) { 
        }

        /// <summary>
        /// Process the dependencies for the Entity
        /// </summary>
        /// <param name="entityName">Name of the Entity being searched</param>
        /// <param name="websiteId">ID of the website being searched</param>
        /// <param name="itemsList">List of search items </param>
        /// <returns>List of DependencyItems found in the Portal entities</returns>
        public List<DependencyItem> ProcessDependencies(string entityName, string websiteId = null, List<object> itemsList = null, bool searchNameOnly = true, string regex = null)
        {
            var dependencyItems = new List<DependencyItem>();
            var searchList = new List<string>() { entityName };

            var element = GetQueryElement("shared_webpage", websiteId);
            ProcessQuery(element, searchList, dependencyItems);

            element = GetQueryElement("entity_entity_form", websiteId);
            ProcessQuery(element, searchList, dependencyItems);

            element = GetQueryElement("entity_entity_list", websiteId);
            ProcessQuery(element, searchList, dependencyItems);

            element = GetQueryElement("entity_webformstep", websiteId);
            ProcessQuery(element, searchList, dependencyItems);

            element = GetQueryElement("shared_webtemplate", websiteId);
            ProcessQuery(element, searchList, dependencyItems);

            element = GetQueryElement("shared_contentsnippet", websiteId);
            ProcessQuery(element, searchList, dependencyItems);

            return dependencyItems;
        }

        public List<DependencyItem> ProcessDependencies(string websiteId, List<Entity> itemsList, bool searchNameOnly = true, string regex = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
