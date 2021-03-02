using System.Collections;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Barotrauma_Mod_Generator.PatchOperations
{
    internal class PatchOperationEdit : PatchOperation
    {
        public PatchOperationEdit(XElement patch, XDocument document) : base(patch, document)
        {
            
        }
        
        
        public override XDocument Apply()
        {
            XAttribute xpath = Patch.Attribute("sel");
            if (xpath == null)
            {
                return Document;
            }

            foreach (XObject xObject in
                (IEnumerable) Document.XPathEvaluate(xpath.Value))
            {
                switch (xObject)
                {
                    case XAttribute attribute:
                        attribute.Value = Patch.Value;
                        break;
                    case XElement element:
                        if (string.IsNullOrWhiteSpace(Patch.Value) && Patch.HasElements)
                        {
                            element.Elements().Remove();
                            element.Add(Patch.Elements());
                        }
                        else
                        {
                            element.Value = Patch.Value;
                        }

                        break;
                }
            }

            return Document;
        }
    }
}
