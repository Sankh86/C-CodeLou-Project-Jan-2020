using System;
using System.Collections;
using Newtonsoft.Json;

namespace DCheatham.CodeLou.ExerciseProject
{
    public class Student
    {
        private ArrayList _studentList = new ArrayList();
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassName { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string LastClassCompleted { get; set; }
        public DateTimeOffset LastClassCompletedOn { get; set; }

        public void AddStudent()
        {
            Console.Clear();
            var studentRecord = new Student();

            bool checkStudentId = true;
            bool checkLastCompleted = true;
            bool checkStartDate = true;

            while (checkStudentId)
            {
                Console.Write("               Enter Student Id: ");
                var input = Console.ReadLine();
                if (Int32.TryParse(input, out var val))
                {
                    if (UniqueId(val))
                    {
                        checkStudentId = false;
                        studentRecord.StudentId = val;
                    }
                    else
                    {
                        Console.WriteLine("   ID Exists! please enter new number.");
                    }
                }
                else{
                    Console.WriteLine("   Invalid Input! please enter a number.");
                }
            }

            Console.Write("               Enter First Name: ");
            studentRecord.FirstName = Console.ReadLine();

            Console.Write("                Enter Last Name: ");
            studentRecord.LastName = Console.ReadLine();

            Console.Write("       Enter Current Class Name: ");
            studentRecord.ClassName = Console.ReadLine();

            Console.WriteLine("Enter Start Date in format mm/dd/yyyy");
            while (checkStartDate)
            {
                var input = Console.ReadLine();
                if (DateTimeOffset.TryParse(input, out var dateValue))
                {
                    checkStartDate = false;
                    studentRecord.StartDate = dateValue;
                }
                else{
                    Console.WriteLine("   Invalid Input! please enter in correct format! (mm/dd/yyyy)");
                }
            }

            Console.Write("Enter Last Class Completed Name: ");
            studentRecord.LastClassCompleted = Console.ReadLine();

            Console.WriteLine("Enter Last Class Completed Date in format mm/dd/yyyy");
            while (checkLastCompleted)
            {
                var input = Console.ReadLine();
                if (DateTimeOffset.TryParse(input, out var dateValue))
                {
                    checkLastCompleted = false;
                    studentRecord.LastClassCompletedOn = dateValue;
                }
                else{
                    Console.WriteLine("   Invalid Input! please enter in correct format! (mm/dd/yyyy)");
                }
            }

            _studentList.Add(studentRecord);
            string json = JsonConvert.SerializeObject(_studentList.ToArray(), Formatting.Indented);
            System.IO.File.WriteAllText(@"..\src\StudentRecords.json", json);
        }

        public void ViewRecords()
        {
            Console.Clear();
            Console.WriteLine("    Student ID | Name | Class");
            Console.WriteLine("+-------------------------------+");
            foreach (Student student in _studentList)
            {
                Console.WriteLine($"{student.StudentId} | {student.FirstName} {student.LastName} | {student.ClassName}");
            }
            if (_studentList.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("       < No records found >");
            }
            Console.ReadLine();
        }

        public void FindByName()
        {
            int numRecord = 0;
            Console.Clear();
            Console.Write("Enter full name of student ([First Name] [Last Name]): ");
            string search = Console.ReadLine();
            Console.WriteLine();
            foreach (Student student in _studentList)
            {
                string recordName = $"{student.FirstName} {student.LastName}";

                if (search.ToLower() == recordName.ToLower())
                {
                    if (numRecord == 0)
                    {
                        Console.WriteLine("    Student ID | Name | Class");
                        Console.WriteLine("+-------------------------------+");
                    }
                    Console.WriteLine($"{student.StudentId} | {student.FirstName} {student.LastName} | {student.ClassName}");
                    numRecord += 1;
                }
            }

            if (numRecord == 0)
            {
                Console.WriteLine();
                Console.WriteLine("  < Could not find student with that name >");
            }
            Console.ReadLine();
        }

        public void FindByCourse()
        {
            int numRecord = 0;
            Console.Clear();
            Console.Write("Enter name of class: ");
            string search = Console.ReadLine();
            Console.WriteLine();
            foreach (Student student in _studentList)
            {
                string courseName = student.ClassName;

                if (search.ToLower() == courseName.ToLower())
                {
                    if (numRecord == 0)
                    {
                        Console.WriteLine($"Student ID | Name |  Class ");
                    }
                    Console.WriteLine($"{student.StudentId} | {student.FirstName} {student.LastName} | {student.ClassName}");
                    numRecord += 1;
                }
            }

            if (numRecord == 0)
            {
                Console.WriteLine();
                Console.WriteLine("  < Could not find students elisted in that class >");
            }
            Console.ReadLine();
        }

        private bool UniqueId(int testId)
        {
            int numRecord = 0;
            foreach (Student student in _studentList)
            {
                int studentId = student.StudentId;

                if (studentId == testId)
                {
                    numRecord += 1;
                }
            }
            return numRecord == 0;
        }

        //var json = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(@"..\src\StudentRecords.json"));
    }
}