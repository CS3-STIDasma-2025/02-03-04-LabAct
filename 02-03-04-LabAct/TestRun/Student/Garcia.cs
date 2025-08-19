using System;
using System.Collections.Specialized;
using System.Linq;

namespace TestRun.Student
{
    internal class Garcia : Student
    {
        public override void Run()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("   STUDENT GRADE CALCULATOR SYSTEM");
            Console.WriteLine("=======================================");
            Console.WriteLine("Instructions:");
            Console.WriteLine("1. Enter your name.");
            Console.WriteLine("2. Enter the number of subjects you want to input.");
            Console.WriteLine("3. Input each subject name and grade.");
            Console.WriteLine("4. Results will be calculated automatically.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.Clear();

            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();

            Console.Write("Enter the number of courses: ");
            int n = int.Parse(Console.ReadLine());

            string[] courses = new string[n];
            double[] grades = new double[n];

            Console.Clear();

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter course name #{i + 1}: ");
                courses[i] = Console.ReadLine();

                Console.Write($"Enter grade for {courses[i]}: ");
                grades[i] = double.Parse(Console.ReadLine());
            }

            Console.Clear();

            Console.WriteLine("=======================================");
            Console.WriteLine("           STUDENT GRADE REPORT        ");
            Console.WriteLine("=======================================");
            Console.WriteLine($"Student Name: {studentName}");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Course Name\t|\tGrade\t|\tEquivalent");
            Console.WriteLine("---------------------------------------");

            int maxIndex = 0, minIndex = 0;
            double maxGrade = grades[0];
            double minGrade = grades[0];
            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                string equivalent = GetGradeDescription(grades[i]);
                Console.WriteLine($"{courses[i],-16} | {grades[i],-5} | {equivalent}");

                if (grades[i] == 5.0)
                {
                    Console.WriteLine("A failing grade (5.0) was detected. Stopping calculation early.");
                    break;
                }

                if (grades[i] > maxGrade)
                {
                    maxGrade = grades[i];
                    maxIndex = i;
                }

                if (grades[i] < minGrade)
                {
                    minGrade = grades[i];
                    minIndex = i;
                }

                sum += grades[i];
            }

            double avg = Math.Round(sum / n, 2);
            string overallEquivalent = GetGradeDescription(avg);

            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Maximum Grade: {maxGrade} in {courses[maxIndex]}");
            Console.WriteLine($"Minimum Grade: {minGrade} in {courses[minIndex]}");
            Console.WriteLine($"Average Grade: {avg}");
            Console.WriteLine($"Overall Grade: {avg}");
            Console.WriteLine($"Equivalent Grade: {overallEquivalent}");
            Console.WriteLine("=======================================");
            Console.WriteLine("Author: John Guiller R. Garcia");
            Console.WriteLine("=======================================");
        }

        static string GetGradeDescription(double grade)
        {
            if (grade >= 97.49) return "1.00 | Excellent";
            else if (grade >= 95.49) return "1.25 | Very Good";
            else if (grade >= 91.49) return "1.50 | Good";
            else if (grade >= 86.49) return "1.75 | Fair";
            else if (grade >= 81.49) return "2.00 | Satisfactory Fair";
            else if (grade >= 75.49) return "2.25 | Satisfied";
            else if (grade >= 70.49) return "2.50 | Passed";
            else if (grade >= 65.49) return "2.75 | Barely passed";
            else if (grade >= 59.49) return "3.00 | Terrible";
            else if (grade >= 55.49) return "4.00 | Terrible";
            else if (grade >= 51.49) return "5.00 | Worst";
            else return "Failed";
        }
    }
}
