using System.Collections.Generic;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller
{
    public interface IDirectoryMapper
    {
        public List<IDocument> ExtractDocuments(string directorName);
    }
}