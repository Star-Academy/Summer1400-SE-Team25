using System.Collections.Generic;
using System.IO;
using SearchLib.Model;
using System.Linq;

namespace SearchLib.Controller
{
    public class DirectoryMapper : IDirectoryMapper
    {
        public List<Document> ExtractDocuments(string directorName)
        {
            string[] fileNames = Directory.GetFiles(directorName);
            var currentDirectoryDocuments = new List<Document>();
            foreach (string fileName in fileNames)
            {
                var document = new Document(fileName);
                currentDirectoryDocuments.Add(document);
            }
            return currentDirectoryDocuments;
            
        }
    }
}