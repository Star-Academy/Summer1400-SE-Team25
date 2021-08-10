using System.Collections.Generic;

namespace SearchEngine.Model
{
    public interface IInvertedIndex
    {
        void AddWordOccurrence(string occurredWord, IDocument document);

        List<IDocument> GetWordOccurrence(string word);
    }
}
