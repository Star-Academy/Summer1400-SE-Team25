using System.IO;
using SearchEngine.Controller.DataBase;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller
{
    public class DocumentParser : IDocumentParser
    {
        public void AddDocumentWordsToDb(IDbHandler idbHandler, IDocument document)
        {
            using var fileReader = new StreamReader(document.DocumentPath);
            while (!fileReader.EndOfStream)
            {
                var wordsText = fileReader.ReadLine()?.Split();
                if (wordsText == null) continue;
                foreach (var wordText in wordsText)
                {
                    var wordObject = idbHandler.GetWordByText(wordText);
                    idbHandler.AddWordOccurrence(wordObject, document);
                }
            }
        }
    }
}
