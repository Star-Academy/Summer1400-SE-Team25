using System.Collections.Generic;
using System.IO;
using SearchEngine.Model;
using System.Linq;

namespace SearchEngine.Controller
{
    public class DirectoryMapper : IDirectoryMapper
    {
        private readonly IDictionary<string, Document> _documentsMap;

        public DirectoryMapper()
        {
            this._documentsMap = new Dictionary<string, Document>();
        }

        public List<Document> ExtractDocuments(string directorName)
        {
            string[] fileNames = Directory.GetFiles(directorName);
            var currentDirectoryDocuments = new List<Document>();
            foreach (string fileName in fileNames)
            {
                var document = new Document(fileName);
                _documentsMap[fileName] = document;
                currentDirectoryDocuments.Add(document);
            }
            return currentDirectoryDocuments;
            
        }

        public List<Document> GetDocumentsList()
        {
            return _documentsMap.Values.ToList();
        }
    }
}