using System.Collections.Generic;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchEngine.Services
{
    public interface IDirectoryHandler
    {
        public void ExtractDocuments(string directoryName);
    }
}