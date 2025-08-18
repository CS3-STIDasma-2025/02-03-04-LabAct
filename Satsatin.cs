using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Satsatin : Student
    {
        public override void Run()
        {
            Console.Title = "Grade Calculator Application";

            // Step-by-step instructions
            Console.WriteLine("=======================================");
            Console.WriteLine(" Welcome to the Grade Calculator!");
            Console.WriteLine("=======================================\n");
            Console.WriteLine("Instructions:");
            Console.WriteLine("1. Enter your full name.");
            Console.WriteLine("2. Enter the number of courses.");
            Console.WriteLine("3. Input course name and numeric grade.");
            Console.WriteLine("4. The system will show your results.\n");
            Console.WriteLine("Press any key to begin...");
            Console.ReadKey();
            Console.Clear();

            // Get student name
            Console.Write("Enter your full name: ");
            string studentName = Console.ReadLine();

            // Get number of courses
            int courseCount;
            while (true)
            {
                Console.Write("Enter number of courses: ");
                if (int.TryParse(Console.ReadLine(), out courseCount) && courseCount > 0)
                {
                    break; // Valid input, exit loop
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }
            }

            // Arrays to hold course names and grades
            string[] courseNames = new string[courseCount];
            double[] courseGrades = new double[courseCount];

            // Input course info
            for (int i = 0; i < courseCount; i++)
            {
                Console.Write($"\nEnter course #{i + 1} name: ");
                courseNames[i] = Console.ReadLine();

                while (true)
                {
                    Console.Write($"Enter grade for {courseNames[i]} (valid: 1, 1.25, 1.5, 1.75, 2, 2.25, 2.5, 2.75, 3): ");
                    if (double.TryParse(Console.ReadLine(), out double grade))
                    {
                        if (IsValidGrade(grade))
                        {
                            courseGrades[i] = grade;
                            break; // Valid grade, exit loop
                        }
                        else
                        {
                            Console.WriteLine("Invalid grade! Must be one of the specified values.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please enter a numeric grade.");
                    }
                }
            }

            Console.Clear();

            // Display report header
            Console.WriteLine("========== GRADE REPORT ==========");
            Console.WriteLine($"Student Name: {studentName}\n");
            Console.WriteLine($"{"Course",-25} {"Grade",8} {"Equivalent"}");
            Console.WriteLine("----------------------------------------------");

            // Show each course's info
            for (int i = 0; i < courseCount; i++)
            {
                string equivalent = GetGradeEquivalent(courseGrades[i]);
                Console.WriteLine($"{courseNames[i],-25} {courseGrades[i],8:0.00} {equivalent}");
            }

            // Calculate statistics
            double maxGrade = courseGrades[0];
            double minGrade = courseGrades[0];
            double sum = 0;

            foreach (double g in courseGrades)
            {
                maxGrade = Math.Max(maxGrade, g);
                minGrade = Math.Min(minGrade, g);
                sum += g;
            }

            double average = Math.Round(sum / courseCount, 2);
            string overallEquivalent = GetGradeEquivalent(average);

            // Display summary
            Console.WriteLine("\n========== SUMMARY ==========");
            Console.WriteLine($"Maximum Grade: {maxGrade:0.00}");
            Console.WriteLine($"Minimum Grade: {minGrade:0.00}");
            Console.WriteLine($"Average Grade: {average:0.00}");
            Console.WriteLine($"Overall Grade: {average:0.00}");
            Console.WriteLine($"Equivalent Grade: {overallEquivalent}");

            // Author credit
            Console.WriteLine("\nAuthor: Satsatin");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Helper: Check if grade is valid according to instruction
        private bool IsValidGrade(double grade)
        {
            double[] validGrades = { 1.00, 1.25, 1.50, 1.75, 2.00, 2.25, 2.50, 2.75, 3.00 };
            foreach (double g in validGrades)
            {
                if (Math.Abs(g - grade) < 0.001) // floating-point tolerance
                    return true;
            }
            return false;
        }

        // Convert numeric grade to equivalent keyword
        private string GetGradeEquivalent(double grade)
        {
            if (grade == 1.00) return "Excellent";
            else if (grade == 1.25 || grade == 1.50) return "Very Good";
            else if (grade == 1.75 || grade == 2.00) return "Good";
            else if (grade == 2.25 || grade == 2.50) return "Satisfactory";
            else if (grade == 2.75 || grade == 3.00) return "Passing";
            else return "Failed";
        }
    }
}



