using System.Collections.Generic;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace Futurez.XrmToolBox
{
    public class EntityDependencies: DependencyBase
    {
        public EntityDependencies(IOrganizationService service, Utility utility, string baseServerUrl) : 
            base(service, utility, baseServerUrl) { 
        }

        public List<DependencyItem> LoadDependencies(EntityMetadata entity) 
        {
            var dependencyItems = new List<DependencyItem>();

            // load the fetch for Entity Form search
            ProcessQuery("entity_entity_form", entity.LogicalName, dependencyItems);

            // load the fetch for Entity List search
            ProcessQuery("entity_entity_list", entity.LogicalName, dependencyItems);

            // load the fetch for Web Form Step search
            ProcessQuery("entity_webformstep", entity.LogicalName, dependencyItems);

            // load the fetch for Web Template search
            ProcessQuery("general_webtemplate", entity.LogicalName, dependencyItems);

            return dependencyItems;
        }
    }
}
