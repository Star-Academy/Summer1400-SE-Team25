using System;
using System.Collections.Generic;
using System.Text;
using SearchLib.Controller;
using SearchLib.Model;
using Xunit;
using NSubstitute;
using System.Linq;

namespace SearchLibTest.ControllerTest
{
    public class QueryHandlerTest
    {
        private readonly string AndQuery = "test1";
        private readonly string OrQuery = "+test2";
        private readonly string NotQuery = "-test3";
        private IInvertedIndex _index;
        private IList<IDocument> _allDocuments;

        private IList<IDocument> _andQueryResult;
        private IList<IDocument> _orQueryResult;
        private IList<IDocument> _notQueryResult;

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

            _index.GetWordOccurrence(AndQuery).Returns(_andQueryResult);
            _index.GetWordOccurrence(OrQuery.Substring(1)).Returns(_orQueryResult);
            _index.GetWordOccurrence(NotQuery.Substring(1)).Returns(_notQueryResult);
        }

        [Fact]
        public void OperateOnOrQueryTest()
        {
            SetUp();
            var queryHandler = new QueryHandler(OrQuery);
            var actualResult = queryHandler.OperateOnQuery(_index);

            Assert.True(actualResult.SequenceEqual(_orQueryResult));
        }

        [Fact]
        public void OperateOnAndQueryTest()
        {
            SetUp();
            var queryHander = new QueryHandler(AndQuery);
            var actualResult = queryHander.OperateOnQuery(_index);

            Assert.True(!actualResult.Any());
        }

        [Fact]
        public void OperatOnNotQueryTest()
        {
            SetUp();
            var queryHandler = new QueryHandler(NotQuery);
            var actualResult = queryHandler.OperateOnQuery(_index);

            Assert.True(!actualResult.Any());
        }

        [Fact]
        public void OperateOnComplexQueryTest()
        {
            SetUp();
            var queryHandler = new QueryHandler(OrQuery + ' ' + AndQuery + ' ' + NotQuery);
            var actualResult = queryHandler.OperateOnQuery(_index);
            var expectedResult = new List<IDocument>()
            {
                _allDocuments[1]
            };

            Assert.True(actualResult.SequenceEqual(expectedResult));
        }
    }
}
