using System.Collections.Generic;
using SearchEngine.Services.DataBase;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchEngine.Services
{
    public interface IQueryHandler
    {
        List<Document> OperateOnQuery(IDbHandler dbHandler);
    }
}
