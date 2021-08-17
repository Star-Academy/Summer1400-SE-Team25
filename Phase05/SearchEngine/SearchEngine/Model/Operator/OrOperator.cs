using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SearchLib.Model.Operator
{
    public class OrOperator : IOperator
    {
        public string Query { get; }

        public OrOperator(string query)
        {
            this.Query = query;
        }

        public List<IDocument> Operate(IInvertedIndex index, List<IDocument> currentResult)
        {
            var searchResult = index.GetWordOccurrence(Query);
            return currentResult.Union(searchResult).ToList();
        }
    }
}
