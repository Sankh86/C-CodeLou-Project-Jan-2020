using System;

namespace DCheatham.CodeLou.ExerciseProject
{
    public class Student
    {
        //private ArrayList _studentList = JsonConvert.DeserializeObject<ArrayList>(System.IO.File.ReadAllText(@"..\src\StudentRecords.json"));
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassName { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string LastClassCompleted { get; set; }
        public DateTimeOffset LastClassCompletedOn { get; set; }
        //var json = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(@"..\src\StudentRecords.json"));
    }
}