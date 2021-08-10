using System.Collections.Generic;
using System.IO;
using SearchEngine.Model;

namespace SearchLib.Controller
{
    public class DirectoryMapper
    {
        public List<Document> ExtractDocuments(string directorName)
        {
            var fileNames = Directory.GetFiles(directorName);
            var currentDirectoryDocuments = new List<Document>();
            foreach (var fileName in fileNames)
            {
                var document = new Document(fileName);
                if (!IsHiddenFile(document)) // do not add hidden files
                    currentDirectoryDocuments.Add(document);
            }
            return currentDirectoryDocuments;
            
        }

        private bool IsHiddenFile(Document document)
        {
            return document.Name[0] == '.';
        }
    }
}