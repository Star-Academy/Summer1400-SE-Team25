using SearchEngine.Services.DataBase;
using SearchEngine.Model.Entities;

namespace SearchEngine.Services
{
    public interface IDocumentParser
    {
        void AddDocumentWordsToDb(IDbHandler dbHandler, Document document);
    }
}
