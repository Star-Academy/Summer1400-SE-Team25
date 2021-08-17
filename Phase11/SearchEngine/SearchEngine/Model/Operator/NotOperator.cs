using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SearchEngine.Services.DataBase;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchLib.Model.Operator
{
    public class NotOperator : IOperator
    {
        public string Query { get; }

        public NotOperator(string query)
        {
            this.Query = query;
        }

        public List<Document> Operate(IDbHandler index, List<Document> currentResult)
        {
            var searchResult = index.GetWordOccurrences(Query);
            currentResult.RemoveAll(x => searchResult.Contains(x));
            return currentResult;
        }
    }
}
