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
        public List<Student> Students { get; private set; }

        public List<Grade> Grades { get; private set; }

        public void Parse(StreamReader studentsFile, StreamReader gradesFile)
        {
            Students =
                JsonSerializer.Deserialize<List<Student>>(studentsFile.ReadToEnd());
            studentsFile.Close();
            Grades =
                JsonSerializer.Deserialize<List<Grade>>(gradesFile.ReadToEnd());
        }
    }
}
