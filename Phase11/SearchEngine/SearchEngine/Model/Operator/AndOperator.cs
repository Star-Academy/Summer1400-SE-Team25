﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SearchEngine.Controller.DataBase;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchLib.Model.Operator
{
    public class AndOperator : IOperator
    {
        public string Query { get; }

        public AndOperator(string query)
        {
            this.Query = query;
        }

        public List<Document> Operate(IDbHandler index, List<Document> currentResult)
        {
            var searcResutlt = index.GetWordOccurrences(Query);
            return currentResult.Intersect(searcResutlt).ToList();
        }
    }
}