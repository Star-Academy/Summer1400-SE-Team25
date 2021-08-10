using System.Collections.Generic;
using SearchEngine.Controller.DataBase;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller
{
    public class SearchEngine : ISearchEngine
    {
        private IDbHandler _index;
        private List<IDocument> _documentsList;
        private Context _context;

        public SearchEngine()
        {
            _index = new DbHandler();
            _documentsList = new List<IDocument>();
            _context = new Context();
        }

        public void AddDirPath(string dirPath)
        {
            throw new System.NotImplementedException();
        }

        public List<IDocument> Search(string searchQuery)
        {
            var queryHandler = new QueryHandler(searchQuery);
            return queryHandler.OperateOnQuery(_index);
        }
    }
}