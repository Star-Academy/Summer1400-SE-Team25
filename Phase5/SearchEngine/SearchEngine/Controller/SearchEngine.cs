using SearchLib.Model;
using System.Collections.Generic;

namespace SearchLib.Controller
{
    public class SearchEngine : ISearchEngine
    {
        private IInvertedIndex _index;
        private List<IDocument> _documentsList;

        public void AddDirPath(string dirPath)
        {
            throw new System.NotImplementedException();
        }

        public List<IDocument> Search(string searchQuery)
        {
            throw new System.NotImplementedException();
        }
    }
}