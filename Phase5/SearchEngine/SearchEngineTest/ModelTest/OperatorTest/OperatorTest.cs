using System;
using System.Collections.Generic;
using System.Text;
using SearchEngine.Model.Operator;
using SearchEngine.Model;
using Xunit;
using NSubstitute;
using System.Linq;

namespace SearchEngineTest.ModelTest.OperatorTest
{
    public class OperatorTest
    {
        private readonly string _query = "test word";
        private List<IDocument> _currentSearchResultList;
        private List<IDocument> _allDocuments;
        private IInvertedIndex _index;

        private void SetUpDocuments()
        {
            var document1 = Substitute.For<IDocument>();
            var document2 = Substitute.For<IDocument>();
            var document3 = Substitute.For<IDocument>();
            var document4 = Substitute.For<IDocument>();

            _allDocuments = new List<IDocument>()
            {
                document1, document2, document3, document4
            };
        }

        private void SetUpCurrentSearchResultList()
        {
            _currentSearchResultList = new List<IDocument>()
            {
                _allDocuments[0], _allDocuments[1]
            };
        }

        private void SetUpIndex()
        {
            _index = Substitute.For<IInvertedIndex>();
            var searchResult = new List<IDocument>()
            {
                _allDocuments[1], _allDocuments[2], _allDocuments[3]
            };
            _index.GetWordOccurrence(_query).Returns(searchResult);
        }

        [Fact]
        public void TestOrOperator()
        {
            var orOperator = new OrOperator(_query);
            SetUpDocuments();
            SetUpCurrentSearchResultList();
            SetUpIndex();

            var actualResult = orOperator.Operate(_index, _currentSearchResultList);
            var expectedResult = new List<IDocument>()
            {
                _allDocuments[0], _allDocuments[1], _allDocuments[2], _allDocuments[3]
            };

            Assert.True(actualResult.SequenceEqual(expectedResult));
        }

        [Fact]
        public void TestAndOperator()
        {
            var andOperator = new AndOperator(_query);
            SetUpDocuments();
            SetUpCurrentSearchResultList();
            SetUpIndex();

            var actualResult = andOperator.Operate(_index, _currentSearchResultList);
            var expectedResult = new List<IDocument>()
            {
                _allDocuments[1]
            };

            Assert.True(actualResult.SequenceEqual(expectedResult));
        }

        [Fact]
        public void TestNotOperator()
        {
            var notOperator = new NotOperator(_query);
            SetUpDocuments();
            SetUpCurrentSearchResultList();
            SetUpIndex();

            var actualResult = notOperator.Operate(_index, _currentSearchResultList);
            var expectedResult = new List<IDocument>()
            {
                _allDocuments[0]
            };

            Assert.True(actualResult.SequenceEqual(expectedResult));
        }
    }
}
