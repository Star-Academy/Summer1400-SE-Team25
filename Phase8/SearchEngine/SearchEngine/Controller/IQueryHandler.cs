﻿using System.Collections.Generic;
using SearchEngine.Controller.DataBase;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller
{
    public interface IQueryHandler
    {
        List<Document> OperateOnQuery(IDbHandler dbHandler);
    }
}
