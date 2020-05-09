using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;

namespace Futurez.XrmToolBox
{
    public class ViewDependencies : DependencyBase, IDependenciesProcessor  
    {
        public ViewDependencies(IOrganizationService service, Utility utility, string baseServerUrl) :
           base(service, utility, baseServerUrl) {
        }

        /// <summary>
        /// Process the dependencies for the Views
        /// </summary>
        /// <param name="entityName">Name of the Entity being searched</param>
        /// <param name="websiteId">ID of the website being searched</param>
        /// <param name="itemsList">List of search items </param>
        /// <returns>List of DependencyItems found in the Portal entities</returns>
        public List<DependencyItem> ProcessDependencies(string entityName, string websiteId, List<object> itemsList, bool searchNameOnly = true, string regex = null)
        {
            var dependencyItems = new List<DependencyItem>();
            var views = itemsList.ConvertAll<Entity>(i => i as Entity);
            var viewIds = views.Select(a => a.Id.ToString()).ToList();

            ProcessEntityQuery("view_entitylist", entityName, websiteId, viewIds, dependencyItems);

            // regex that will find entity views by ID 
            regex = "(\\s*entityview\\s*(.*\\s*=\\s*)?\\s*(id:('|\")?" + SRCH_SLUG + "('|\")?){1}\\s*)";

            // search for view IDs
            ProcessQuery("shared_webtemplate", websiteId, viewIds, dependencyItems, regex);
            ProcessQuery("shared_contentsnippet", websiteId, viewIds, dependencyItems, regex);
            ProcessQuery("shared_webpage", websiteId, viewIds, dependencyItems, regex);

            // now search web templates for entity views by name
            var names = views.Select(a => a.Attributes["name"].ToString()).ToList();

            regex = "(\\s*entityview\\s*(.*\\s*=\\s*)?\\s*(\\s*logical_name:\\s*('|\")?" + entityName + "('|\")?,\\s*name:('|\")?" + SRCH_SLUG + "('|\")?){1}\\s*)";
            ProcessQuery("shared_webtemplate", websiteId, names, dependencyItems, regex);
            ProcessQuery("shared_contentsnippet", websiteId, names, dependencyItems, regex);
            ProcessQuery("shared_webpage", websiteId, names, dependencyItems, regex);
            
            return dependencyItems;
        }

        public List<DependencyItem> ProcessDependencies(string websiteId, List<Entity> itemsList, bool searchNameOnly = true, string regex = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
