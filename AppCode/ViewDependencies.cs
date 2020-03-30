using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace Futurez.XrmToolBox
{
    public class ViewDependencies : DependencyBase
    {
        public ViewDependencies(IOrganizationService service, Utility utility, string baseServerUrl) :
           base(service, utility, baseServerUrl) {
        }

        public List<DependencyItem> LoadDependencies(List<AttributeMetadata> attributes)
        {
            var dependencyItems = new List<DependencyItem>();
            var attNames= attributes.Select(a => a.LogicalName).ToList();

            // load the fetch for Web Template search
            ProcessQuery("general_webtemplate", attNames, dependencyItems);

            return dependencyItems;
        }
    }
}
