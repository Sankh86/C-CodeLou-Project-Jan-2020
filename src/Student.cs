using System;
using System.Collections;
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
                    checkStudentId = false;
                    studentRecord.StudentId = val;
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
        }

        public void ViewRecords()
        {
            Console.Clear();
            Console.WriteLine("Student ID | Name | Class");
            foreach (Student student in _studentList)
            {
                Console.WriteLine($"{student.StudentId} | {student.FirstName} {student.LastName} | {student.ClassName}");
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
                        Console.WriteLine($"Student ID | Name |  Class ");
                    }
                    Console.WriteLine($"{student.StudentId} | {student.FirstName} {student.LastName} | {student.ClassName}");
                    numRecord += 1;
                }
            }

            if (numRecord == 0)
            {
                Console.WriteLine("Could not find student with that name.");
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
                Console.WriteLine("Could not find students elisted in that class.");
            }
            Console.ReadLine();
        }

        // Console.WriteLine($"Student Id | Name |  Class ");
        // Console.WriteLine($"{studentRecord.StudentId} | {studentRecord.FirstName} {studentRecord.LastName} | {studentRecord.ClassName} ");
    }
}