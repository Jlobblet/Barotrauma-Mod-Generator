using System.Collections;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Barotrauma_Mod_Generator.PatchOperations
{
    internal sealed class PatchOperationEdit : PatchOperation
    {
#pragma warning disable IDE0051
        private new readonly string ElementName = "replace";
#pragma warning restore IDE0051
        internal static new XDocument Apply(XElement patch, XDocument document)
        {
            XAttribute xpath = patch.Attribute("sel");
            if (xpath == null) { return document; }
            foreach (XObject xObject in (IEnumerable)document.XPathEvaluate(xpath.Value))
            {
                if (xObject is XAttribute attribute)
                {
                    attribute.Value = patch.Value;
                }
                else if (xObject is XElement element)
                {
                    element.Value = patch.Value;
                }
            }
            return document;
        }
    }
}
