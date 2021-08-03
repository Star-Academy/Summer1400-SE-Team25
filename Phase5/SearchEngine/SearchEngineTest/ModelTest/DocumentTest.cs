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
        private const string ValidEnglishDataPath = "EnglishData/57110";
        private const string InvalidEnglishDataPath = "EnglishData/100";
        private Document _document;

        public DocumentTest()
        {
        }

        private void InitializeValidDocument()
        {
            _document = new Document(ValidEnglishDataPath);
        }

        private void InitializeInvalidDocument()
        {
            _document = new Document(InvalidEnglishDataPath);
        }

        [Fact]
        public void MakeValidDocument()
        {
            InitializeValidDocument();
        }

        [Fact]
        public void MakeInvalidDocument()
        {
            InitializeInvalidDocument();
            // Assert.Throws<FileNotFoundException>(_document.GetDocumentName);
        }

        [Fact]
        public void GetDocumentNameTest()
        {
            InitializeValidDocument();
            var documentName = _document.GetDocumentName();
        }
    }
}