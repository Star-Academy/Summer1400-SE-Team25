using System.Collections;
using System.Collections.Generic;

namespace SearchEngine
{
    public class Word
    {
        public readonly IList<Document> OccurredDocuments;

        public Word()
        {
            OccurredDocuments = new List<Document>();
        }
    }
}