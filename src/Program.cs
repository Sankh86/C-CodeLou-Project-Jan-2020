using System;

namespace DCheatham.CodeLou.ExerciseProject
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            StudentRepository studentList = new StudentRepository();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("+--------------------------------+");
                Console.WriteLine("|  Student Entry/Selection Menu  |");
                Console.WriteLine("+--------------------------------+");
                Console.WriteLine();
                Console.WriteLine("   1. New Student");
                Console.WriteLine("   2. List Students");
                Console.WriteLine("   3. Find Student By Name");
                Console.WriteLine("   4. Find Student By Course");
                Console.WriteLine("   5. Exit");
                string input = Console.ReadLine();

                if (input == "1" || input == "1." || input.ToLower() == "new student")
                {
                    studentList.AddStudent();
                }

                if(input == "2" || input == "2." || input.ToLower() == "list students")
                {
                    studentList.ViewRecords();
                }

                if(input == "3" || input == "3." || input.ToLower() == "find student by name")
                {
                    studentList.FindByName();
                }

                if(input == "4" || input == "4." || input.ToLower() == "find student by course")
                {
                    studentList.FindByCourse();
                }

                if (input == "5" || input == "5." || input.ToLower() == "exit" || input.ToLower() == "q" || input.ToLower() == "quit")
                {
                    Console.Clear();
                    Console.WriteLine("Program End");
                    break;
                }
            }
        }
    }
}
