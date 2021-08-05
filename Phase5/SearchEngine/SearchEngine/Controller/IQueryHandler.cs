using System;
using System.Collections.Generic;
using System.Text;
using SearchLib.Model;

namespace SearchLib.Controller
{
    public interface IQueryHandler
    {
        List<IDocument> OperateOnQuery(IInvertedIndex index);
    }
}
