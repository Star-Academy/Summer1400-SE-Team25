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
        private const string validDirPath = "EnglishData";
        private readonly string searchQuery1 = "+happen +old +convention";
        private readonly string searchQuery2 = "+happen +old +convention same";
        private readonly string searchQuery3 = "+happen +old +convention -same";
        private readonly string firstFilePath = validDirPath + Path.DirectorySeparatorChar + "57110";
        private readonly string secondFilePath = validDirPath + Path.DirectorySeparatorChar + "58043";
        private readonly string thirdFilePath = validDirPath + Path.DirectorySeparatorChar + "58044";

        [Fact]
        public void Searctest1()
        {
            var searchEngine = new SearchEngine();
            searchEngine.AddDirPath(validDirPath);

            var actualResult = searchEngine.Search(searchQuery1);
            var expectedResult = new List<IDocument>()
            {
                new Document(firstFilePath),
                new Document(secondFilePath),
                new Document(thirdFilePath)
            };

            Assert.True(actualResult.Intersect(expectedResult).Count() == actualResult.Count());
        }

        [Fact]
        public void SearchTest2()
        {
            var searchEngine = new SearchEngine();
            searchEngine.AddDirPath(validDirPath);

            var actualResult = searchEngine.Search(searchQuery2);
            var expectedResult = new List<IDocument>()
            {
                new Document(secondFilePath)
            };

            Assert.True(actualResult.SequenceEqual(expectedResult, new DocumentFileComparator()));
        }

        [Fact]
        public void SearchTest3()
        {
            var searchEngine = new SearchEngine();
            searchEngine.AddDirPath(validDirPath);

            var actualResult = searchEngine.Search(searchQuery3);
            var expectedResult = new List<IDocument>()
            {
                new Document(firstFilePath),
                new Document(thirdFilePath)
            };

            Assert.True(actualResult.SequenceEqual(expectedResult, new DocumentFileComparator()));
        }
    }
}