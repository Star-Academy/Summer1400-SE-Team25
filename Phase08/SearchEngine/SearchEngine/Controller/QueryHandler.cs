using System.Collections.Generic;
using System.Linq;
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
            _operatorsList = new List<IOperator>();
            MakeOperatorsList(searchQuery.Split(" "));
        }

        public List<Document> OperateOnQuery(IDbHandler dbHandler)
        {
            var result = new List<Document>();
            return _operatorsList.
                Aggregate(result, (current, operation) => operation.Operate(dbHandler, current));
        }

        private void MakeOperatorsList(IEnumerable<string> searchQuery)
        {
            foreach (var query in searchQuery)
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
