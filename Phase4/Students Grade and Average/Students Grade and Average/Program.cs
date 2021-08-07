using System;
using System.IO;
namespace StudentsGradeandAverage
{
    class Program
    {
        private const string StudentsFilePath = "Students.json";
        private const string GradesFilePath = "Grades.json";
        static void Main(string[] args)
        {
            var parser = new Parser();
            parser.Parse(new StreamReader(StudentsFilePath), new StreamReader(GradesFilePath));
            var studentsScoreHandler = new StudentsScoreHandler(parser.Students, parser.Grades);
            studentsScoreHandler.AssignGradesToStudents();
            studentsScoreHandler.SortStudentsByScore();
            var view = new View(studentsScoreHandler.Students);
            view.Run();
        }
    }
}
