using System;
using System.Collections.Generic;
using System.Text;

namespace Students_Grade_and_Average
{
    class View
    {
        private List<Student> studentsList;
        private const int maxStudentsViewed = 3;

        public View(List<Student> studentsList)
        {
            this.studentsList = studentsList;
            studentsList.Sort((a, b) => { return a.GradesAverage().CompareTo(b.GradesAverage()); });
        }

        public void Run()
        {
            for (int i = 0; i < maxStudentsViewed; i++)
            {
                Console.WriteLine(studentsList[i].ToString());
            }
        }
    }
}
