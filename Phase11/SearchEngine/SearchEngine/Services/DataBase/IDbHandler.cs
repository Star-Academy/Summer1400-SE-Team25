using System.Collections.Generic;
using SearchEngine.Model.Entities;

namespace SearchEngine.Services.DataBase
{
    public interface IDbHandler
    {
        Document GetDocumentByPath(string documentPath);

        void AddDocumentToDb(Document document);

        bool DBContains(Document document);

        public bool DBContains(Word word);

        public bool DBContains(Word word, Document document);

        Word GetWordByText(string wordText);

        void AddWordToDb(Word word);

        void AddWordOccurrence(Word occurredWord, Document document);

        List<Document> GetWordOccurrences(string word);
    }
}
