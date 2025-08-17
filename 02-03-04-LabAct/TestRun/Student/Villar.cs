using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Villar : Student
    {
        public override void Run()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("       STUDENT GRADE CALCULATOR        ");
            Console.WriteLine("=======================================");

            Console.WriteLine();

            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();

            Console.Write("Enter number of courses: ");
            int n = Convert.ToInt32(Console.ReadLine());

            string[] courseNames = new string[n];
            int[] rawGrades = new int[n];
            double[] equivalents = new double[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                Console.WriteLine("--- Course #" + (i + 1) + " ---");
                Console.Write("Enter course name: ");
                courseNames[i] = Console.ReadLine();

                Console.Write("Enter grade (0-100): ");
                rawGrades[i] = Convert.ToInt32(Console.ReadLine());

                equivalents[i] = ConvertToEquivalent(rawGrades[i]);
            }

            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("            GRADE REPORT               ");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.WriteLine("Student Name: " + studentName);
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(courseNames[i] + " | " + rawGrades[i] + " | " + equivalents[i]);
            }

            int maxGrade = rawGrades[0];
            int minGrade = rawGrades[0];
            int total = 0;

            foreach (int g in rawGrades)
            {
                maxGrade = Math.Max(maxGrade, g);
                minGrade = Math.Min(minGrade, g);
                total += g;

                if (g < 50)
                {
                    Console.WriteLine();
                    Console.WriteLine("One failing grade detected. Ending early...");
                    break;
                }
            }

            double average = (double)total / n;
            double overall = Math.Round(ConvertToEquivalent((int)average), 2);

            Console.WriteLine();
            Console.WriteLine("=======================================");
            Console.WriteLine("               RESULTS                 ");
            Console.WriteLine("=======================================");
            Console.WriteLine("Maximum Grade: " + maxGrade);
            Console.WriteLine("Minimum Grade: " + minGrade);
            Console.WriteLine("Average Grade: " + average);
            Console.WriteLine("Overall Grade: " + overall);
            Console.WriteLine("Equivalent Grade: " + overall);
            Console.WriteLine();
            Console.WriteLine("Author: Villar");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static float ConvertToEquivalent(float grade)
        {
            if (grade >= 97.5) return 1.0f;
            else if (grade >= 94.5) return 1.25f;
            else if (grade >= 91.5) return 1.5f;
            else if (grade >= 86.5) return 1.75f;
            else if (grade >= 81.5) return 2.0f;
            else if (grade >= 76) return 2.25f;
            else if (grade >= 70.5) return 2.5f;
            else if (grade >= 65) return 2.75f;
            else if (grade >= 59.5) return 3f;
            else return 5.0f;
        }
    }
}
//THIS IS A TEMPLATE FILE 
