using Barotrauma_Mod_Generator.XmlUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Barotrauma_Mod_Generator.PatchOperations
{
    public sealed class ApplyPatchOperation
    {
        public static XDocument ApplyAll(XDocument diff)
        {
            return ApplyAll(diff, Directory.GetCurrentDirectory());
        }

        public static XDocument ApplyAll(XDocument diff, string relativeDirectory)
        {
            XDocument document = null;
            string file = diff.Root.GetAttributeSafe("file");
            if (file == null) { return document; }
            file = DiffUtils.RelativeToAbsoluteFilepath(file, relativeDirectory);
            document = XDocument.Load(file);
            document = ApplyAll(diff, document);
            return document;
        }

        private static XDocument ApplyAll(XDocument diff, XDocument document)
        {
            DiffUtils.CleanHeader(diff, document, out bool OverrideRoot);

            foreach (XElement patch in diff.Root.Elements())
            {
                document = Apply(patch, document);
            }
            diff.Root.ParseBoolAttribute("cleanup", out bool cleanup);
            if (cleanup)
            {
                HashSet<string> OverrideXpaths = XMLUtils.GetFilteredXPaths(diff, document, (patch, elt) => patch.ParseBoolAttribute("override"));
                HashSet<string> SaveXpaths = XMLUtils.GetFilteredXPaths(diff, document, (patch, elt) => !patch.ParseBoolAttribute("override"));
                foreach (XElement element in document.Root.Elements().Reverse())
                {
                    string xpath = element.GetAbsoluteXPath();
                    if (OverrideXpaths.Contains(xpath))
                    {
                        ConstructOverride.Override(element);
                    }
                    else if (!SaveXpaths.Contains(xpath))
                    {
                        element.Remove();
                    }
                }
            }
            if (OverrideRoot)
            {
                document = ConstructOverride.OverrideRoot(document);
            }
            return document;
        }

        private static XDocument Apply(XElement patch, XDocument document)
        {
            switch (patch.Name.LocalName)
            {
                case "add":
                    document = PatchOperationAdd.Apply(patch, document);
                    break;
                case "remove":
                    document = PatchOperationRemove.Apply(patch, document);
                    break;
                case "replace":
                    document = PatchOperationEdit.Apply(patch, document);
                    break;
            }
            return document;
        }
    }
}
