using System;

namespace SearchEngine.Model
{
    public interface IDocument
    {
        public string Name { get; set; }

        public string GetDocumentPreview();

        public string ToString();
    }
}