using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Gonzaga : Student
    {
        public override void Run()
        {
            string authorName = "Gonzaga";

            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
            Console.Clear();
            Thread.Sleep(2000);
            Console.WriteLine("STARTING...");
            Thread.Sleep(2000);
            Console.Clear();

            Console.Write("Enter student name: ");
            string studentName = Console.ReadLine();

            Console.Write("Enter number of courses: ");
            int courseCount = int.Parse(Console.ReadLine());

            string[] courseNames = new string[courseCount];
            double[] courseGrades = new double[courseCount];
            int[] courseUnits = new int[courseCount];
            Console.WriteLine("CLEARING...");
            Thread.Sleep(1000);
            Console.Clear();
            Thread.Sleep(1000);

            for (int i = 0; i < courseCount; i++)
            {
                Console.WriteLine("[" + studentName + "]");
                Console.Write($"Enter course name: ");
                courseNames[i] = Console.ReadLine();

                while (true)
                {
                    Console.Write($"Enter grade for [{courseNames[i]}]: ");
                    courseGrades[i] = double.Parse(Console.ReadLine());
                    if (courseGrades[i] > 100)
                    {
                        Console.WriteLine("Please enter a valid grade.");
                    }
                    else
                    {
                        break;
                    }
                }

                Console.Write($"Enter number of units for [{courseNames[i]}]: ");
                courseUnits[i] = int.Parse(Console.ReadLine());
                Console.Clear();
            }

            Console.Clear();
            Console.WriteLine("-~-~-~ Report Card ~-~-~-");
            Console.WriteLine($"Student Name: {studentName}\n");

            double maxGrade = courseGrades[0];
            double minGrade = courseGrades[0];
            double sumGrades = 0;
            double weightedSum = 0;
            int totalUnits = 0;

            Console.WriteLine("Course Name\t\tGrades\tUnits\tEquivalent");
            Console.WriteLine("-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-");

            for (int i = 0; i < courseCount; i++)
            {
                maxGrade = Math.Max(maxGrade, courseGrades[i]);
                minGrade = Math.Min(minGrade, courseGrades[i]);
                sumGrades += courseGrades[i];

                float equivalent;
                if (courseGrades[i] >= 97.5)
                {
                    equivalent = 1f;
                }
                else if (courseGrades[i] >= 94.5)
                {
                    equivalent = 1.25f;
                }
                else if (courseGrades[i] >= 91.5)
                {
                    equivalent = 1.5f;
                }
                else if (courseGrades[i] >= 86.5)
                {
                    equivalent = 1.75f;
                }
                else if (courseGrades[i] >= 81.5)
                {
                    equivalent = 2f;
                }
                else if (courseGrades[i] >= 76)
                {
                    equivalent = 2.25f;
                }
                else if (courseGrades[i] >= 70.5)
                {
                    equivalent = 2.5f;
                }
                else if (courseGrades[i] >= 65)
                {
                    equivalent = 2.75f;
                }
                else if (courseGrades[i] >= 59.5)
                {
                    equivalent = 3f;
                }
                else
                {
                    equivalent = 5f;
                }

                weightedSum += equivalent * courseUnits[i];
                totalUnits += courseUnits[i];

                Console.WriteLine($"{courseNames[i],-18} | {courseGrades[i],5} | {courseUnits[i],3} | {equivalent}");
            }

            double averageGrade = sumGrades / courseCount;
            averageGrade = Math.Round(averageGrade, 2);

            double gpa = weightedSum / totalUnits;
            gpa = Math.Round(gpa, 2);

            string equiba = "";
            switch (gpa)
            {
                case <= 1.25:
                    equiba = "Pwede ka na kunin ni Lord";
                    break;
                case <= 1.75:
                    equiba = "Very nice";
                    break;
                case <= 2.25:
                    equiba = "Mataas na rin to";
                    break;
                case <= 2.75:
                    equiba = "Tanggal ka na sa president's list";
                    break;
                case <= 3:
                    equiba = "Kahit tres lang";
                    break;
                default:
                    equiba = "BAGSAK!";
                    break;
            }

            Console.WriteLine("\n-~-~-~ Report Card ~-~-~-");
            Console.WriteLine($"Maximum Grade: {maxGrade}");
            Console.WriteLine($"Minimum Grade: {minGrade}");
            Console.WriteLine($"Average Grade: {averageGrade}");
            Console.WriteLine($"Overall Grade (GPA): {gpa}");
            Console.WriteLine($"Equivalent Grade: {equiba}");

            Console.WriteLine($"\nAuthor: {authorName}");
            Console.ReadKey();

        }

    }
}

