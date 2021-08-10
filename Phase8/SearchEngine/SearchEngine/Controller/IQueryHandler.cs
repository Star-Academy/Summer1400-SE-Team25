using System.Collections.Generic;
using SearchEngine.Model;

namespace SearchEngine.Controller
{
    public interface IQueryHandler
    {
        List<IDocument> OperateOnQuery(IInvertedIndex index);
    }
}
