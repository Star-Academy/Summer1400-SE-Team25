using System.Collections.Generic;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller
{
    public interface IDirectoryHandler
    {
        public void ExtractDocuments(string directoryName);
    }
}