using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Model
{
    public interface IDocumentMapper
    {
        void AddDocumentWordsToInvertedIndex(IInvertedIndex invertedIndex, IDocument document);
    }
}
