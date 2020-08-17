using System.Xml.Linq;
using System.Xml.XPath;

namespace Barotrauma_Mod_Generator.PatchOperations
{
    internal class PatchOperationAdd : PatchOperation
    {
        private const string ElementName = "add";

        internal new static XDocument Apply(XElement patch, XDocument document)
        {
            XAttribute xpath = patch.Attribute("sel");
            if (xpath == null)
            {
                return document;
            }

            foreach (XElement elt in document.Root.XPathSelectElements(xpath.Value))
            {
                elt.Add(patch.Elements());
            }

            return document;
        }
    }
}
