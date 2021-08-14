using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Model.Entities
{
    public class WordDocument
    {
        public int WordId { get; set; }
        public Word Word { get; set; }

        public int DocumentId { get; set; }
        public Document Document { get; set; }

        public WordDocument(Word word, Document document)
        {
            Word = word;
            WordId = word.Id;

            Document = document;
            DocumentId = document.Id;
        }

        public WordDocument()
        {
        }
    }
}
