using SearchEngine.Model;

namespace SearchEngine.Controller
{
    public interface IDirectoryMapper
    {
        public Document GetDocumentByDirectory(string directory);
    }
}