using System.Collections.Generic;
using SearchEngine.Model;

namespace SearchEngine.Controller
{
    public interface IDirectoryMapper
    {
        public List<IDocument> ExtractDocuments(string directorName);
    }
}