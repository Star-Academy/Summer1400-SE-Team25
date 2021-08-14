using System.Collections.Generic;

namespace SearchEngine.Model.Entities
{
    public interface IWord
    {
        public int Id { get; set; }
        public string WordText { get; set; }
        public List<WordDocument> WordDocuments { get; }
    }
}