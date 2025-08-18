using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Montante : Student
    {
        public override void Run()
        {
            Console.WriteLine("=== Grade Calculation Program ===");
            Console.WriteLine("Step 1: Enter your name.");
            Console.WriteLine("Step 2: Enter the number of courses.");
            Console.WriteLine("Step 3: Enter each course name and grade.");
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();

            Console.Clear();

            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();

            int courseCount;
            while (true)
            {
                Console.Write("Enter number of courses: ");
                if (int.TryParse(Console.ReadLine(), out courseCount) && courseCount > 0)
                    break;
                Console.WriteLine("Invalid input. Please enter a valid number greater than 0.");
            }

            string[] courseNames = new string[courseCount];
            double[] grades = new double[courseCount];

            for (int i = 0; i < courseCount; i++)
            {
                Console.Write($"Enter course name #{i + 1}: ");
                courseNames[i] = Console.ReadLine();

                while (true)
                {
                    Console.Write($"Enter grade for {courseNames[i]}: ");
                    if (double.TryParse(Console.ReadLine(), out grades[i]))
                        break;
                    Console.WriteLine("Invalid input. Please enter a numeric grade.");
                }
            }

            Console.Clear();

            double maxGrade = grades[0];
            double minGrade = grades[0];
            double sum = 0;

            foreach (double grade in grades)
            {
                maxGrade = Math.Max(maxGrade, grade);
                minGrade = Math.Min(minGrade, grade);
                sum += grade;
            }

            double average = sum / courseCount;
            double overallGrade = Math.Round(average, 2);
            string equivalent = GetEquivalent(overallGrade);

   
            Console.WriteLine("=== Student Grade Report ===");
            Console.WriteLine($"Student Name: {studentName}");
            Console.WriteLine("\nCourse Results:");
            Console.WriteLine("-------------------------------------");
            for (int i = 0; i < courseCount; i++)
            {
                Console.WriteLine($"{courseNames[i]} | {grades[i]} | {GetEquivalent(grades[i])}");
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Maximum Grade: {maxGrade}");
            Console.WriteLine($"Minimum Grade: {minGrade}");
            Console.WriteLine($"Average Grade: {Math.Round(average, 2)}");
            Console.WriteLine($"Overall Grade: {overallGrade}");
            Console.WriteLine($"Equivalent Grade: {equivalent}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Author: Trisha Montante");

            while (true)
            {
                Console.Write("\nType 'exit' to close the program: ");
                string command = Console.ReadLine();
                if (command.ToLower() == "exit")
                {
                    Console.WriteLine("Program terminated.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, please type 'exit' to close.");
                }
            }
        }

        private string GetEquivalent(double grade)
        {
            if (grade == 1) return "Excellent";
            else if (grade == 1.25) return "Very Good";
            else if (grade == 1.5) return "Good";
            else if (grade == 1.75) return "Satisfactory";
            else if (grade == 2) return "Average";
            else if (grade == 2.25) return "Fair";
            else if (grade == 2.5) return "Pass";
            else if (grade == 2.75) return "Barely Pass";
            else if (grade == 3) return "Conditional Pass";
            else return "Invalid Grade";
        }
    }
}