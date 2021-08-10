using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SearchEngine.Model.Entities
{
    public class Word : IWord
    {
        [Key]
        public int WordId { get; set; }
        public string WordText { get; set; }
        public IList<IDocument> OccurredDocuments { get; }

        public Word(string wordText)
        {
            WordText = wordText;
            OccurredDocuments = new List<IDocument>();
        }
    }
}