using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SearchEngine.Services;
using SearchEngine.Services.DataBase;
using SearchEngine.Model.Entities;

namespace SearchEngine.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class SearchEngine : ControllerBase, ISearchEngine
    {
        private readonly IDbHandler _dbHandler;
        private readonly IDirectoryHandler _directoryHandler;

        public SearchEngine(IDbHandler dbHandler)
        {
            _dbHandler = dbHandler;
            _directoryHandler = new DirectoryHandler(_dbHandler, new DocumentParser());
        }

        [HttpPost]
        [Route("add_dir")]
        public IActionResult AddDirPath([FromQuery] string directoryPath)
        {
            _directoryHandler.ExtractDocuments(directoryPath);
            return Ok();
        }

        [HttpGet]
        [Route("search/{searchQuery}")]
        public ActionResult<List<Document>> Search([FromRoute] string searchQuery)
        {
            var queryHandler = new QueryHandler(searchQuery);
            return queryHandler.OperateOnQuery(_dbHandler);
        }
    }
}