namespace SearchEngine.Model
{
    public class Document
    {
        private readonly string _documentDirectory;
        public string FileName { get; set; }

        public Document(string documentDirectory, string fileName)
        {
            _documentDirectory = documentDirectory;
            FileName = fileName;
        }
    }
}