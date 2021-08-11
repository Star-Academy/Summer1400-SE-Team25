using System.IO;
using SearchEngine.Controller.DataBase;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller
{
    public class DirectoryHandler : IDirectoryHandler
    {
        private readonly IDbHandler _dbHandler;
        private readonly IDocumentParser _documentParser;

        public DirectoryHandler(IDbHandler dbHandler, IDocumentParser documentParser)
        {
            _dbHandler = dbHandler;
            _documentParser = documentParser;
        }

        public void ExtractDocuments(string directoryName)
        {
            var directoryFiles = Directory.GetFiles(directoryName);
            foreach (var file in directoryFiles)
            {
                var newDocument = new Document(file);

                if (!_dbHandler.DBContains(newDocument))
                    _dbHandler.AddDocumentToDb(newDocument);

                _documentParser.AddDocumentWordsToDb(_dbHandler, newDocument);
            }

        }
    }
}