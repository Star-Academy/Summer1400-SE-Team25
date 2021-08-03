using System.IO;

namespace SearchEngine.Model
{
    public class Document : IDocument
    {
        private string _documentPath;

        public Document(string documentPath)
        {
            _documentPath = documentPath;
        }

        public string GetDocumentName()
        {
            throw new System.NotImplementedException();
        }
    }
}
