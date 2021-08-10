namespace SearchEngine.Model.Entities
{
    public interface IDocument
    {

        string DocumentPath { get; }
        string Name { get; set; }

        string GetDocumentPreview();

        string ToString();
    }
}