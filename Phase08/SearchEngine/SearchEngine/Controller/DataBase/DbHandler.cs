using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return _context.Documents
                .Include(d => d.WordDocuments)
                .FirstOrDefault(d => d.DocumentPath == documentPath);

        }

        public Word GetWordByText(string wordText)
        {
            return _context.Words
                .Include(w => w.WordDocuments)
                .FirstOrDefault(w => w.WordText == wordText);
        }

        public bool DBContains(Document document)
        {
            return _context.Documents.Any(d => d.DocumentPath == document.DocumentPath);
        }

        public bool DBContains(Word word)
        {
            return _context.Words.Any(w => w.WordText == word.WordText);
        }

        public bool DBContains(Word word, Document document)
        {
            return _context.WordDocuments.Any(wd =>
                wd.DocumentId == document.Id &&
                wd.WordId == word.Id);
        }

        public void AddDocumentToDb(Document document)
        {
            _context.Add(document);
            _context.SaveChanges();
        }

        public void AddWordToDb(Word word)
        {
            _context.Add(word);
            _context.SaveChanges();
        }

        public void AddWordOccurrence(Word occurredWord, Document document)
        {
            var newWordDocument = new WordDocument(occurredWord, document);
            _context.Add(newWordDocument);
            occurredWord.WordDocuments.Add(newWordDocument);
            document.WordDocuments.Add(newWordDocument);
            _context.Update(occurredWord);
            _context.Update(document);
            _context.SaveChanges();
        }

        public List<Document> GetWordOccurrences(string wordText)
        {
            var foundWord = GetWordByText(wordText);
            if (foundWord == null)
                return new List<Document>();
            return (from wordDocument in _context.WordDocuments
                where wordDocument.WordId == foundWord.Id
                select wordDocument.Document).ToList();
        }
    }
}
