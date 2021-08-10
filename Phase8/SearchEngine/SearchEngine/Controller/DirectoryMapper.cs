using System.Collections.Generic;
using System.IO;
using System.Linq;
using SearchEngine.Model;

namespace SearchEngine.Controller
{
    public class DirectoryMapper
    {
        public List<Document> ExtractDocuments(string directorName)
        {
            var fileNames = Directory.GetFiles(directorName);
            return fileNames.Select(fileName => new Document(fileName)).Where(document => !IsHiddenFile(document)).ToList();
            
        }

        private bool IsHiddenFile(Document document)
        {
            return document.Name[0] == '.';
        }
    }
}