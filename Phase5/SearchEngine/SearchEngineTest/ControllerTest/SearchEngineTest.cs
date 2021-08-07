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
        private const string ValidDirPath = "EnglishData";
        private const string SearchQuery1 = "+happen +old +convention";
        private const string SearchQuery2 = "+happen +old +convention same";
        private const string SearchQuery3 = "+happen +old +convention -same";
        private readonly string _firstFilePath = ValidDirPath + Path.DirectorySeparatorChar + "57110";
        private readonly string _secondFilePath = ValidDirPath + Path.DirectorySeparatorChar + "58043";
        private readonly string _thirdFilePath = ValidDirPath + Path.DirectorySeparatorChar + "58044";
        private ISearchEngine _searchEngine;

        private void InitializeProperties()
        {
            _searchEngine = new SearchEngine();
            _searchEngine.AddDirPath(ValidDirPath);
        }

        [Fact]
        public void SearchTest1()
        {
            InitializeProperties();
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
            InitializeProperties();
            var actualResult = _searchEngine.Search(SearchQuery2);
            var expectedResult = new List<IDocument>()
            {
                new Document(_secondFilePath)
            };

            Assert.True(actualResult.SequenceEqual(expectedResult, new DocumentFileComparator()));
        }

        [Fact]
        public void SearchTest3()
        {
            InitializeProperties();
            var actualResult = _searchEngine.Search(SearchQuery3);
            var expectedResult = new List<IDocument>()
            {
                new Document(_firstFilePath),
                new Document(_thirdFilePath)
            };

            Assert.True(actualResult.SequenceEqual(expectedResult, new DocumentFileComparator()));
        }
    }
}