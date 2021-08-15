using System;
using System.Collections.Generic;
using System.Text;

namespace SearchLib.Model
{
    public interface IInvertedIndex
    {
        void AddWordOccurrence(string occurredWord, IDocument document);

        List<IDocument> GetWordOccurrence(string word);
    }
}
