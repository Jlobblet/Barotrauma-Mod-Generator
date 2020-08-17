using System.IO;
using System.Xml.Linq;
// ReSharper disable PossibleNullReferenceException

namespace Barotrauma_Mod_Generator.Util
{
    public static class DiffUtils
    {
        public static void CleanHeader(XDocument diff, XDocument document, out bool overrideRoot)
        {
            if (diff.Root.GetAttributeSafe("override") == null)
            {
                diff.Root.SetAttributeValue("override", "none");
            }
            if (diff.Root.GetAttributeSafe("cleanup") == null)
            {
                diff.Root.SetAttributeValue("cleanup", "false");
            }
            overrideRoot = false;
            switch (diff.Root.Attribute("override").Value)
            {
                case "all":
                    document.Root.Name = "Override";
                    break;
                case "root":
                    overrideRoot = true;
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
