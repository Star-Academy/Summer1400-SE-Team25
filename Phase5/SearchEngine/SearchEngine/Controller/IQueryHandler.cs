using System;
using System.Collections.Generic;
using System.Text;
using SearchEngine.Model;

namespace SearchEngine.Controller
{
    public interface IQueryHandler
    {
        List<IDocument> OperateOnQuery(IInvertedIndex index);
    }
}
