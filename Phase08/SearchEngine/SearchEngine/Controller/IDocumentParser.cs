using SearchEngine.Controller.DataBase;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller
{
    public interface IDocumentParser
    {
        void AddDocumentWordsToDb(IDbHandler dbHandler, Document document);
    }
}
