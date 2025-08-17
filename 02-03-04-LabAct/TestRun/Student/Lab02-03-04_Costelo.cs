using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Costelo : Student
    {
        public override void Run()
        {
            Console.WriteLine("====  GRADE CALCULATOR =====");
            Console.Write("Enter Course Name: "); // Prompt the user for the course name
            string courseName = Console.ReadLine();
            Console.Clear();

            int numGrades;
            Console.WriteLine("==== GRADE CALCULATOR =====");
            Console.Write("How many grades will you enter? "); // Prompt the user for the number of grades
            while (!int.TryParse(Console.ReadLine(), out numGrades) || numGrades <= 0)
                Console.Clear();
            {
                Console.Write("Please enter a valid number of grades: "); // Ensure the input is a valid positive integer
            }
            Console.WriteLine($"Okii, let's enter your {numGrades} grades for {courseName}:"); // Inform the user about the number of grades to be entered
            Console.Clear();
            Console.WriteLine("====  GRADE CALCULATOR =====");
            var grades = new List<double>();

            for (int i = 0; i < numGrades; i++)
            {
                
                Console.Write($" Please Enter Your Grade #{i + 1}: "); // Prompt the user to enter each grade
                double grade;
                while (!double.TryParse(Console.ReadLine(), out grade) || grade < 0 || grade > 10)
                {
                    Console.Write("Please enter a valid grade (0–10): ");
                }   
                if (Math.Abs(grade - 5.00) < 0.001)
                {
                    Console.WriteLine("You entered a grade of 5.00, which is considered a failing grade.");
                    break; // If the grade is exactly 5.00, inform the user and stop entering grades

                }
                grades.Add(grade);
            }


            if (grades.Count > 0)
            {
                Console.WriteLine($"\n{grades.Count} grades were entered for {courseName}:"); // Display the number of grades entered
                Console.Clear();

                double sum = 0;
                foreach (double g in grades)
                {
                    sum += g;
                }
                double average = sum / grades.Count;

                double minGrade = grades.Min();
                double maxGrade = grades.Max();

                Console.WriteLine("\n=== Grade Summary ==="); // Print a summary of the grades entered
                Console.WriteLine($"Course: {courseName}"); // Display the course name
                Console.WriteLine("Grades entered:"); // List each grade with its index
                for (int i = 0; i < grades.Count; i++)
                {
                Console.WriteLine($"  [{i + 1}] {grades[i]:F2} => {GradeKeyword(grades[i])}");
                }

                Console.WriteLine($"Maximum Grade: {minGrade:F2}"); // Display the minimum grade
                Console.WriteLine($"Minimum Grade: {maxGrade:F2}"); // Display the maximum grade
                Console.WriteLine($"\nAverage Grade: {average:F2}"); // Calculate and display the average grade
                Console.WriteLine($"Overall Grade: {average:F2}"); // Display the overall grade
                Console.WriteLine($"Overall Equivalent: {GradeKeyword(average)}"); // Display the equivalent grade for the average
                Console.WriteLine("Authored By: Costelo, Aldrain Yrhon N. ");
                Console.WriteLine("End of the program.... ");
            }
            else
            {
                Console.WriteLine("End of the program..."); // Handle the case where no grades were entered or the user entered a failing grade

            }
        }
        static string GradeKeyword(double grade) // Convert the numeric grade to a string representation
        {
            if (grade == 1.0) return "1";
            else if (grade == 1.25) return "1.25";
            else if (grade == 1.5) return "1.5";
            else if (grade == 1.75) return "1.75";
            else if (grade == 2.0) return "2";
            else if (grade == 2.25) return "2.25";
            else if (grade == 2.5) return "2.5";
            else if (grade == 2.75) return "2.75";
            else if (grade == 3.0) return "3";
            else return "N/A";
        }
    }
}
