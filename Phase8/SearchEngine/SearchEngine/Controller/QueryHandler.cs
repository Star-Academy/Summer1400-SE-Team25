using System.Collections.Generic;
using SearchEngine.Controller.DataBase;
using SearchEngine.Model;
using SearchEngine.Model.Entities;
using SearchLib.Model.Operator;

namespace SearchEngine.Controller
{
    public class QueryHandler : IQueryHandler
    {
        private readonly List<IOperator> _operatorsList;
        public QueryHandler(string searchQuery)
        {
            this._operatorsList = new List<IOperator>();
            MakeOperatorsList(searchQuery.Split(" "));
        }

        public List<IDocument> OperateOnQuery(IDbHandler index)
        {
            var result = new List<IDocument>();
            foreach (var operation in _operatorsList)
                result = operation.Operate(index, result);
            return result;
        }

        private void MakeOperatorsList(string[] searchQuery)
        {
            foreach (string query in searchQuery)
            {
                switch (query[0])
                {
                    case '+':
                        _operatorsList.Add(new OrOperator(query[1..]));
                        break;
                    case '-':
                        _operatorsList.Add(new NotOperator(query[1..]));
                        break;
                    default:
                        _operatorsList.Add(new AndOperator(query));
                        break;
                }
            }
        }
    }
}
