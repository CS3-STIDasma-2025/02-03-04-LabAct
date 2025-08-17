using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Pardillo : Student
    {
        public override void Run()
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("      Student Grade Calculation System");
            Console.WriteLine("=========================================\n");

            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();

            Console.Write("Enter number of courses: ");
            int courseCount = Convert.ToInt32(Console.ReadLine());

            string[] courses = new string[courseCount];
            double[] rawGrades = new double[courseCount];
            double[] equivalents = new double[courseCount];

            for (int i = 0; i < courseCount; i++)
            {
                Console.Write($"\nEnter Course {i + 1} Name: ");
                courses[i] = Console.ReadLine();

                Console.Write($"Enter Raw Grade for {courses[i]}: ");
                rawGrades[i] = Convert.ToDouble(Console.ReadLine());

                equivalents[i] = GetEquivalent(rawGrades[i]);
            }

            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine($"      Grade Report for {studentName}");
            Console.WriteLine("=========================================\n");

            Console.WriteLine("Course Name\t\t|\tRaw\t|\tEquivalent");
            double total = 0;

            for (int i = 0; i < courseCount; i++)
            {
                Console.WriteLine($"{courses[i],-20} | {rawGrades[i],-3} | {equivalents[i]}");
                total += equivalents[i];
            }

            double max = equivalents[0], min = equivalents[0];
            foreach (double g in equivalents)
            {
                max = Math.Max(max, g);
                min = Math.Min(min, g);
            }

            double average = total / courseCount;
            double overall = Math.Round(average, 2);

            Console.WriteLine("\n=========================================");
            Console.WriteLine($"Maximum Grade: {max}");
            Console.WriteLine($"Minimum Grade: {min}");
            Console.WriteLine($"Average Grade: {Math.Round(average, 2)}");
            Console.WriteLine($"Overall Grade: {overall}");
            Console.WriteLine($"Equivalent Grade: {overall}");
            Console.WriteLine("=========================================");
            Console.WriteLine("Author: Kharlsten D. Pardillo\n");

            Console.WriteLine("Press 'X' to exit...");
            while (true)
            {
                string exit = Console.ReadLine();
                if (exit.ToUpper() == "X")
                {
                    Console.WriteLine("Program terminated. Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Press 'X' to exit.");
                }
            }
        }

        static double GetEquivalent(double n)
        {
            if (n >= 97.5) return 1f;
            else if (n >= 94.5) return 1.25f;
            else if (n >= 91.5) return 1.5f;
            else if (n >= 86.5) return 1.75f;
            else if (n >= 81.5) return 2f;
            else if (n >= 76) return 2.25f;
            else if (n >= 70.5) return 2.5f;
            else if (n >= 65) return 2.75f;
            else if (n >= 59.5) return 3f;
            else return 5f;
        }
    }
}
//THIS IS A TEMPLATE FILE 
