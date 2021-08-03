using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Students_Grade_and_Average
{
    class Parser
    {
        private List<Student> _students;
        public List<Student> Students
        {
            get { return _students; }
        }

        private List<Grade> grades;
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
            grades =
                JsonSerializer.Deserialize<List<Grade>>(gradesFile.ReadToEnd());
            AssignGradesToStudents();
        }

        private void AssignGradesToStudents()
        {
            foreach(var student in _students)
            {
                student.Grades = (from grade in grades
                              where grade.StudentNumber == student.StudentNumber
                              select grade).ToList();
            }
        }
    }
}
