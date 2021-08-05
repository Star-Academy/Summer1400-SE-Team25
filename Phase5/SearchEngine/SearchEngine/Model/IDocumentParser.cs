using System;
using System.Collections.Generic;
using System.Text;

namespace SearchLib.Model
{
    public interface IDocumentParser
    {
        void AddDocumentWordsToInvertedIndex(IInvertedIndex invertedIndex, IDocument document);
    }
}
