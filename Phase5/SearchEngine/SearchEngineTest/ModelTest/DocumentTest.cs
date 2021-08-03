using System;
using System.IO;
using SearchEngine.Model;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SearchEngineTest.ModelTest
{
    public class DocumentTest
    {
        private const string ValidDocumentPath = "EnglishData/57110";
        private const string InvalidDocumentPath = "EnglishData/100";
        private const string ValidDocumentPreview = "I have a 42 yr old male fri...";
        private Document _document;

        public DocumentTest()
        {
        }

        private void InitializeValidDocument()
        {
            _document = new Document(ValidDocumentPath);
        }

        private void InitializeInvalidDocument()
        {
            _document = new Document(InvalidDocumentPath);
        }

        [Fact]
        public void TestValidDocument()
        {
            InitializeValidDocument();
            var exception = Record.Exception(_document.GetDocumentPreview);
            Assert.Null(exception);
        }

        [Fact]
        public void TestInvalidDocument()
        {
            InitializeInvalidDocument();
            Assert.Throws<FileNotFoundException>(_document.GetDocumentPreview);
        }

        [Fact]
        public void TestDocumentPreview()
        {
            InitializeValidDocument();
            var documentName = _document.GetDocumentPreview();
            Assert.Equal(ValidDocumentPreview, documentName);
        }
    }
}