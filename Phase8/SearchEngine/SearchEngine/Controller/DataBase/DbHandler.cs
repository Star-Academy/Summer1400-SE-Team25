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

        public Document GetDocumentByDirectory(string documentDirectory)
        {
            var resultSet = _context.Documents.Where(document => document.DocumentPath.Equals(documentDirectory)).ToList();
            if (resultSet.Count > 0)
                return resultSet[0];
            var newDocument = new Document(documentDirectory);
            AddDocumentToDb(newDocument);
            return newDocument;
        }

        private void AddDocumentToDb(IDocument document)
        {
            _context.Add(document);
        }

        public Word GetWordByText(string wordText)
        {
            var resultSet = _context.Words.Where(word => word.WordText.Equals(wordText)).ToList();
            if (resultSet.Count > 0)
                return resultSet[0];
            var newWord = new Word(wordText);
            AddWordToDb(newWord);
            return newWord;
        }

        private void AddWordToDb(IWord word)
        {
            _context.Add(word);
        }

        public void AddWordOccurrence(IWord occurredWord, IDocument document)
        {
            occurredWord.OccurredDocuments.Add(document);
            _context.SaveChanges();
        }

        public List<IDocument> GetWordOccurrences(string wordText)
        {
            return _context.Words
                .Where(word => word.WordText.Equals(wordText))
                .Select(word => word.OccurredDocuments).ToList().First().ToList();

        }
    }
}
