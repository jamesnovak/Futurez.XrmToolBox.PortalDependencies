using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Workflow.Activities.Rules;
using Microsoft.Xrm.Tooling.Connector;

namespace Futurez.XrmToolBox
{
    public class EntityDependencies: DependencyBase
    {
        public EntityDependencies(IOrganizationService service, Utility utility, string baseServerUrl) : 
            base(service, utility, baseServerUrl) { 
        }

        public List<DependencyItem> LoadDependencies(EntityMetadata entity, string websiteId) 
        {
            var dependencyItems = new List<DependencyItem>();
            var search = new List<string>() { entity.LogicalName };

            var element = GetQueryElement("entity_webpage", websiteId);
            ProcessQuery(element, search, dependencyItems);

            element = GetQueryElement("entity_entity_form", websiteId);
            ProcessQuery(element, search, dependencyItems);

            element = GetQueryElement("entity_entity_list", websiteId);
            ProcessQuery(element, search, dependencyItems);
            
            element = GetQueryElement("entity_webformstep", websiteId);
            ProcessQuery(element, search, dependencyItems);

            element = GetQueryElement("shared_webtemplate", websiteId);
            ProcessQuery(element, search, dependencyItems);

            element = GetQueryElement("shared_contentsnippet", websiteId);
            ProcessQuery(element, search, dependencyItems);

            return dependencyItems;
        }
    }
}
