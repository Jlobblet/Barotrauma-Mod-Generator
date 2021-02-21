using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Barotrauma_Mod_Generator.PatchOperations
{
    internal class PatchOperationAdd : PatchOperation
    {
        private const string ElementName = "add";

        internal new static XDocument Apply(XElement patch, XDocument document)
        {
            string xpath = patch.Attribute("sel")?.Value;
            if (xpath == null)
            {
                return document;
            }

            MatchCollection matches = Regex.Matches(xpath, @"^(?<element>.+)/@(?<attributeName>[a-zA-Z]+)$");

            if (!matches.Any())
            {
                foreach (XElement elt in document.Root.XPathSelectElements(xpath))
                {
                    elt.Add(patch.Elements());
                }
            }
            else
            {
                string newXpath = matches[0].Groups["element"].Value;
                string attributeName = matches[0].Groups["attributeName"].Value;
                foreach (XElement elt in document.Root.XPathSelectElements(newXpath))
                {
                    elt.SetAttributeValue(attributeName, patch.Value);
                }
            }

            return document;
        }
    }
}
