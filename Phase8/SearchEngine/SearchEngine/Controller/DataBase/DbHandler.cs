using System.Collections.Generic;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller.DataBase
{
    public class DbHandler : IDbHandler
    {
        private readonly Dictionary<string, List<IDocument>> _index;

        public DbHandler()
        {
            _index = new Dictionary<string, List<IDocument>>();
        }

        public Document GetDocumentByDirectory(string documentDirectory)
        {
            throw new System.NotImplementedException();
        }

        public Word GetWordByText(string wordText)
        {
            throw new System.NotImplementedException();
        }

        public void AddWordOccurrence(IWord occurredWord, IDocument document)
        {
            throw new System.NotImplementedException();
        }

        public List<IDocument> GetWordOccurrences(string word)
        {
            throw new System.NotImplementedException();
        }
    }
}
