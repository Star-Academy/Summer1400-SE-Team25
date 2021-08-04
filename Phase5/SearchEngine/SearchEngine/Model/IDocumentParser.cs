using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Model
{
    public interface IDocumentParser
    {
        void AddDocumentWordsToInvertedIndex(IInvertedIndex invertedIndex, IDocument document);
    }
}
