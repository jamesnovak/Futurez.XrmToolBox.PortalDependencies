using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;

namespace Futurez.XrmToolBox
{
    public class FormDependencies : DependencyBase, IChildDependencies
    {
        public FormDependencies(IOrganizationService service, Utility utility, string baseServerUrl) :
            base(service, utility, baseServerUrl) {
        }

        /// <summary>
        /// Load dependencies for the list of selected Forms
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        public List<DependencyItem> ProcessDependencies(List<object> itemsList, string entityName, string websiteId)
        {
            var dependencyItems = new List<DependencyItem>();
            var forms = itemsList.ConvertAll<Entity>(i => i as Entity);

            var formNames = forms.Select(a => a.Attributes["name"].ToString()).ToList();
            
            ProcessEntityQuery("form_entityform", entityName, websiteId, formNames, dependencyItems);
            
            var element = GetQueryElement("shared_contentsnippet", websiteId);
            ProcessQuery(element, formNames, dependencyItems);

            return dependencyItems;
        }
    }
}
