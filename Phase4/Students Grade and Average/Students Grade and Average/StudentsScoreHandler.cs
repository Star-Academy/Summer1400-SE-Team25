using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StudentsGradeandAverage
{
    public class StudentsScoreHandler
    {
        private List<Student> _students;
        public List<Student> Students
        {
            get { return _students; }
        }

        private List<Grade> _grades;

        public StudentsScoreHandler(List<Student> students, List<Grade> grades)
        {
            this._students = students;
            this._grades = grades;
        }

        public void AssignGradesToStudents()
        {
            _students.ForEach(student => student.Grades = ExtractStudentsGrades(student.StudentNumber));
        }

        private List<Grade> ExtractStudentsGrades(int studentNumber)
        {
            return (from grade in _grades
                    where grade.StudentNumber == studentNumber
                    select grade).ToList();
        }

        public void SortStudentsByScore()
        {
            _students.Sort((a, b) => a.GetGradesAverage().CompareTo(b.GetGradesAverage()));
        }
    }
}
