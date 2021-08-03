using System;

namespace SearchEngine.Model
{
    public class Document : IDocument
    {
        private string _documentPath;
        public string Name { get; set; }

        public Document(string documentPath)
        {
            _documentPath = documentPath;
        }

        public string GetDocumentPreview()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
