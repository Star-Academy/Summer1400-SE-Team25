using System.Collections.Generic;

namespace SearchEngine.Model.Entities
{
    public class Word
    {
        public IList<IDocument> OccurredDocuments { get; }

        public Word()
        {
            OccurredDocuments = new List<IDocument>();
        }
    }
}