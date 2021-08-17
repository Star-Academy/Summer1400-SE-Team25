using System;
using System.Collections.Generic;
using System.Text;
using SearchEngine.Services.DataBase;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchLib.Model.Operator
{
    public interface IOperator
    {
        List<Document> Operate(IDbHandler index, List<Document> currentResult);
    }
}
