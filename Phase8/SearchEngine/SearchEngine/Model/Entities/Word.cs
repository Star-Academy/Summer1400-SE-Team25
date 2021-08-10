using System.Collections.Generic;

namespace SearchEngine.Model.Entities
{
    public class Word : IWord
    {
        public int WordId { get; set; }
        public string WordText { get; set; }
        public IList<IDocument> OccurredDocuments { get; }

        public Word(string wordText)
        {
            WordText = wordText;
        }
    }
}