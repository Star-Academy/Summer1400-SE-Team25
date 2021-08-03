using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SearchEngine.Model
{
    public class DocumentMapper : IDocumentMapper
    {
        public void AddDocumentWordsToIndex(IInvertedIndex index, IDocument document)
        {
            StreamReader file = new StreamReader(document.DocumentPath);
            while (!file.EndOfStream)
            {
                index.AddWordOccurrence(ReadWord(file), document);
            }
            file.Close();
        }

        private string ReadWord(StreamReader inputStream)
        {
            StringBuilder result = new StringBuilder();
            char c = (char)inputStream.Read();
            while (c != ' ' && !inputStream.EndOfStream)
            {
                result.Append(c);
                c = (char)inputStream.Read();
            }
            return result.ToString();
        }
    }
}
