using System.Collections.Generic;
using System.Linq;

using Microsoft.Xrm.Sdk;

namespace Futurez.XrmToolBox
{
    public class FormDependencies : DependencyBase, IDependenciesProcessor
    {
        public FormDependencies(IOrganizationService service, Utility utility, string baseServerUrl) :
            base(service, utility, baseServerUrl) {
        }

        /// <summary>
        /// Process the dependencies for the Forms
        /// </summary>
        /// <param name="entityName">Name of the Entity being searched</param>
        /// <param name="websiteId">ID of the website being searched</param>
        /// <param name="itemsList">List of search items </param>
        /// <returns>List of DependencyItems found in the Portal entities</returns>
        public List<DependencyItem> ProcessDependencies(string entityName, string websiteId, List<object> itemsList, bool searchNameOnly = true, string regex = null)
        {
            var dependencyItems = new List<DependencyItem>();
            var forms = itemsList.ConvertAll<Entity>(i => i as Entity);

            var formNames = forms.Select(a => a.Attributes["name"].ToString()).ToList();
            
            ProcessEntityQuery("form_entityform", entityName, websiteId, formNames, dependencyItems);

            formNames.AddRange( forms.Select(a => a.LogicalName).ToList());

            ProcessEntityQuery("form_webformstep", entityName, websiteId, formNames, dependencyItems);

            return dependencyItems;
        }

        public List<DependencyItem> ProcessDependencies(string websiteId, List<Entity> itemsList, bool searchNameOnly = true, string regex = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
