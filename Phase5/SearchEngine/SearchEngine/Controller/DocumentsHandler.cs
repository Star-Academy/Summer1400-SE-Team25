using System;
using System.Collections.Generic;
using System.Text;
using SearchEngine.Model;

namespace SearchEngine.Controller
{
    public class DocumentsHandler : IDocumentsHandler
    {
        private IDocumentParser _parser;

        public DocumentsHandler(IDocumentParser parser)
        {
            this._parser = parser;
        }

        public void AddDocumentsToIndex(IInvertedIndex index, List<IDocument> documentsList)
        {
            foreach (IDocument document in documentsList)
                _parser.AddDocumentWordsToInvertedIndex(index, document);
        }
    }
}
