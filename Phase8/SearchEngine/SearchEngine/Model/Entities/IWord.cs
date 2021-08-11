using System.Collections.Generic;

namespace SearchEngine.Model.Entities
{
    public interface IWord
    {
        public string WordText { get; set; }
        public List<Document> OccurredDocuments { get; }
    }
}