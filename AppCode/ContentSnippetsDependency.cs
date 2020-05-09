using System.Collections.Generic;

using Microsoft.Xrm.Sdk;

namespace Futurez.XrmToolBox
{
    public class ContentSnippetsDependency : PortalConfigDependency
    {
        public ContentSnippetsDependency(IOrganizationService service, Utility utility, string baseServerUrl) :
            base(service, utility, baseServerUrl) {
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
            // ensure that these matches include the snippets phrase
            regex = REGEX_NAME_OR_ID.Replace(LIQUID_CDS_TAG, "snippets");

            // call the base search
            var dependencyItems = base.ProcessDependencies(websiteId, itemsList, searchNameOnly, regex);

            return dependencyItems;
        }
    }
}
