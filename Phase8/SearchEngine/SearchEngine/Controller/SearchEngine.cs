using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SearchEngine.Controller.DataBase;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller
{
    public class SearchEngine : ISearchEngine
    {
        private readonly IDbHandler _dbHandler;
        private readonly IDirectoryHandler _directoryHandler;

        public SearchEngine(IDbHandler dbHandler)
        {
            _dbHandler = dbHandler;
            _directoryHandler = new DirectoryHandler(_dbHandler, new DocumentParser());
        }

        public void AddDirPath(string directoryPath)
        {
            _directoryHandler.ExtractDocuments(directoryPath);
        }

        public List<IDocument> Search(string searchQuery)
        {
            var queryHandler = new QueryHandler(searchQuery);
            return queryHandler.OperateOnQuery(_dbHandler);
        }
    }
}