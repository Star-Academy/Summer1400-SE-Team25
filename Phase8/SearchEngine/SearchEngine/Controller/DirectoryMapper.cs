using System.Collections.Generic;
using System.IO;
using SearchEngine.Model;

namespace SearchEngine.Controller
{
    public class DirectoryMapper : IDirectoryMapper
    {
        public List<IDocument> ExtractDocuments(string directorName)
        {
            var fileNames = Directory.GetFiles(directorName);
            var currentDirectoryDocuments = new List<IDocument>();
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