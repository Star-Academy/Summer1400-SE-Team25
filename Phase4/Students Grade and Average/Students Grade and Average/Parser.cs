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
        private List<Student> students;
        public List<Student> Students
        {
            get { return students; }
        }

        private List<Grade> grades;
        private string studentsFilePath;
        private string gradesFilePath;

        public Parser(string studentsFilePath, string gradesFilePath)
        {
            this.studentsFilePath = studentsFilePath;
            this.gradesFilePath = gradesFilePath;
            Parse();
        }

        public void Parse()
        {
            var studentsFile = new StreamReader(studentsFilePath);
            students =
                JsonSerializer.Deserialize<List<Student>>(studentsFile.ReadToEnd());
            studentsFile.Close();
            var gradesFile = new StreamReader(gradesFilePath);
            grades =
                JsonSerializer.Deserialize<List<Grade>>(gradesFile.ReadToEnd());
            AssignGradesToStudents();
        }

        private void AssignGradesToStudents()
        {
            foreach(var stud in students)
            {
                stud.Grades = (from grade in grades
                              where grade.StudentNumber == stud.StudentNumber
                              select grade).ToList();
            }
        }
    }
}
