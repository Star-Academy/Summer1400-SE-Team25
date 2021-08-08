using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NSubstitute;
using SearchLib.Model;
using System.Linq;

namespace SearchLibTest.ModelTest
{
    public class InvertedIndexTest
    {

        private InvertedIndex _index = new InvertedIndex();
        private List<IDocument> _documentsList = new List<IDocument>()
        {
            Substitute.For<IDocument>(),
            Substitute.For<IDocument>(),
            Substitute.For<IDocument>()
        };

        private const string Query = "query";

        [Fact]
        public void TestIndex1()
        {
            _index.AddWordOccurrence(Query, _documentsList[0]);

            var actualResult = _index.GetWordOccurrence(Query);
            var expectedresult = new List<IDocument>() 
            {
                _documentsList[0]
            };

            Assert.True(actualResult.SequenceEqual(expectedresult));
        }

        [Fact]
        public void TestIndex2()
        {
            var actualResult = _index.GetWordOccurrence(Query);

            Assert.True(!actualResult.Any());
        }

        [Fact]
        public void TestIndex3()
        {
            _index.AddWordOccurrence(Query, _documentsList[0]);
            _index.AddWordOccurrence(Query, _documentsList[1]);
            _index.AddWordOccurrence(Query, _documentsList[2]);

            var actualResult = _index.GetWordOccurrence(Query);
            var expectedResult = _documentsList;

            Assert.True(actualResult.SequenceEqual(expectedResult));
        }

        [Fact]
        public void TestIndex4()
        {
            _index.AddWordOccurrence(Query, _documentsList[0]);
            _index.AddWordOccurrence(Query, _documentsList[0]);

            var actualResult = _index.GetWordOccurrence(Query);
            var expectedResult = new List<IDocument>()
            { 
                _documentsList[0]
            };

            Assert.True(actualResult.SequenceEqual(expectedResult));
        }

        [Fact]
        public void TestIndex5()
        {
            _index.AddWordOccurrence(Query, _documentsList[0]);
            _index.AddWordOccurrence(Query, _documentsList[1]);
            _index.AddWordOccurrence(Query, _documentsList[1]);

            var atcualResult = _index.GetWordOccurrence(Query);
            var expecctedResult = new List<IDocument>()
            {
                _documentsList[0],
                _documentsList[1]
            };

            Assert.True(atcualResult.SequenceEqual(expecctedResult));
        }
    }
}
