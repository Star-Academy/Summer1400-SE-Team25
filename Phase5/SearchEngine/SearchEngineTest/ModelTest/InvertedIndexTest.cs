using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NSubstitute;
using SearchEngine.Model;
using System.Linq;

namespace SearchEngineTest.ModelTest
{
    public class InvertedIndexTest
    {
        [Fact]
        public void TestIndex()
        {
            var index = new InvertedIndex();
            var document1 = Substitute.For<IDocument>();

            index.AddWordOccurrence("test word", document1);
            var expectedResult = new List<IDocument> { document1 };
            Assert.True(index.GetWordOccurrence("test word").SequenceEqual(expectedResult));
        }
    }
}
