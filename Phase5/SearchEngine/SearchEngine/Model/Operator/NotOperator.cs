using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SearchLib.Model.Operator
{
    public class NotOperator : IOperator
    {
        public string Query { get; }

        public NotOperator(string query)
        {
            this.Query = query;
        }

        public List<IDocument> Operate(IInvertedIndex index, List<IDocument> currentResult)
        {
            var searchResult = index.GetWordOccurrence(Query);
            currentResult.RemoveAll(x => searchResult.Contains(x));
            return currentResult;
        }
    }
}
