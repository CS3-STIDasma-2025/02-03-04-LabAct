using System;
using System.Collections.Generic;

namespace TestRun.Student
{
    internal class Tenerife : Student
    {
        public override void Run()
        {
           
            string author = "Richel";

            Console.WriteLine("========================================");
            Console.WriteLine(" STUDENT GRADE MANAGEMENT SYSTEM ");
            Console.WriteLine("========================================");

           
            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();

           
            Console.WriteLine("\nChoose Mode:");
            Console.WriteLine("1 - Manual Input");
            Console.WriteLine("2 - Hardcoded Demo (Your 4 courses)");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            string[] courseNames;
            double[] courseGrades;

            if (choice == "2")
            {
              
                courseNames = new string[]
                {
                    "Computer Programming",
                    "Discrete Structures",
                    "Data Structures",
                    "College Calculus"
                };
                courseGrades = new double[] { 1.75, 1.5, 1.25, 1.25 };
            }
            else
            {
                Console.Write("Enter the number of courses: ");
                int courseCount = int.Parse(Console.ReadLine());

                courseNames = new string[courseCount];
                courseGrades = new double[courseCount];

                for (int i = 0; i < courseCount; i++)
                {
                    Console.Write($"Enter Course {i + 1} Name: ");
                    courseNames[i] = Console.ReadLine();

                    Console.Write($"Enter Grade for {courseNames[i]}: ");
                    courseGrades[i] = double.Parse(Console.ReadLine());
                }
            }

           
            Dictionary<string, int> gradeSummary = new Dictionary<string, int>();

           
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine($" Student Name: {studentName}");
            Console.WriteLine("========================================");
            Console.WriteLine("Course Name\t\tGrade\tEquivalent");

            double sum = 0;
            double maxGrade = courseGrades[0];
            double minGrade = courseGrades[0];

            for (int i = 0; i < courseNames.Length; i++)
            {
                double grade = courseGrades[i];
                string equivalent = GetEquivalent(grade);

               
                if (gradeSummary.ContainsKey(equivalent))
                    gradeSummary[equivalent]++;
                else
                    gradeSummary[equivalent] = 1;

              
                maxGrade = Math.Max(maxGrade, grade);
                minGrade = Math.Min(minGrade, grade);

                sum += grade;

               
                SetColor(equivalent);
                Console.WriteLine($"{courseNames[i],-20} | {grade,5} | {equivalent}");
                Console.ResetColor();
            }

            double average = sum / courseNames.Length;
            double overall = Math.Round(average, 2);
            string overallEquivalent = GetEquivalent(overall);

            Console.WriteLine("========================================");
            Console.WriteLine($"Maximum Grade: {maxGrade}");
            Console.WriteLine($"Minimum Grade: {minGrade}");
            Console.WriteLine($"Average Grade: {average:F2}");
            Console.WriteLine($"Overall Grade: {overall}");

            SetColor(overallEquivalent);
            Console.WriteLine($"Equivalent Grade: {overallEquivalent}");
            Console.ResetColor();

            Console.WriteLine("========================================");
            Console.WriteLine($"Author: {author}");

            
            Console.WriteLine("\nGrade Summary:");
            foreach (var kvp in gradeSummary)
            {
                SetColor(kvp.Key);
                Console.WriteLine($"{kvp.Key,-15} : {kvp.Value}");
                Console.ResetColor();
            }

           
            Console.WriteLine("\nPress X to exit...");
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.X)
                {
                    Console.WriteLine("Program Ended. Goodbye!");
                    break;
                }
            }
        }

       
        static string GetEquivalent(double grade)
        {
            if (grade >= 1.00 && grade <= 1.24) return "Excellent";
            else if (grade >= 1.25 && grade <= 1.49) return "Very Good";
            else if (grade >= 1.50 && grade <= 1.74) return "Very Good";
            else if (grade >= 1.75 && grade <= 1.99) return "Very Good";
            else if (grade >= 2.00 && grade <= 2.24) return "Satisfactory";
            else if (grade >= 2.25 && grade <= 2.49) return "Satisfactory";
            else if (grade >= 2.50 && grade <= 2.74) return "Satisfactory";
            else if (grade >= 2.75 && grade <= 2.99) return "Satisfactory";
            else if (grade == 3.00) return "Fair";
            else if (grade > 3.00 && grade <= 5.00) return "Fair";
            else return "Invalid/No Equivalent";
        }

       
        static void SetColor(string equivalent)
        {
            switch (equivalent)
            {
                case "Excellent":
                case "Very Good":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "Satisfactory":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "Fair":
                case "Pass":
                case "Barely Passing":
                case "Fail":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ResetColor(); 
                    break;
            }
        }
    }
}
