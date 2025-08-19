using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Marasigan : Student
    {
        public override void Run()
        {
            Console.WriteLine("Authored by: King");
            {
                    {
                        Console.Title = "Grade Report Generator";
                        Console.WriteLine("=======================================");
                        Console.WriteLine("        GRADE REPORT GENERATOR         ");
                        Console.WriteLine("=======================================");
                        Console.WriteLine("Instructions:");
                        Console.WriteLine("1. Enter student name.");
                        Console.WriteLine("2. Enter number of course.");
                        Console.WriteLine("3. For each course, enter course name and grade.");
                        Console.WriteLine("4. Grades must be between 65 and 100.");
                        Console.WriteLine("5. Grade equivalents are based on a 1.0 to 3.0 scale.");
                        Console.WriteLine("Press any key to start...");
                        Console.ReadKey();
                        Console.Clear();

                        Console.Write("Enter Student Name: ");
                        string studentName = Console.ReadLine();

                        Console.Write("How many Subject: ");
                        int numberOfCourses = int.Parse(Console.ReadLine());

                        string[] courseNames = new string[numberOfCourses];
                        double[] courseGrades = new double[numberOfCourses];
                        double[] courseEquivalents = new double[numberOfCourses];

                        for (int i = 0; i < numberOfCourses; i++)
                        {
                            Console.WriteLine($"\ #{i + 1}");

                            Console.Write("Enter Subject name: ");
                            courseNames[i] = Console.ReadLine();

                            while (true)
                            {
                                Console.Write("Enter grade (65–100): ");
                                double grade = double.Parse(Console.ReadLine());

                                if (grade >= 65 && grade <= 100)
                                {
                                    courseGrades[i] = grade;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid grade. Please enter a grade between 65 and 100.");
                                }
                            }

                            double g = courseGrades[i];
                            if (g >= 97) courseEquivalents[i] = 1.0;
                            else if (g >= 94) courseEquivalents[i] = 1.25;
                            else if (g >= 91) courseEquivalents[i] = 1.5;
                            else if (g >= 88) courseEquivalents[i] = 1.75;
                            else if (g >= 85) courseEquivalents[i] = 2.0;
                            else if (g >= 82) courseEquivalents[i] = 2.25;
                            else if (g >= 79) courseEquivalents[i] = 2.5;
                            else if (g >= 75) courseEquivalents[i] = 2.75;
                            else courseEquivalents[i] = 3.0;
                        }

                        Console.Clear();

                        Console.WriteLine("=======================================");
                        Console.WriteLine("           GRADE REPORT CARD           ");
                        Console.WriteLine("=======================================");
                        Console.WriteLine($"Student Name: {studentName}\n");

                        Console.WriteLine("Course Name\tGrade\tEquivalent");
                        Console.WriteLine("---------------------------------------");

                        double sum = 0;
                        for (int i = 0; i < numberOfCourses; i++)
                        {
                            Console.WriteLine($"{courseNames[i]}      {courseGrades[i]}{courseEquivalents[i]}");
                            sum += courseGrades[i];
                        }

                        double max = courseGrades[0];
                        double min = courseGrades[0];
                        for (int i = 1; i < numberOfCourses; i++)
                        {
                            max = Math.Max(max, courseGrades[i]);
                            min = Math.Min(min, courseGrades[i]);
                        }

                        {
                            double average = Math.Round(sum / numberOfCourses, 2);
                            double overallEquivalent;

                            if (average >= 97) overallEquivalent = 1.0;
                            else if (average >= 94) overallEquivalent = 1.25;
                            else if (average >= 91) overallEquivalent = 1.5;
                            else if (average >= 88) overallEquivalent = 1.75;
                            else if (average >= 85) overallEquivalent = 2.0;
                            else if (average >= 82) overallEquivalent = 2.25;
                            else if (average >= 79) overallEquivalent = 2.5;
                            else if (average >= 75) overallEquivalent = 2.75;
                            else overallEquivalent = 3.0;

                            Console.WriteLine("\n=========== SUMMARY ===========");
                            Console.WriteLine($"Maximum Grade     : {max}");
                            Console.WriteLine($"Minimum Grade     : {min}");
                            Console.WriteLine($"Average Grade     : {average}");
                            Console.WriteLine($"Overall Grade     : {average}");
                            Console.WriteLine($"Equivalent Grade  : {overallEquivalent}");
                            Console.WriteLine("===============================");

                            Console.WriteLine("\nAuthor: King Justine Marasigan");
                            Console.WriteLine("Press any key to exit...");
                            Console.ReadKey();
                        }
                    }
            }
        }
    }
}            