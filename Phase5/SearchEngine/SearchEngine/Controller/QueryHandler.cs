using SearchEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;
using SearchEngine.Model.Operator;

namespace SearchEngine.Controller
{
    public class QueryHandler : IQueryHandler
    {
        private List<IOperator> _operatorsList;
        public QueryHandler(string searchQuery)
        {
            this._operatorsList = new List<IOperator>();
            MakeOperatorsList(searchQuery.Split(" "));
        }

        public List<IDocument> OperateOnQuery(IInvertedIndex index)
        {
            var result = new List<IDocument>();
            foreach (IOperator op in _operatorsList)
                result = op.Operate(index, result);
            return result;
        }

        private void MakeOperatorsList(string[] searchQuery)
        {
            foreach (string query in searchQuery)
            {
                if (query[0] == '+')
                    _operatorsList.Add(new OrOperator(query.Substring(1)));
                else if (query[0] == '-')
                    _operatorsList.Add(new NotOperator(query.Substring(1)));
                else
                    _operatorsList.Add(new AndOperator(query));
            }
        }
    }
}
