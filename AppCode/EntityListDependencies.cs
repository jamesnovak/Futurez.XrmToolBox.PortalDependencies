using System.Collections.Generic;

using Microsoft.Xrm.Sdk;

namespace Futurez.XrmToolBox
{
    public class EntityListDependency : PortalConfigDependency
    {
        public EntityListDependency(IOrganizationService service, Utility utility, string baseServerUrl) :
            base(service, utility, baseServerUrl)
        {
        }
        /// <summary>
        /// Override the search for custom regex matching
        /// </summary>
        /// <param name="websiteId"></param>
        /// <param name="itemsList"></param>
        /// <param name="searchNameOnly"></param>
        /// <returns></returns>
        public override List<DependencyItem> ProcessDependencies(string websiteId, List<Entity> itemsList, bool searchNameOnly = true, string regex = null)
        {
            // ensure that these matches include the site settings phrase settings
            regex = "(\\s*entitylist(\\s*.*\\s*=)?\\s*(id:|name:)?\\s*('|\")?" + SRCH_SLUG + "('|\")?\\s*)";

            // call the base search
            var dependencyItems = base.ProcessDependencies(websiteId, itemsList, searchNameOnly, regex);

            return dependencyItems;
        }
    }
}
