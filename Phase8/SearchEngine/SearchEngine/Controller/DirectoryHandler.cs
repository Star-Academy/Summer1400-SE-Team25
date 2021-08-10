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
            var fileDirectories = Directory.GetFiles(directoryName);
            foreach (var fileDirectory in fileDirectories)
            {
                var document = _dbHandler.GetDocumentByDirectory(fileDirectory);
                _documentParser.AddDocumentWordsToDb(_dbHandler, document);
            }
            
        }
    }
}