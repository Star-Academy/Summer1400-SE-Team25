using System.IO;
using NSubstitute;
using SearchEngine.Model;
using Xunit;

namespace SearchEngineTest.ModelTest
{
    public class DocumentMapperTest
    {
        private const string ValidDocumentPath = "EnglishData/57110";
        private const string InvalidDocumentPath = "EnglishData/100";
        private const int ValidDocumentWordsCount = 201;
        private IDocumentParser _documentMapper;
        private IInvertedIndex _invertedIndex;
        private IDocument _validDocument;
        private IDocument _invalidDocument;
        private int _occuredWordCount;

        public DocumentMapperTest()
        {
            _documentMapper = new DocumentParser();
            _invertedIndex = Substitute.For<IInvertedIndex>();
            _validDocument = Substitute.For<IDocument>();
            _invalidDocument = Substitute.For<IDocument>();
            _invertedIndex.
                When(invertedIndex => invertedIndex.AddWordOccurrence(Arg.Any<string>(), Arg.Any<IDocument>())).
                Do(invertedIndex => _occuredWordCount++);
            _validDocument.DocumentPath.Returns(ValidDocumentPath);
            _invalidDocument.DocumentPath.Returns(InvalidDocumentPath);
        }

        private void InitializeProperties()
        {
            _occuredWordCount = 0;
        }

        [Fact]
        public void TestAddValidDocumentWordsToInvertedIndex()
        {
            InitializeProperties();
            _documentMapper.AddDocumentWordsToInvertedIndex(_invertedIndex, _validDocument);
            Assert.Equal(ValidDocumentWordsCount, _occuredWordCount);
        }

        [Fact]
        public void TestAddInvalidDocumentWordsToInvertedIndex()
        {
            InitializeProperties();
            // Assert.Throws<FileNotFoundException>(() =>
            //     _documentMapper.AddDocumentWordsToInvertedIndex(_invertedIndex, _invalidDocument));
        }
    }
}