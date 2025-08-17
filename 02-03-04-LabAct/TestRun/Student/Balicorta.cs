using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Balicorta : Student
    {
        public override void Run()
        {
            // Ask for student details
            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();

            Console.Write("Enter Course Name: ");
            string courseName = Console.ReadLine();

            Console.Write("How many grades will you enter? ");
            int n = int.Parse(Console.ReadLine());

            double[] grades = new double[n];

            // Input grades
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter grade {i + 1}: ");
                grades[i] = double.Parse(Console.ReadLine());
            }

            // Calculations
            double max = grades[0];
            double min = grades[0];
            double sum = 0;

            Console.WriteLine("\n--- Grade Report ---");
            Console.WriteLine($"Student: {studentName}");
            Console.WriteLine($"Course: {courseName}");
            Console.WriteLine("\nGrades and Keywords:");
            Console.WriteLine("-------------------------");

            foreach (double g in grades)
            {
                sum += g;
                if (g > max) max = g;
                if (g < min) min = g;

                string keyword;
                if (g == 1) keyword = "Excellent";
                else if (g == 1.25) keyword = "Very Good";
                else if (g == 1.5) keyword = "Good";
                else if (g == 1.75) keyword = "Satisfactory";
                else if (g == 2) keyword = "Fair";
                else if (g == 2.25) keyword = "Average";
                else if (g == 2.5) keyword = "Below Average";
                else if (g == 2.75) keyword = "Poor";
                else if (g == 3) keyword = "Pass";
                else keyword = "Invalid Grade";

                Console.WriteLine($"Grade: {g} -> {keyword}");
            }

            double average = sum / n;

            // Results
            Console.WriteLine("\n--- Results ---");
            Console.WriteLine($"Maximum Grade: {max}");
            Console.WriteLine($"Minimum Grade: {min}");
            Console.WriteLine($"Average Grade: {average:F2}");
            Console.WriteLine("Author by: " + "Balicorta");
        }
    }
}

//THIS IS A TEMPLATE FILE 
