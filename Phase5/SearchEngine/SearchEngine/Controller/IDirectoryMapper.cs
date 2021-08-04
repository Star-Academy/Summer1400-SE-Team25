using SearchEngine.Model;
using System.Collections.Generic;

namespace SearchEngine.Controller
{
    public interface IDirectoryMapper
    {
        public List<Document> ExtractDocuments(string directorName);

        public List<Document> GetDocumentsList();
    }
}