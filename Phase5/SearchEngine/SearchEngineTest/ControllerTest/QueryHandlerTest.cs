using System;
using System.Collections.Generic;
using System.Text;
using SearchEngine.Controller;
using SearchEngine.Model;
using Xunit;
using NSubstitute;
using System.Linq;

namespace SearchEngineTest.ControllerTest
{
    public class QueryHandlerTest
    {
        private readonly string _andQuery = "test1";
        private readonly string _orQuery = "+test2";
        private readonly string _notQuery = "-test3";
        private IInvertedIndex _index;
        private List<IDocument> _allDocuments;

        private List<IDocument> _andQueryResult;
        private List<IDocument> _orQueryResult;
        private List<IDocument> _notQueryResult;

        private void SetUp()
        {
            _index = Substitute.For<IInvertedIndex>();
            _allDocuments = new List<IDocument>()
            {
                Substitute.For<IDocument>(),
                Substitute.For<IDocument>(),
                Substitute.For<IDocument>()
            };
            _andQueryResult = new List<IDocument>()
            {
                _allDocuments[0],
                _allDocuments[1]

            };

            _orQueryResult = new List<IDocument>()
            {
                _allDocuments[1],
                _allDocuments[2]
            };

            _notQueryResult = new List<IDocument>()
            {
                _allDocuments[2]
            };

            _index.GetWordOccurrence(_andQuery).Returns(_andQueryResult);
            _index.GetWordOccurrence(_orQuery.Substring(1)).Returns(_orQueryResult);
            _index.GetWordOccurrence(_notQuery.Substring(1)).Returns(_notQueryResult);
        }

        [Fact]
        public void OperateOnOrQueryTest()
        {
            SetUp();
            var queryHandler = new QueryHandler(_orQuery);
            var actualResult = queryHandler.OperateOnQuery(_index);

            Assert.True(actualResult.SequenceEqual(_orQueryResult));
        }

        [Fact]
        public void OperateOnAndQueryTest()
        {
            SetUp();
            var queryHander = new QueryHandler(_andQuery);
            var actualResult = queryHander.OperateOnQuery(_index);

            Assert.True(!actualResult.Any());
        }

        [Fact]
        public void OperatOnNotQueryTest()
        {
            SetUp();
            var queryHandler = new QueryHandler(_notQuery);
            var actualResult = queryHandler.OperateOnQuery(_index);

            Assert.True(!actualResult.Any());
        }

        [Fact]
        public void OperateOnComplexQueryTest()
        {
            SetUp();
            var queryHandler = new QueryHandler(_orQuery + ' ' + _andQuery + ' ' + _notQuery);
            var actualResult = queryHandler.OperateOnQuery(_index);
            var expectedResult = new List<IDocument>()
            {
                _allDocuments[1]
            };

            Assert.True(actualResult.SequenceEqual(expectedResult));
        }
    }
}
