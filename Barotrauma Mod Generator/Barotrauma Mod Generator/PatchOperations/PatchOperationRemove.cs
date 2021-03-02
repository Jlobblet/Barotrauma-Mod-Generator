using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Barotrauma_Mod_Generator.PatchOperations
{
    internal class PatchOperationRemove : PatchOperation
    {
        public PatchOperationRemove(XElement patch, XDocument document) : base(patch, document)
        {
        }

        public override XDocument Apply()
        {
            XAttribute xpath = Patch.Attribute("sel");
            if (xpath == null) return Document;

            IEnumerable<XObject> objs = ((IEnumerable) Document.XPathEvaluate(xpath.Value)).Cast<XObject>();

            foreach (XObject xObject in objs.Reverse())
                switch (xObject)
                {
                    case XElement element:
                        element.Remove();
                        break;
                    case XAttribute attribute:
                        attribute.Remove();
                        break;
                }

            return Document;
        }
    }
}
