using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Barotrauma_Mod_Generator.Util;

namespace Barotrauma_Mod_Generator.PatchOperations
{
    public static class ApplyPatchOperation
    {
        public static XDocument ApplyAll(XDocument diff)
        {
            return ApplyAll(diff, Directory.GetCurrentDirectory());
        }

        public static XDocument ApplyAll(XDocument diff, string relativeDirectory)
        {
            string file = diff.Root.GetAttributeSafe("file");
            if (file == null)
            {
                throw new ArgumentNullException(nameof(diff));
            }

            file = DiffUtils.RelativeToAbsoluteFilepath(file, relativeDirectory);
            XDocument document = XDocument.Load(file);
            document = ApplyAll(diff, document);
            return document;
        }

        private static XDocument ApplyAll(XDocument diff, XDocument document)
        {
            DiffUtils.CleanHeader(diff, document, out bool overrideRoot);

            HashSet<string> overrideXpaths =
                XmlUtils.GetFilteredXPaths(diff, document,
                                           (patch, elt) =>
                                               patch.ParseBoolAttribute("override"));
            HashSet<string> saveXpaths =
                XmlUtils.GetFilteredXPaths(diff, document,
                                           (patch, elt) =>
                                               !patch.ParseBoolAttribute("override"));

            document = diff.Root?.Elements()
                           .Aggregate(document,
                                      (current, patch) => Apply(patch, current));
            
            diff.Root.ParseBoolAttribute("cleanup", out bool cleanup);
            
            if (cleanup && document?.Root != null)
            {
                foreach (XElement element in document.Root.Elements().Reverse())
                {
                    string xpath = element.GetAbsoluteXPath();
                    if (overrideXpaths.Contains(xpath))
                    {
                        ConstructOverride.Override(element);
                    }
                    else if (!saveXpaths.Contains(xpath))
                    {
                        element.Remove();
                    }
                }
            }

            if (overrideRoot)
            {
                document = ConstructOverride.OverrideRoot(document);
            }

            return document;
        }

        private static XDocument Apply(XElement patch, XDocument document)
        {
            document = patch.Name.LocalName switch
                       {
                           "add" => PatchOperationAdd.Apply(patch, document),
                           "remove" => PatchOperationRemove.Apply(patch, document),
                           "replace" => PatchOperationEdit.Apply(patch, document),
                           _ => document
                       };
            return document;
        }
    }
}
