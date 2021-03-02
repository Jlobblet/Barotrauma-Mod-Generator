using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Barotrauma_Mod_Generator.Util
{
    public static class XmlUtils
    {
        public static XElement GetSecondLevelAncestor(this XElement element)
        {
            IEnumerable<XElement> ancestors = element.Ancestors().Prepend(element);
            // Handle root behaviour
            IEnumerable<XElement> elements = ancestors.ToList();
            return elements.Count() == 1 ? element : elements.ElementAt(elements.Count() - 2);
        }

        private static int IndexPosition(this XElement element)
        {
            if (element == null) throw new ArgumentException();

            if (element.Parent == null) return -1;

            var index = 1;
            foreach (XElement sibling in element.Parent.Elements(element.Name))
            {
                if (sibling == element) return index;
                index++;
            }

            throw new InvalidOperationException("Element could not be found");
        }

        private static string GetRelativeXPath(XElement element)
        {
            int index = element.IndexPosition();
            string name = element.Name.LocalName;

            return index == -1 ? $"/{name}" : $"/{name}[{index}]";
        }

        public static string GetAbsoluteXPath(this XElement element)
        {
            if (element == null) throw new ArgumentException();

            IEnumerable<string> ancestors = element.Ancestors().Select(GetRelativeXPath);
            return string.Concat(ancestors.Reverse().ToArray()) + GetRelativeXPath(element);
        }

        public static string GetAttributeSafe(this XElement element, string attribute)
        {
            // ReSharper disable once PossibleNullReferenceException
            return element.Attribute(attribute)?.Value;
        }

        public static string GetAttributeSafe(this XElement element, string attribute, out string value)
        {
            if (element.Attribute(attribute) == null) return value = element.GetAttributeSafe(attribute);
            return value = element.GetAttributeSafe(attribute);
        }

        public static bool ParseBoolAttribute(this XElement element, string attribute)
        {
            if (element.Attribute(attribute) == null) return false;
            bool.TryParse(element.GetAttributeSafe(attribute), out bool output);
            return output;
        }

        public static bool ParseBoolAttribute(this XElement element, string attribute, out bool value)
        {
            if (element.Attribute(attribute) == null) return value = false;
            return bool.TryParse(element.GetAttributeSafe(attribute), out value);
        }

        private static XElement GetElement(this XObject @object)
        {
            XElement elt = @object switch
                           {
                               XAttribute attribute => attribute.Parent,
                               XElement element => element,
                               _ => null
                           };
            return elt;
        }

        public static HashSet<string> GetFilteredXPaths(XDocument diff, XDocument document,
                                                        Func<XElement, XElement, bool> filter = null)
        {
            var filteredXPaths = new HashSet<string>();
            foreach (XElement patch in diff.Root?.Elements())
            {
                string xpath = patch.GetAttributeSafe("sel");
                if (xpath == null) continue;
                foreach (XObject obj in (IEnumerable) document.Root.XPathEvaluate(xpath))
                {
                    XElement elt = obj.GetElement();
                    if (filter == null || filter(patch, elt))
                        filteredXPaths.Add(elt.GetSecondLevelAncestor().GetAbsoluteXPath());
                }
            }

            return filteredXPaths;
        }
    }
}
