using SearchEngine.Controller;
using Xunit;

namespace SearchEngineTest.ControllerTest
{
    public class DirectoryMapperTest
    {
        private const string FirstValidDocumentPath = "EnglishData/57110";
        private const string SecondValidDocumentPath = "EnglishData/58119";
        private const string InvalidDocumentPath = "EnglishData/100";
        private IDirectoryMapper _directoryMapper;

        private void InitializeProperties()
        {
            _directoryMapper = new DirectoryMapper();
        }

        [Fact]
        public void TestAddingValidDocumentTwice()
        {
            InitializeProperties();
            var retrievedDocument1 = _directoryMapper.GetDocumentByDirectory(FirstValidDocumentPath);
            var retrievedDocument2 = _directoryMapper.GetDocumentByDirectory(FirstValidDocumentPath);
            Assert.Equal(retrievedDocument1, retrievedDocument2);
        }

        [Fact]
        public void TestAddingTwoValidDocument()
        {
            InitializeProperties();
            var retrievedDocument1 = _directoryMapper.GetDocumentByDirectory(FirstValidDocumentPath);
            var retrievedDocument2 = _directoryMapper.GetDocumentByDirectory(SecondValidDocumentPath);
            Assert.NotEqual(retrievedDocument1, retrievedDocument2);
        }

        [Fact]
        public void TestAddingInvalidDocument()
        {
            InitializeProperties();
            var retrievedDocument = _directoryMapper.GetDocumentByDirectory(InvalidDocumentPath);
            Assert.Null(retrievedDocument);
        }
    }
}