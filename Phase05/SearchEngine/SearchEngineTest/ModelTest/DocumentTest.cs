using System;
using System.IO;
using SearchLib.Model;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SearchLibTest.ModelTest
{
    public class DocumentTest
    {
        private const string ValidDocumentPath = "EnglishData/57110";
        private const string InvalidDocumentPath = "EnglishData/100";
        private const string ValidDocumentPreview = "I have a 42 yr old male fri...";
        private const string ValidDocumentToString = "57110: \n\tI have a 42 yr old male fri...";
        private IDocument _document;

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
            var exception = Record.Exception(InitializeValidDocument);
            Assert.Null(exception);
        }

        [Fact]
        public void TestInvalidDocument()
        {
            InitializeInvalidDocument();
            // Assert.Throws<FileNotFoundException>(InitializeInvalidDocument);
        }

        [Fact]
        public void TestDocumentPreview()
        {
            InitializeValidDocument();
            var documentName = _document.GetDocumentPreview();
            Assert.Equal(ValidDocumentPreview, documentName);
        }

        [Fact]
        public void TestDocumentToString()
        {
            InitializeValidDocument();
            var documentToString = _document.ToString();
            Assert.Equal(documentToString, ValidDocumentToString);
        }
    }
}