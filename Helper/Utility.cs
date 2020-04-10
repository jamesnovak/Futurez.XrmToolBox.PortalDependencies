using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Linq;

using Microsoft.Xrm.Sdk;

namespace Futurez.XrmToolBox
{
    public struct HighLightColor 
    {
        public Color ForeColor;
        public Color BackColor;

        public HighLightColor(Color foreColor, Color backColor) 
        {
            ForeColor = foreColor;
            BackColor = backColor;
        }
    }

    /// <summary>
    /// Utility class with stuff.
    /// </summary>
    public class Utility
    {
        private readonly List<HighLightColor> _highlightColors = 
            new List<HighLightColor>
            {
                new HighLightColor (Color.White, Color.Indigo),
                new HighLightColor (Color.White, Color.DarkGreen),
                new HighLightColor (Color.White, Color.DarkOrchid),
                new HighLightColor (Color.White, Color.DarkRed),
                new HighLightColor (Color.White, Color.IndianRed),
                new HighLightColor (Color.White, Color.DarkViolet),
                new HighLightColor (Color.White, Color.Navy),
                new HighLightColor (Color.White, Color.DarkTurquoise),
                new HighLightColor (Color.White, Color.Blue)
            };

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

        public HighLightColor GetHighlightColor()
        {
            var index = new Random().Next(_highlightColors.Count - 1);
            return GetHighlightColor(index);
        }

        public HighLightColor GetHighlightColor(int lastIndex)
        {
            return _highlightColors[lastIndex % _highlightColors.Count];
        }

    }

}
