﻿using System.Collections.Generic;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller
{
    public interface IQueryHandler
    {
        List<IDocument> OperateOnQuery(IInvertedIndex index);
    }
}
