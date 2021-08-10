using System;
using System.Collections.Generic;
using System.Text;
using SearchEngine.Controller.DataBase;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchLib.Model.Operator
{
    public interface IOperator
    {
        List<IDocument> Operate(IDbHandler index, List<IDocument> currentResult);
    }
}
