using System;
using System.IO;
using System.Xml.Linq;

namespace Barotrauma_Mod_Generator.XmlUtils
{
    public static class DiffUtils
    {
        public static void CleanHeader(XDocument diff, XDocument document, out bool OverrideRoot)
        {
            if (diff.Root.GetAttributeSafe("override") == null)
            {
                diff.Root.SetAttributeValue("override", "none");
            }
            if (diff.Root.GetAttributeSafe("cleanup") == null)
            {
                diff.Root.SetAttributeValue("cleanup", "false");
            }
            OverrideRoot = false;
            switch (diff.Root.Attribute("override").Value)
            {
                case "all":
                    document.Root.Name = "Override";
                    break;
                case "root":
                    OverrideRoot = true;
                    break;
                default:
                    break;
            }
        }

        public static string RelativeToAbsoluteFilepath(string filepath, string relativeDirectory)
        {
            if (Path.IsPathFullyQualified(filepath) && Path.IsPathRooted(filepath))
            {
                return filepath;
            }
            else
            {
                return Path.Combine(relativeDirectory, filepath);
            }
        }
    }
}
