using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestRun.Student
{
    internal class Cabal : Student
    {
        public override void Run()
        {


            Console.WriteLine("Author: John Albert L. Cabal\n");
            Console.WriteLine("====Grade Calculator====");
            Console.WriteLine("Instructions");
            Console.WriteLine("1. Enter Full Name");
            Console.WriteLine("2  Enter number of courses taken");
            Console.WriteLine("3. Enter course name and grade");
            Console.WriteLine();

            

            Console.Write("Enter Student name: ");
            string StudentName = Console.ReadLine();

            bool correct = false;
            int numCourse = 0;

            while (!correct)
            {
                Console.Write("Enter number of courses: ");
                string input = Console.ReadLine();

                // check if input is a number
                if (int.TryParse(input, out numCourse))
                {
                    correct = true; 
                }
                else
                {
                    Console.WriteLine("That is not a number. Please try again.\n");
                }
            }

            string[] courseNames = new string[numCourse];
            double[] grades = new double[numCourse];

            // Input loop
            for (int i = 0; i < numCourse; i++)
            {

                    // ✅ Ask for Course Name (must not be a number)
                    while (true)
                    {
                        Console.Write($"Enter Course {i + 1} Name: ");
                        string inputName = Console.ReadLine();

                        // check if the name is a number
                        if (double.TryParse(inputName, out _))
                        {
                            Console.WriteLine("Invalid input. Course name cannot be a number. Try again.\n");
                        }
                        else
                        {
                            courseNames[i] = inputName;
                            break; 
                        }
                    }

                   
                    while (true)
                    {
                        Console.Write($"Enter Grade for {courseNames[i]}: ");
                        string inputGrade = Console.ReadLine();

                        if (double.TryParse(inputGrade, out double grade))
                        {
                            grades[i] = grade;
                            break; 
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a number for the grade.\n");
                        }
                    }

                }

            Console.Clear();
            Console.WriteLine("=== Grade Report ===");
            Console.WriteLine($"Student: {StudentName}");
            Console.WriteLine();

            double sum = 0;
            double maxGrade = grades[0];
            double minGrade = grades[0];

            for (int i = 0; i < numCourse; i++)
            {
                string equivalent = GetEquivalent(grades[i]);
                Console.WriteLine($"{courseNames[i]} | {grades[i]} | {equivalent}");
                sum += grades[i];

                maxGrade = Math.Max(maxGrade, grades[i]);
                minGrade = Math.Min(minGrade, grades[i]);

                if (grades[i] < 1 || grades[i] > 3)
                {
                    Console.WriteLine("Invalid grade entered. Breaking process.");
                    break; 
                }
            }

            double average = Math.Round(sum / numCourse, 2);
            string overallEquivalent = GetEquivalent(average);
            static string GetEquivalent(double grade)
            {
                if (grade >= 1.0 && grade < 1.25) return "Excellent";
                else if (grade >= 1.25 && grade < 1.5) return "Superior";
                else if (grade >= 1.5 && grade < 1.75) return "Very Good";
                else if (grade >= 1.75 && grade < 2.0) return "Good";
                else if (grade >= 2.0 && grade < 2.25) return "Above Average";
                else if (grade >= 2.25 && grade < 2.5) return "Average";
                else if (grade >= 2.5 && grade < 2.75) return "Satisfactory";
                else if (grade >= 2.75 && grade < 3.0) return "Passing";
                else if (grade == 3.0) return "Barely Passing";
                else return "Invalid Grade";
            }

            //Results
            Console.WriteLine("=====================================");
            Console.WriteLine("            GRADE REPORT             ");
            Console.WriteLine("=====================================");
            Console.WriteLine($"Student: {StudentName}");

            Console.WriteLine("\n=== Summary ===");
            Console.WriteLine($"Maximum Grade: {maxGrade}");
            Console.WriteLine($"Minimum Grade: {minGrade}");
            Console.WriteLine($"Average Grade: {average}");
            Console.WriteLine($"Overall Grade: {average}");
            Console.WriteLine($"Equivalent Grade: {overallEquivalent}");

            Console.WriteLine("\nAuthor: John Albert L. Cabal");



           
        }




        }
    }


