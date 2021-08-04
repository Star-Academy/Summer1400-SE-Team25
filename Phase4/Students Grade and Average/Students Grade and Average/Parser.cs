using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace StudentsGradeandAverage
{
    class Parser
    {
        private List<Student> _students;
        public List<Student> Students
        {
            get { return _students; }
        }

        private List<Grade> _grades;
        public List<Grade> Grades
        {
            get { return _grades; }
        }

        private string studentsFilePath;
        private string gradesFilePath;

        public Parser(string studentsFilePath, string gradesFilePath)
        {
            this.studentsFilePath = studentsFilePath;
            this.gradesFilePath = gradesFilePath;
        }

        public void Parse()
        {
            var studentsFile = new StreamReader(studentsFilePath);
            _students =
                JsonSerializer.Deserialize<List<Student>>(studentsFile.ReadToEnd());
            studentsFile.Close();
            var gradesFile = new StreamReader(gradesFilePath);
            _grades =
                JsonSerializer.Deserialize<List<Grade>>(gradesFile.ReadToEnd());
        }
    }
}
