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

            var queryEl = GetQueryElement("entity_webpage", websiteId);
            ProcessQuery(queryEl, search, dependencyItems);

            queryEl = GetQueryElement("entity_entity_form", websiteId);
            ProcessQuery(queryEl, search, dependencyItems);

            queryEl = GetQueryElement("entity_entity_list", websiteId);
            ProcessQuery(queryEl, search, dependencyItems);
            
            queryEl = GetQueryElement("entity_webformstep", websiteId);
            ProcessQuery(queryEl, search, dependencyItems);

            queryEl = GetQueryElement("general_webtemplate", websiteId);
            ProcessQuery(queryEl, search, dependencyItems);

            return dependencyItems;
        }
    }
}
