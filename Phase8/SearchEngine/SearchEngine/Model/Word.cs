using System.Collections.Generic;

namespace SearchEngine.Model
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