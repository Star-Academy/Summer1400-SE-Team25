using System.IO;
using NSubstitute;
using SearchLib.Model;
using Xunit;

namespace SearchLibTest.ModelTest
{
    public class DocumentParserTest
    {
        private readonly string ValidDocumentPath = "EnglishData/57110";
        private readonly string InvalidDocumentPath = "EnglishData/100";
        private readonly int ValidDocumentWordsCount = 201;
        private IDocumentParser _documentMapper;
        private IInvertedIndex _invertedIndex;
        private IDocument _validDocument;
        private IDocument _invalidDocument;
        private int _occuredWordCount;

        public DocumentParserTest()
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

    }
}