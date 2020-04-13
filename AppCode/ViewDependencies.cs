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
        public List<DependencyItem> ProcessDependencies(string entityName, string websiteId, List<object> itemsList)
        {
            var dependencyItems = new List<DependencyItem>();
            var views = itemsList.ConvertAll<Entity>(i => i as Entity);
            var viewIds = views.Select(a => a.Id.ToString()).ToList();
            
            ProcessEntityQuery("view_entitylist", entityName, websiteId, viewIds, dependencyItems);

            //var element = GetQueryElement("shared_contentsnippet", websiteId);
            //ProcessQuery(element, viewIds, dependencyItems);

            return dependencyItems;
        }
    }
}
