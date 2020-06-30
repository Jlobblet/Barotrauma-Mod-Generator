using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Barotrauma_Mod_Generator.XmlUtils
{
    public static class XMLUtils
    {
        public static XElement GetSecondLevelAncestor(this XElement element)
        {
            IEnumerable<XElement> ancestors = element.Ancestors().Prepend(element);
            // Handle root behaviour
            if (ancestors.Count() == 1)
            {
                return element;
            }
            else
            {
                return ancestors.ElementAt(ancestors.Count() - 2);
            }
        }

        public static int IndexPosition(this XElement element)
        {
            if (element == null)
            {
                throw new ArgumentException();
            }

            if (element.Parent == null)
            {
                return -1;
            }

            int index = 1;
            foreach (XElement sibling in element.Parent.Elements(element.Name))
            {
                if (sibling == element)
                {
                    return index;
                }
                index++;
            }
            throw new InvalidOperationException("Element could not be found");
        }

        public static string GetRelativeXPath(XElement element)
        {
            int index = element.IndexPosition();
            string name = element.Name.LocalName;

            if (index == -1)
            {
                return string.Format("/{0}", name);
            }
            else
            {
                return string.Format("/{0}[{1}]", name, index.ToString());
            }
        }

        public static string GetAbsoluteXPath(this XElement element)
        {
            if (element == null)
            {
                throw new ArgumentException();
            }

            IEnumerable<string> ancestors = element.Ancestors().Select(GetRelativeXPath);
            return string.Concat(ancestors.Reverse().ToArray()) + GetRelativeXPath(element);
        }

        public static string GetAttributeSafe(this XElement element, string attribute)
        {
            if (element.Attribute(attribute) == null)
            {
                return null;
            }
            return element.Attribute(attribute).Value;
        }

        public static string GetAttributeSafe(this XElement element, string attribute, out string value)
        {
            if (element.Attribute(attribute) == null)
            {
                return value = element.GetAttributeSafe(attribute);
            }
            return value = element.GetAttributeSafe(attribute);
        }

        public static bool ParseBoolAttribute(this XElement element, string attribute)
        {
            if (element.Attribute(attribute) == null)
            {
                return false;
            }
            bool.TryParse(element.GetAttributeSafe(attribute), out bool output);
            return output;
        }

        public static bool ParseBoolAttribute(this XElement element, string attribute, out bool value)
        {
            if (element.Attribute(attribute) == null)
            {
                return value = false;
            }
            return bool.TryParse(element.GetAttributeSafe(attribute), out value);
        }

        public static XElement GetElement(this XObject @object)
        {
            XElement elt = null;
            if (@object is XAttribute attribute)
            {
                elt = attribute.Parent;
            }
            else if (@object is XElement element)
            {
                elt = element;
            }
            return elt;
        }
        public static HashSet<string> GetFilteredXPaths(XDocument diff, XDocument document, Func<XElement, XElement, bool> filter = null)
        {
            HashSet<string> FilteredXPaths = new HashSet<string>();
            foreach (XElement patch in diff.Root.Elements())
            {
                string xpath = patch.GetAttributeSafe("sel");
                if (xpath == null) { continue; }
                foreach (XObject obj in (IEnumerable)document.Root.XPathEvaluate(xpath))
                {
                    XElement elt = obj.GetElement();
                    if (filter == null || filter(patch, elt))
                    {
                        FilteredXPaths.Add(elt.GetSecondLevelAncestor().GetAbsoluteXPath());
                    }
                }
            }
            return FilteredXPaths;
        }
    }
}
