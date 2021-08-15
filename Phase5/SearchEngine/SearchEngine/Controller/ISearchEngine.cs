using SearchLib.Model;
using System.Collections.Generic;

namespace SearchLib.Controller
{
    public interface ISearchEngine
    {
        void AddDirPath(string dirPath);

        List<IDocument> Search(string searchQuery);
    }
}