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
        private const string FirstValidDocumentPath = "EnglishData/57110";
        private const string SecondValidDocumentPath = "EnglishData/58119";
        private IDirectoryMapper _directoryMapper;

        [Fact]
        public void ExtractDocumentsFromValidDir()
        {
            _directoryMapper = new DirectoryMapper();
            var actualResult = _directoryMapper.ExtractDocuments(ValidDirPath);
            var expectedResult = new System.Collections.Generic.List<Document>()
            {
                new Document(ValidDirPath + Path.DirectorySeparatorChar + "57110"),
                new Document(ValidDirPath + Path.DirectorySeparatorChar + "58043")
            };

            Assert.True(actualResult.SequenceEqual(expectedResult));
        }
    }
}