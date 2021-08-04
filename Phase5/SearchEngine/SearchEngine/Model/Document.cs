using System;
using System.IO;
using System.Linq;

namespace SearchEngine.Model
{
    public class Document : IDocument
    {
        private const int DocumentPreviewCharacterCount = 27;
        private const string DocumentPreviewEndingString = "...";
        public string DocumentPath { get; }
        public string Name { get; set; }

        public Document(string documentPath)
        {
            DocumentPath = documentPath;
            Name = Path.GetFileName(documentPath);
        }

        public string GetDocumentPreview()
        {
            var documentLines = File.ReadLines(DocumentPath);
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
