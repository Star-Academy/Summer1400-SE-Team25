using System;
using System.IO;
using System.Linq;

namespace SearchEngine.Model
{
    public class Document : IDocument
    {
        private const int DocumentPreviewCharacterCount = 27;
        private const string DocumentPreviewEndingString = "...";
        private readonly string _documentPath;
        public string DocumentPath
        {
            get { return _documentPath; }
        }

        public string Name { get; set; }

        public Document(string documentPath)
        {
            _documentPath = documentPath;
            Name = Path.GetFileName(documentPath);
        }

        public string GetDocumentPreview()
        {
            var documentLines = File.ReadLines(_documentPath);
            var firstLine = documentLines.First();
            return firstLine[..Math.Min(firstLine.Length, DocumentPreviewCharacterCount)] + DocumentPreviewEndingString;
        }

        public override string ToString()
        {
            return Name + ": \n" +
                   "\t" + GetDocumentPreview();
        }
    }
}
