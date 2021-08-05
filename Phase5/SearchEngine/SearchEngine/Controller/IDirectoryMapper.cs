using SearchLib.Model;
using System.Collections.Generic;

namespace SearchLib.Controller
{
    public interface IDirectoryMapper
    {
        public List<Document> ExtractDocuments(string directorName);
    }
}