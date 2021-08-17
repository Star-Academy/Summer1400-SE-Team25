using System;
using System.IO;
using SearchEngine.Services.DataBase;
using SearchEngine.Model.Entities;

namespace SearchEngine.Services
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
                if (IsFileHidden(file))
                    continue;

                var newDocument = new Document(file);
                if (_dbHandler.DBContains(newDocument))
                    continue;
                _dbHandler.AddDocumentToDb(newDocument);
                newDocument = _dbHandler.GetDocumentByPath(file);
                _documentParser.AddDocumentWordsToDb(_dbHandler, newDocument);
            }

        }

        private bool IsFileHidden(string filePath)
        {
            return Path.GetFileName(filePath)[0] == '.';
        }
    }
}