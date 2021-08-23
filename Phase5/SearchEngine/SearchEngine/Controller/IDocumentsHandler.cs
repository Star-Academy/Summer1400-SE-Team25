using System;
using System.Collections.Generic;
using System.Text;
using SearchLib.Model;

namespace SearchLib.Controller
{
    public interface IDocumentsHandler
    {
        void AddDocumentsToIndex(IInvertedIndex index, List<IDocument> documentsList);
    }
}
