using System;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Barotrauma_Mod_Generator.PatchOperations
{
    public class PatchOperation
    {
        private static string elementName;
        internal static string ElementName { get => elementName; set => elementName = value; }

        public static XDocument Apply(XDocument diff)
        {
            XDocument document = null;
            if (diff.Root.Attribute("file") == null) { return document; }
            document = XDocument.Load(diff.Root.Attribute("file").Value);
            return Apply(diff, document);
        }

        public static XDocument Apply(XDocument diff, XDocument document)
        {
            foreach (XElement element in diff.Root.XPathSelectElements(ElementName))
            {
                document = Apply(element, document);
            }
            return document;
        }

        public static XDocument Apply(XElement element, XDocument document)
        {
            throw new NotImplementedException("PatchOperation is a base class; use one of its descendants instead");
        }
    }
}
