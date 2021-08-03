using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Model
{
    public interface IDocumentMapper
    {
        void AddDocumentWordsToIndex(IInvertedIndex index);
    }
}
