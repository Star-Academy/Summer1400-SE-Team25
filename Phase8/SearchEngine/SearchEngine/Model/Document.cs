using System.IO;

namespace SearchEngine.Model
{
    public class Document
    {
        private readonly string _documentDirectory;
        public string Name { get; set; }

        public Document(string documentDirectory)
        {
            _documentDirectory = documentDirectory;
            Name = Path.GetFileName(documentDirectory);
        }
    }
}