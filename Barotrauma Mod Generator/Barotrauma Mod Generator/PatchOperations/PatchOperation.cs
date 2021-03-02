using System;
using System.Xml.Linq;

namespace Barotrauma_Mod_Generator.PatchOperations
{
    public abstract class PatchOperation: IDisposable
    {
        protected readonly XElement Patch;
        protected  readonly XDocument Document;

        protected PatchOperation(XElement patch, XDocument document)
        {
            Patch = patch;
            Document = document;
        }

        public abstract XDocument Apply();

        public void Dispose()
        {
        }
    }
}
