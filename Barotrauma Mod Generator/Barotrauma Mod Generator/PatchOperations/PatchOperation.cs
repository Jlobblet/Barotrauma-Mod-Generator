using System;
using System.Xml.Linq;

namespace Barotrauma_Mod_Generator.PatchOperations
{
    public abstract class PatchOperation : IDisposable
    {
        protected readonly XDocument Document;
        protected readonly XElement Patch;

        protected PatchOperation(XElement patch, XDocument document)
        {
            Patch = patch;
            Document = document;
        }

        public void Dispose()
        {
        }

        public abstract XDocument Apply();
    }
}
