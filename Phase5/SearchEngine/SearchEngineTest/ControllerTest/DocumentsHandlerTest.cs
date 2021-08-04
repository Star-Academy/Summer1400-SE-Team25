using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NSubstitute;
using SearchEngine.Model;
using SearchEngine.Controller;

namespace SearchEngineTest.ControllerTest
{
    public class DocumentsHandlerTest
    {
        private IInvertedIndex _index;
        private IDocumentParser _parser;
        private List<IDocument> _documents;

        private void SetUp()
        {
            var document1 = Substitute.For<IDocument>();
            
            _index = Substitute.For<IInvertedIndex>();
            _parser = Substitute.For<IDocumentParser>();
            _documents = new List<IDocument>()
            {
                document1
            };
        }

        [Fact]
        public void TestHandler()
        {
            var documentsHandler = new DocumentsHandler();

            documentsHandler.AddDocumentsToIndex(_index, _documents);

            _parser.Received().AddDocumentWordsToInvertedIndex(_index, _documents[0]);
        }
    }
}
