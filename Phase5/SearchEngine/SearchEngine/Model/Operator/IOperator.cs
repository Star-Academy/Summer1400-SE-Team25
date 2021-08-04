using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Model.Operator
{
    public interface IOperator
    {
        List<IDocument> Operate(IInvertedIndex index, List<IDocument> currentResult);
    }
}
