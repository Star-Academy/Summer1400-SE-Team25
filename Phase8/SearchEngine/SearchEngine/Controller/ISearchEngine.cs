using System.Collections.Generic;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller
{
    public interface ISearchEngine
    {
        void AddDirPath(string dirPath);

        List<Document> Search(string searchQuery);
    }
}