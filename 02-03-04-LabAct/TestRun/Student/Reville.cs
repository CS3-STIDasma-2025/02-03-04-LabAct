using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Reville : Student
    {
        public override void Run()
        {
            //Instruction
            Console.WriteLine("=======================================");
            Console.WriteLine("       STUDENT GRADE CALCULATOR        ");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.WriteLine("INSTRUCTIONS:");
            Console.WriteLine("1. Enter your name.");
            Console.WriteLine("2. Enter how many courses you have.");
            Console.WriteLine("3. For each course, enter the course name and the grade (0–100).");
            Console.WriteLine("4. The program will show a grade report with raw and equivalent grades.");
            Console.WriteLine("5. If any grade is below 50, the program will stop early.");
            Console.WriteLine("Press Enter To Continue...");
            Console.ReadKey();
            Console.Clear();

            //Student name
            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();

            //Number of courses
            Console.Write("Enter number of courses you have: ");
            int n = Convert.ToInt32(Console.ReadLine());

            string[] courseNames = new string[n];
            int[] OrigGrades = new int[n];
            double[] equivalents = new double[n];

            //Input loop for the Course
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                Console.WriteLine(">Course #" + (i + 1));
                Console.Write("Enter course name: ");
                courseNames[i] = Console.ReadLine();

                Console.Write("Enter grade (0-100): ");
                OrigGrades[i] = Convert.ToInt32(Console.ReadLine());

                equivalents[i] = ConvertToEquivalent(OrigGrades[i]);
            }

            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("            GRADE REPORT               ");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.WriteLine("Student Name: " + studentName);
            Console.WriteLine();
            Console.WriteLine("Course Name\t|\tOriginal Grade\t|\tEquivalent");
            Console.WriteLine("-------------------------------------------------");

            // Step 4: Show results for each course
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(courseNames[i] + "\t|\t" + OrigGrades[i] + "\t\t|\t" + equivalents[i]);
            }

            //Calculate Max, Min, Average
            int maxGrade = OrigGrades[0];
            int minGrade = OrigGrades[0];
            int total = 0;

            foreach (int g in OrigGrades)
            {
                maxGrade = Math.Max(maxGrade, g);
                minGrade = Math.Min(minGrade, g);
                total += g;

                if (g < 50) 
                {
                    Console.WriteLine();
                    Console.WriteLine("Failing Grade");
                    break;
                }
            }

            double average = (double)total / n;
            double overall = Math.Round(ConvertToEquivalent((int)average), 2);

            //Display summary
            Console.WriteLine();
            Console.WriteLine("=======================================");
            Console.WriteLine("               RESULTS                 ");
            Console.WriteLine("=======================================");
            Console.WriteLine("Maximum Grade: " + maxGrade);
            Console.WriteLine("Minimum Grade: " + minGrade);
            Console.WriteLine("Average Grade: " + Math.Round(average, 2));
            Console.WriteLine("Overall Grade (Equivalent): " + overall);
            Console.WriteLine();
            Console.WriteLine("Author: Reville");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        //Conversion
        static float ConvertToEquivalent(float grade)
        {
            if (grade >= 97) return 1.0f;
            else if (grade >= 94) return 1.25f;
            else if (grade >= 91) return 1.5f;
            else if (grade >= 86) return 1.75f;
            else if (grade >= 81) return 2.0f;
            else if (grade >= 76) return 2.25f;
            else if (grade >= 70) return 2.5f;
            else if (grade >= 65) return 2.75f;
            else if (grade >= 59) return 3f;
            else return 5.0f;
        }
    }
   
 }
//THIS IS A TEMPLATE FILE 
