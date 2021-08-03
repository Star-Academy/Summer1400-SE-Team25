using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Students_Grade_and_Average
{
    class Student
    {
        public List<Grade> Grades { get; set; }
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Student(int studentNumber, string firstName, string lastName)
        {
            StudentNumber = studentNumber;
            FirstName = firstName;
            LastName = lastName;
        }

        public double GetGradesAverage()
        {
            return Grades.Average(item => item.Score);
        }

        public override string ToString()
        {
            return String.Format("FirstName : {0} | LastName : {1} | Score average : {2}",
                FirstName, LastName, Math.Round(GetGradesAverage(), 2));
        }

    }
}
