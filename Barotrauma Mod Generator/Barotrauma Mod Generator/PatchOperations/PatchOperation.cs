using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Barotrauma_Mod_Generator.PatchOperations
{
    public class PatchOperation
    {
        private static string ElementName => null;

        public static XDocument Apply(XDocument diff)
        {
            XDocument document = null;
            if (diff.Root?.Attribute("file") == null)
            {
                return null;
            }

            document = XDocument.Load(diff.Root.Attribute("file").Value);
            return Apply(diff, document);
        }

        public static XDocument Apply(XDocument diff, XDocument document)
        {
            return diff.Root.XPathSelectElements(ElementName)
                       .Aggregate(document,
                                  (current, element) => Apply(element, current));
        }

        public static XDocument Apply(XElement element, XDocument document)
        {
            throw new
                NotImplementedException("PatchOperation is a base class; use one of its descendants instead");
        }
    }
}
