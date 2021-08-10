using System.Collections.Generic;
using SearchEngine.Model;

namespace SearchEngine.Controller
{
    public interface ISearchEngine
    {
        void AddDirPath(string dirPath);

        List<IDocument> Search(string searchQuery);
    }
}