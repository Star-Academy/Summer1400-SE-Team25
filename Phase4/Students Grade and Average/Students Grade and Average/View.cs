using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsGradeandAverage
{
    class View
    {
        private readonly List<Student> _studentsList;
        private const int MaxStudentsViewed = 3;

        public View(List<Student> studentsList)
        {
            this._studentsList = studentsList;
        }

        public void Run()
        {
            for (int i = 0; i < MaxStudentsViewed; i++)
            {
                Console.WriteLine(_studentsList[i].ToString());
            }
        }
    }
}
