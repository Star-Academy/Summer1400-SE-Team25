using System.Collections.Generic;

namespace SearchEngine.Model.Entities
{
    public interface IDocument
    {
        public int Id { get; set; }
        string Name { get; set; }
        string DocumentPath { get; }
        public List<WordDocument> WordDocuments { get; set; }

        string GetDocumentPreview();

        string ToString();
    }
}