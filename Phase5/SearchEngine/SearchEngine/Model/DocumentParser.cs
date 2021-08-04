using System.IO;

namespace SearchEngine.Model
{
    public class DocumentParser : IDocumentParser
    {
        public void AddDocumentWordsToInvertedIndex(IInvertedIndex invertedIndex, IDocument document)
        {
            using var fileReader = new StreamReader(document.DocumentPath);
            while (!fileReader.EndOfStream)
            {
                var words = fileReader.ReadLine()?.Split();
                if (words == null) continue;
                foreach (var word in words)
                    invertedIndex.AddWordOccurrence(word, document);
            }
        }
    }
}
