using System;
using System.IO;
using System.Linq;

namespace SearchLib.Model
{
    public class Document : IDocument
    {
        private readonly int DocumentPreviewCharacterCount = 27;
        private readonly string DocumentPreviewEndingString = "...";
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

        public override bool Equals(object? obj)
        {
            if (!(obj is IDocument document))
                return false;
            return DocumentPath.Equals(document.DocumentPath);
        }

        public override int GetHashCode()
        {
            return DocumentPath.GetHashCode();
        }
    }
}
