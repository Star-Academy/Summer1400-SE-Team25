using SearchEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;
using SearchEngine.Model.Operator;

namespace SearchEngine.Controller
{
    public class QueryHandler : IQueryHandler
    {
        private readonly string _searchQuery;
        private List<IOperator> _operatorsList;
        public QueryHandler(string searchQuery)
        {
            this._searchQuery = searchQuery;
        }

        public List<IDocument> OperateOnQuery(IInvertedIndex index)
        {
            throw new NotImplementedException();
        }
    }
}
