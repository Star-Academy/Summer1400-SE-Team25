using System;

namespace StudentsGradeandAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser("Students.json", "Grades.json");
            parser.Parse();
            var studentsScoreHandler = new StudentsScoreHandler(parser.Students, parser.Grades);
            studentsScoreHandler.AssignGradesToStudents();
            studentsScoreHandler.SortStudentsByScore();
            var view = new View(studentsScoreHandler.Students);
            view.Run();
        }
    }
}
