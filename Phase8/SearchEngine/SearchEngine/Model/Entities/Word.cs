using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SearchEngine.Model.Entities
{
    public class Word : IWord
    {
        public string WordText { get; set; }
        public List<Document> OccurredDocuments { get; set; }

        public Word(string wordText)
        {
            WordText = wordText;
            OccurredDocuments = new List<Document>();
        }
    }
}