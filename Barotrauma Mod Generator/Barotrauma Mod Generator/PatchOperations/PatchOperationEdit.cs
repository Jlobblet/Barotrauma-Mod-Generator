using System.Collections;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Barotrauma_Mod_Generator.PatchOperations
{
    internal class PatchOperationEdit : PatchOperation
    {
        private const string ElementName = "replace";

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
                    case XAttribute attribute:
                        attribute.Value = patch.Value;
                        break;
                    case XElement element:
                        if (string.IsNullOrWhiteSpace(patch.Value) && patch.HasElements)
                        {
                            element.Elements().Remove();
                            element.Add(patch.Elements());
                        }
                        else
                        {
                            element.Value = patch.Value;
                        }

                        break;
                }
            }

            return document;
        }
    }
}
