using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Model
{
    public class InvertedIndex : IInvertedIndex
    {
        private Dictionary<string, List<IDocument>> _index;

        public InvertedIndex()
        {
            this._index = new Dictionary<string, List<IDocument>>();
        }

        public void AddWordOccurrence(string occurredWord, IDocument document)
        {
            if (_index.ContainsKey(occurredWord))
                _index[occurredWord].Add(document);
            else
                _index[occurredWord] = new List<IDocument> { document };
        }

        public List<IDocument> GetWordOccurrence(string word)
        {
            List<IDocument> result;
            _index.TryGetValue(word, out result);
            return result;
        }
    }
}
