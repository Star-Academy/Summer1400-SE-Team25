using System.Collections.Generic;

namespace SearchEngine.Model.Entities
{
    public interface IWord
    {
        public int WordId { get; set; }
        public string WordText { get; set; }
        public IList<IDocument> OccurredDocuments { get; }
    }
}