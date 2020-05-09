using System.Collections.Generic;
using System.Linq;

using Microsoft.Xrm.Sdk;

namespace Futurez.XrmToolBox
{
    public class WebLinkSetDependency : PortalConfigDependency
    {
        public WebLinkSetDependency(IOrganizationService service, Utility utility, string baseServerUrl) :
            base(service, utility, baseServerUrl)
        {
        }
        /// <summary>
        /// Override the search here to search for web link set by name and Id
        /// </summary>
        /// <param name="websiteId"></param>
        /// <param name="itemsList"></param>
        /// <param name="searchNameOnly"></param>
        /// <returns></returns>
        public override List<DependencyItem> ProcessDependencies(string websiteId, List<Entity> itemsList, bool searchNameOnly = true, string regex = null)
        {
            // ensure that these matches include the weblinks phrase
            regex = REGEX_NAME_OR_ID.Replace(LIQUID_CDS_TAG, "weblinks");

            // call the base search
            var dependencyItems = base.ProcessDependencies(websiteId, itemsList, searchNameOnly, regex);

            // now searc for the list of Web Link Sets
            var searchList = itemsList.Select(a => $"{a.FormattedValues["adx_weblinksetid"]}").ToList();
            if (!searchNameOnly) {
                searchList.AddRange(itemsList.Select(a => $"{((EntityReference)a.Attributes["adx_weblinksetid"]).Id}").ToList());
            }
            ProcessSearches(websiteId, searchList, dependencyItems, regex);

            return dependencyItems;
        }
    }
}
