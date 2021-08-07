using SearchLib.Controller;
using SearchLib.Model;
using Xunit;
using System.IO;
using System.Linq;

namespace SearchLibTest.ControllerTest
{
    public class DirectoryMapperTest
    {
        private const string ValidDirPath = "EnglishData";
        private const string FirstValidDocumentName = "57110";
        private const string SecondValidDocumentName = "58043";
        private const string ThirdValidDocumentName = "58044";
        private IDirectoryMapper _directoryMapper;

        [Fact]
        public void ExtractDocumentsFromValidDir()
        {
            _directoryMapper = new DirectoryMapper();
            var actualResult = _directoryMapper.ExtractDocuments(ValidDirPath);
            var expectedResult = new System.Collections.Generic.List<Document>()
            {
                new Document(ValidDirPath + Path.DirectorySeparatorChar + FirstValidDocumentName),
                new Document(ValidDirPath + Path.DirectorySeparatorChar + SecondValidDocumentName),
                new Document(ValidDirPath + Path.DirectorySeparatorChar + ThirdValidDocumentName)
            };

            Assert.True(actualResult.SequenceEqual(expectedResult, new DocumentFileComparator()));
        }
    }
}