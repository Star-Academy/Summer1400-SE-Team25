using System.Collections.Generic;
using System.IO;
using SearchEngine.Model;

namespace SearchEngine.Controller
{
    public class DirectoryMapper : IDirectoryMapper
    {
        private IDictionary<string, Document> _directoryMapper;

        public DirectoryMapper()
        {
            _directoryMapper = new Dictionary<string, Document>();
        }

        public Document GetDocumentByDirectory(string documentDirectory)
        {
            if (!File.Exists(documentDirectory))
                return null;
            if (!_directoryMapper.ContainsKey(documentDirectory))
                _directoryMapper.Add(documentDirectory, new Document(documentDirectory));
            return _directoryMapper[documentDirectory];
        }
    }
}