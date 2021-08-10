using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SearchEngine.Model;

namespace SearchLib.Model.Operator
{
    public class AndOperator : IOperator
    {
        public string Query { get; }

        public AndOperator(string query)
        {
            this.Query = query;
        }

        public List<IDocument> Operate(IInvertedIndex index, List<IDocument> currentResult)
        {
            var searcResutlt = index.GetWordOccurrence(Query);
            return currentResult.Intersect(searcResutlt).ToList();
        }
    }
}
