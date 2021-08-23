using System;
using System.Collections.Generic;
using System.Text;

namespace SearchLib.Model
{
    public class InvertedIndex : IInvertedIndex
    {
        private readonly Dictionary<string, List<IDocument>> _index;

        public InvertedIndex()
        {
            this._index = new Dictionary<string, List<IDocument>>();
        }

        public void AddWordOccurrence(string occurredWord, IDocument document)
        {
            if (!_index.ContainsKey(occurredWord))
                _index[occurredWord] = new List<IDocument>();
            if (!_index[occurredWord].Contains(document))
                _index[occurredWord].Add(document);
        }

        public List<IDocument> GetWordOccurrence(string word)
        {
            List<IDocument> result;
            _index.TryGetValue(word, out result);
            return result ?? new List<IDocument>();
        }
    }
}
