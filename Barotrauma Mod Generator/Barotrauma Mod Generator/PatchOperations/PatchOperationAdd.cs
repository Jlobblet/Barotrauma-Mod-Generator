using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Barotrauma_Mod_Generator.PatchOperations
{
    internal class PatchOperationAdd : PatchOperation
    {
        public PatchOperationAdd(XElement patch, XDocument document) : base(patch, document)
        {
        }

        public override XDocument Apply()
        {
            string xpath = Patch.Attribute("sel")?.Value;
            if (xpath == null) return Document;

            MatchCollection matches = Regex.Matches(xpath, @"^(?<element>.+)/@(?<attributeName>[a-zA-Z]+)$");

            if (!matches.Any())
            {
                foreach (XElement elt in Document.Root.XPathSelectElements(xpath)) elt.Add(Patch.Elements());
            }
            else
            {
                string newXpath = matches[0].Groups["element"].Value;
                string attributeName = matches[0].Groups["attributeName"].Value;
                foreach (XElement elt in Document.Root.XPathSelectElements(newXpath))
                    elt.SetAttributeValue(attributeName, Patch.Value);
            }

            return Document;
        }
    }
}
