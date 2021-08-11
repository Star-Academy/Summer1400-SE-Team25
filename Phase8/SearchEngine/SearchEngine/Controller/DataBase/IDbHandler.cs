using System.Collections.Generic;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller.DataBase
{
    public interface IDbHandler
    {
        Document GetDocumentByPath(string documentPath);

        void AddDocumentToDb(Document document);

        bool DBContains(Document document);

        Word GetWordByText(string wordText);

        void AddWordToDb(Word word);

        void AddWordOccurrence(Word occurredWord, Document document);

        public bool DBContains(Word word);

        List<Document> GetWordOccurrences(string word);
    }
}
