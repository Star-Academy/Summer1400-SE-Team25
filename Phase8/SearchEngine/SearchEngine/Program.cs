using System;
using SearchEngine.Controller.DataBase;

namespace SearchEngine
{
    class Program
    {
        private const string EnglishDataPath = "EnglishData/";
        static void Main(string[] args)
        {
            var context = new Context();
            var dbHandler = new DbHandler(context);
            var searchEngine = new Controller.SearchEngine(dbHandler);
            searchEngine.AddDirPath(EnglishDataPath);
            foreach (var document in searchEngine.Search("dog +platform -Order"))
                Console.WriteLine(document);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}