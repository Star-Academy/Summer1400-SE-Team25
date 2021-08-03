using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Model
{
    public class DocumentMapper : IDocumentMapper
    {
        private readonly IDocument _document;

        public DocumentMapper(IDocument document)
        {
            this._document = document;
        }

        public void AddDocumentWordsToIndex(IInvertedIndex index)
        {
            throw new NotImplementedException();
        }
    }
}
