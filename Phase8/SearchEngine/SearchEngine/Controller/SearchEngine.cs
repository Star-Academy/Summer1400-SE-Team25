using System.Collections.Generic;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller
{
    public class SearchEngine : ISearchEngine
    {
        private IInvertedIndex _index;
        private List<IDocument> _documentsList;

        public SearchEngine()
        {
            _index = new InvertedIndex();
            _documentsList = new List<IDocument>();
        }

        public void AddDirPath(string dirPath)
        {
            var dirMapper = new DirectoryMapper();
            var newDocuments = dirMapper.ExtractDocuments(dirPath);
            var documentsHandler = new DocumentsHandler(new DocumentParser());
            documentsHandler.AddDocumentsToIndex(_index, newDocuments);
            _documentsList.AddRange(newDocuments);
        }

        public List<IDocument> Search(string searchQuery)
        {
            var queryHandler = new QueryHandler(searchQuery);
            return queryHandler.OperateOnQuery(_index);
        }
    }
}