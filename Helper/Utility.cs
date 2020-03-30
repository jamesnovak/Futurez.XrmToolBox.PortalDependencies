using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Deployment;
using System.Activities;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Futurez.XrmToolBox
{
    public class Utility
    {
        private XDocument _doc = null;

        public string GetFetchXml(string queryName)
        {
            var element = GetFetchXmlElement(queryName).ToString();

            return element.ToString();
        }

        public XElement GetFetchXmlElement(string queryName)
        {
            var doc = GetResourceXmlFile("FetchTemplates.xml");

            var query = doc.Root
                .Descendants("query")
                .Where(d => (string)d.Attribute("id") == queryName);

            return query.Descendants<XElement>().First();

        }

        public XDocument GetResourceXmlFile(string filename)
        {
            var asm = this.GetType().Assembly;
            using (Stream stream = asm.GetManifestResourceStream($"Futurez.XrmToolBox.Config.{filename}"))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    _doc = XDocument.Load(sr);
                }
            }
            return _doc;
        }

        public bool PortalsInstalled(IOrganizationService service) 
        {
            var entity = xrmtb.XrmToolBox.Controls.CrmActions.RetrieveEntity(service, "adx_website",true);

            return (entity != null);

        }
    }
}
