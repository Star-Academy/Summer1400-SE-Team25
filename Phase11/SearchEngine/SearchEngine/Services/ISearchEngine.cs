using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SearchEngine.Model;
using SearchEngine.Model.Entities;

namespace SearchEngine.Services
{
    public interface ISearchEngine
    {
        IActionResult AddDirPath(string dirPath);

        ActionResult<List<Document>> Search(string searchQuery);
    }
}