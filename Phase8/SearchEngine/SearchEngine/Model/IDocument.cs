namespace SearchEngine.Model
{
    public interface IDocument
    {

        string DocumentPath { get; }
        string Name { get; set; }

        string GetDocumentPreview();

        string ToString();
    }
}