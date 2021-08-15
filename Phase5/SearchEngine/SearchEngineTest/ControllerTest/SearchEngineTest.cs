using System.IO;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using SearchLib.Controller;
using SearchLib.Model;

namespace SearchLibTest.ControllerTest
{
    public class SearchEngineTest
    {
        private readonly string ValidDirPath = "EnglishData";
        private readonly string SearchQuery1 = "+happen +old +convention";
        private readonly string SearchQuery2 = "+happen +old +convention same";
        private readonly string SearchQuery3 = "+happen +old +convention -same";
        private readonly string _firstFilePath;
        private readonly string _secondFilePath;
        private readonly string _thirdFilePath;
        private ISearchEngine _searchEngine;

        public SearchEngineTest()
        {
            _firstFilePath = ValidDirPath + Path.DirectorySeparatorChar + "57110";
            _secondFilePath = ValidDirPath + Path.DirectorySeparatorChar + "58043";
            _thirdFilePath = ValidDirPath + Path.DirectorySeparatorChar + "58044";
            _searchEngine = new SearchEngine();
            _searchEngine.AddDirPath(ValidDirPath);
        }

        [Fact]
        public void SearchTest1()
        {
            var actualResult = _searchEngine.Search(SearchQuery1);
            var expectedResult = new List<IDocument>()
            {
                new Document(_firstFilePath),
                new Document(_secondFilePath),
                new Document(_thirdFilePath)
            };

            Assert.True(actualResult.Intersect(expectedResult).Count() == actualResult.Count());
        }

        [Fact]
        public void SearchTest2()
        {
            var actualResult = _searchEngine.Search(SearchQuery2);
            var expectedResult = new List<IDocument>()
            {
                new Document(_secondFilePath)
            };

            Assert.True(actualResult.SequenceEqual(expectedResult));
        }

        [Fact]
        public void SearchTest3()
        {
            var actualResult = _searchEngine.Search(SearchQuery3);
            var expectedResult = new List<IDocument>()
            {
                new Document(_firstFilePath),
                new Document(_thirdFilePath)
            };

            Assert.True(actualResult.SequenceEqual(expectedResult));
        }
    }
}