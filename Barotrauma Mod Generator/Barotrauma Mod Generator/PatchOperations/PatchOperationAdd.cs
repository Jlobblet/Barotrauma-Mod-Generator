using System.Xml.Linq;
using System.Xml.XPath;

namespace Barotrauma_Mod_Generator.PatchOperations
{
    internal sealed class PatchOperationAdd : PatchOperation
    {
        private new readonly string ElementName = "add";
        internal static new XDocument Apply(XElement patch, XDocument document)
        {
            XAttribute xpath = patch.Attribute("sel");
            if (xpath == null) { return document; }
            foreach (XElement elt in document.Root.XPathSelectElements(xpath.Value))
            {
                elt.Add(patch.Elements());
            }
            return document;
        }
    }
}
