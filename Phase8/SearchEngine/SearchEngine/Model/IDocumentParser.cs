using SearchEngine.Model.Entities;
using SearchLib.Model;

namespace SearchEngine.Model
{
    public interface IDocumentParser
    {
        void AddDocumentWordsToInvertedIndex(IInvertedIndex invertedIndex, IDocument document);
    }
}
