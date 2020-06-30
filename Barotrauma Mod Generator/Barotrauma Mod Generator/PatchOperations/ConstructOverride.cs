using Barotrauma_Mod_Generator.XmlUtils;
using System.Xml.Linq;

namespace Barotrauma_Mod_Generator.PatchOperations
{
    internal sealed class ConstructOverride
    {
        public static void Override(XElement elt)
        {
            XElement ItemElement = elt.GetSecondLevelAncestor();
            if (ItemElement.Name.LocalName != "Override")
            {
                XElement OverrideElement = new XElement("Override");
                OverrideElement.Add(ItemElement);
                elt.Document.Root.Add(OverrideElement);
                ItemElement.Remove();
            }
        }

        public static XDocument OverrideRoot(XDocument doc)
        {
            return new XDocument(new XElement("Override", doc.Root));
        }
    }
}
