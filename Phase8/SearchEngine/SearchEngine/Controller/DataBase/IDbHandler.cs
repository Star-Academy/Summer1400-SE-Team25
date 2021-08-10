using System.Collections.Generic;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller.DataBase
{
    public interface IDbHandler
    {
        Document GetDocumentByDirectory(string documentDirectory);

        Word GetWordByText(string wordText);

        void AddWordOccurrence(IWord occurredWord, IDocument document);

        List<IDocument> GetWordOccurrences(string word);
    }
}
