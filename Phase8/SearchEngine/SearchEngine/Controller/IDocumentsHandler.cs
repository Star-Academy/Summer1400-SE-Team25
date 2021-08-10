using System.Collections.Generic;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller
{
    public interface IDocumentsHandler
    {
        void AddDocumentsToIndex(IInvertedIndex index, List<IDocument> documentsList);
    }
}
