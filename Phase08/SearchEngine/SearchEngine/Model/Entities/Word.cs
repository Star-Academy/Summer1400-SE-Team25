using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SearchEngine.Model.Entities
{
    public class Word
    {
        public int Id { get; set; }
        public string WordText { get; set; }
        public ICollection<WordDocument> WordDocuments { get; set; }

        public Word(string wordText)
        {
            WordText = wordText;
            WordDocuments = new List<WordDocument>();
        }
    }
}