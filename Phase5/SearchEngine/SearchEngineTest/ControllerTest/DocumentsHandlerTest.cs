using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NSubstitute;
using SearchLib.Model;
using SearchLib.Controller;

namespace SearchLibTest.ControllerTest
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

            _parser.When(x => x.AddDocumentWordsToInvertedIndex(_index, _documents[0])).
                Do(x => { });
        }

        [Fact]
        public void TestHandler()
        {
            SetUp();
            var documentsHandler = new DocumentsHandler(_parser);

            documentsHandler.AddDocumentsToIndex(_index, _documents);

            _parser.Received().AddDocumentWordsToInvertedIndex(_index, _documents[0]);
        }
    }
}
