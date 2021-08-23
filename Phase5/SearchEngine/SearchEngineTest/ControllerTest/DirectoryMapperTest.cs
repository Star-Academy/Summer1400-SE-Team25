using System;
using SearchLib.Controller;
using SearchLib.Model;
using Xunit;
using System.IO;
using System.Linq;
using Xunit.Abstractions;

namespace SearchLibTest.ControllerTest
{
    public class DirectoryMapperTest
    {
        private readonly string ValidDirPath = "EnglishData";
        private readonly string _firstValidDocumentPath = "EnglishData" + Path.DirectorySeparatorChar + "57110";
        private readonly string _secondValidDocumentPath = "EnglishData" + Path.DirectorySeparatorChar + "58043";
        private readonly string _thirdValidDocumentPath = "EnglishData" + Path.DirectorySeparatorChar + "58044";
        private IDirectoryMapper _directoryMapper;

        [Fact]
        public void ExtractDocumentsFromValidDir()
        {
            _directoryMapper = new DirectoryMapper();
            var actualResult = _directoryMapper.ExtractDocuments(ValidDirPath);
            var expectedResult = new System.Collections.Generic.List<Document>()
            {
                new Document(_firstValidDocumentPath),
                new Document(_secondValidDocumentPath),
                new Document(_thirdValidDocumentPath)
            };
            Assert.True(actualResult.All(expectedResult.Contains) && actualResult.Count == expectedResult.Count);
        }
    }
}