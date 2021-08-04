using System;
using System.Collections.Generic;
using System.Text;
using SearchEngine.Model;

namespace SearchEngine.Controller
{
    public interface IDocumentsHandler
    {
        void AddDocumentsToIndex(IInvertedIndex index, List<IDocument> documentsList);
    }
}
