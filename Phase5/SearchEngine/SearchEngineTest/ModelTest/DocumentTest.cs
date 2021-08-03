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
        private readonly ITestOutputHelper _outputWriter;

        public DocumentTest()
        {
            _outputWriter = new TestOutputHelper();
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
            Assert.Throws<FileNotFoundException>(InitializeInvalidDocument);
        }

        [Fact]
        public void GetDocumentNameTest()
        {
            var documentName = _document.GetDocumentName();
            _outputWriter.WriteLine(documentName);
        }
    }
}