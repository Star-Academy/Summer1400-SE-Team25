using System;
using System.Collections.Generic;
using System.Text;
using SearchEngine.Model;

namespace SearchLib.Model.Operator
{
    public interface IOperator
    {
        List<IDocument> Operate(IInvertedIndex index, List<IDocument> currentResult);
    }
}
