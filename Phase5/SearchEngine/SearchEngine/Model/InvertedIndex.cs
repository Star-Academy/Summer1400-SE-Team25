using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Model
{
    public class InvertedIndex : IInvertedIndex
    {
        private Dictionary<string, List<IDocument>> index;

        public InvertedIndex()
        {
            this.index = new Dictionary<string, List<IDocument>>();
        }

        public void AddWordOccurrence(string occurredWord, IDocument document)
        {
            if (index.ContainsKey(occurredWord))
                index[occurredWord].Add(document);
            else
                index[occurredWord] = new List<IDocument> { document };
        }

        public List<IDocument> GetWordOccurrence(string word)
        {
            List<IDocument> result;
            index.TryGetValue(word, out result);
            return result;
        }
    }
}
