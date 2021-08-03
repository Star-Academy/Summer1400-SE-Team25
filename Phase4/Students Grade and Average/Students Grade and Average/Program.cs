using System;

namespace Students_Grade_and_Average
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser("Students.txt", "Grades.txt");
            var view = new View(parser.Students);
            view.Run();
        }
    }
}
