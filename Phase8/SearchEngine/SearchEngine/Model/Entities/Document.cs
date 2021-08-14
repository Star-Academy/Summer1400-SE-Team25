using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace SearchEngine.Model.Entities
{
    public class Document : IDocument
    {
        private const int DocumentPreviewCharacterCount = 27;
        private const string DocumentPreviewEndingString = "...";

        public int Id { get; set; }
        public string Name { get; set; }
        public string DocumentPath { get; set; }
        public List<WordDocument> WordDocuments { get; set; }

        public Document()
        {
        }

        public Document(string documentPath)
        {
            DocumentPath = documentPath;
            Name = Path.GetFileName(documentPath);
            WordDocuments = new List<WordDocument>();
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

        public override bool Equals(object obj)
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
