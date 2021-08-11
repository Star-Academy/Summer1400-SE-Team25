using System.Collections.Generic;
using System.Linq;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller.DataBase
{
    public class DbHandler : IDbHandler
    {
        private readonly Context _context;

        public DbHandler(Context context)
        {
            _context = context;
        }

        public Document GetDocumentByPath(string documentPath)
        {
            return _context.Documents.Find(documentPath);

        }

        public void AddDocumentToDb(Document document)
        {
            _context.Documents.Add(document);
            _context.SaveChanges();
        }

        public bool DBContains(Document document)
        {
            return _context.Documents.Any(d => d.DocumentPath == document.DocumentPath);
        }

        public Word GetWordByText(string wordText)
        {
            return _context.Words.Find(wordText);
        }

        public void AddWordToDb(Word word)
        {
            _context.Words.Add(word);
            _context.SaveChanges();
        }

        public bool DBContains(Word word)
        {
            return _context.Words.Any(w => w.WordText == word.WordText);
        }

        public void AddWordOccurrence(Word occurredWord, Document document)
        {
            occurredWord.OccurredDocuments.Add(document);
            _context.SaveChanges();
        }

        public List<Document> GetWordOccurrences(string wordText)
        {
            return _context.Words.Find(wordText).OccurredDocuments;

        }
    }
}
