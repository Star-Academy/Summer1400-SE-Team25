using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsGradeandAverage
{
    public class Grade
    {
        public int StudentNumber { get; set; }
        public double Score { get; set; }
        public string Lesson { get; set; }

        public Grade(int studentNumber, double score, string lesson)
        {
            StudentNumber = studentNumber;
            Score = score;
            Lesson = lesson;
        }
    }
}
