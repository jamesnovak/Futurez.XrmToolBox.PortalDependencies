using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace Futurez.XrmToolBox
{
    public class ViewDependencies : DependencyBase, IChildDependencies
    {
        public ViewDependencies(IOrganizationService service, Utility utility, string baseServerUrl) :
           base(service, utility, baseServerUrl) {
        }
        /// <summary>
        /// Process generic list of dependencies
        /// </summary>
        /// <param name="views"></param>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public List<DependencyItem> ProcessDependencies(List<object> itemsList, string entityName, string websiteId)
        {
            var dependencyItems = new List<DependencyItem>();
            var views = itemsList.ConvertAll<Entity>(i => i as Entity);
            var viewIds = views.Select(a => a.Id.ToString()).ToList();
            
            ProcessEntityQuery("view_entitylist", entityName, websiteId, viewIds, dependencyItems);  

            return dependencyItems;
        }
    }
}
