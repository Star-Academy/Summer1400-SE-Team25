using System;
using System.Collections.Generic;
using System.Text;

namespace Students_Grade_and_Average
{
    class View
    {
        private readonly List<Student> studentsList;
        private const int MaxStudentsViewed = 3;

        public View(List<Student> studentsList)
        {
            this.studentsList = studentsList;
            studentsList.Sort((a, b) => a.GetGradesAverage().CompareTo(b.GetGradesAverage()) );
        }

        public void Run()
        {
            for (int i = 0; i < MaxStudentsViewed; i++)
            {
                Console.WriteLine(studentsList[i].ToString());
            }
        }
    }
}
