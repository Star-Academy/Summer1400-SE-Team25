using System;
using System.IO;
using SearchEngine.Services.DataBase;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchEngine.Services
{
    public class DocumentParser : IDocumentParser
    {
        public void AddDocumentWordsToDb(IDbHandler dbHandler, Document document)
        {
            using var fileReader = new StreamReader(document.DocumentPath);
            while (!fileReader.EndOfStream)
            {
                var wordsText = fileReader.ReadLine()?.Split();
                if (wordsText == null) continue;
                foreach (var wordText in wordsText)
                {
                    var newWord = new Word(wordText);
                    if (!dbHandler.DBContains(newWord))
                        dbHandler.AddWordToDb(newWord);
                    newWord = dbHandler.GetWordByText(wordText);
                    if (!dbHandler.DBContains(newWord, document))
                        dbHandler.AddWordOccurrence(newWord, document);
                }
            }
        }
    }
}
