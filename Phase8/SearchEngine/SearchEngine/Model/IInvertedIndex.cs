using System.Collections.Generic;
using SearchEngine.Model.Entities;

namespace SearchEngine.Model
{
    public interface IInvertedIndex
    {
        void AddWordOccurrence(string occurredWord, IDocument document);

        List<IDocument> GetWordOccurrence(string word);
    }
}
