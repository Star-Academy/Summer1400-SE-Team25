using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controller
{
    public interface ISearchEngine
    {
        IActionResult AddDirPath(string dirPath);

        ActionResult<List<Document>> Search(string searchQuery);
    }
}