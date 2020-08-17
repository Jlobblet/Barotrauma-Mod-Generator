using System.Collections;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Barotrauma_Mod_Generator.PatchOperations
{
    internal class PatchOperationRemove : PatchOperation
    {
        private const string ElementName = "remove";

        internal new static XDocument Apply(XElement patch, XDocument document)
        {
            XAttribute xpath = patch.Attribute("sel");
            if (xpath == null)
            {
                return document;
            }

            foreach (XObject xObject in
                (IEnumerable) document.XPathEvaluate(xpath.Value))
            {
                switch (xObject)
                {
                    case XElement element:
                        element.Remove();
                        break;
                    case XAttribute attribute:
                        attribute.Remove();
                        break;
                }
            }

            return document;
        }
    }
}
