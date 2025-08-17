using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Rana : Student
    {
        public override void Run()
        {
            // Function to center text in console
            void CenterText(string text)
            {
                int screenWidth = Console.WindowWidth;
                int stringWidth = text.Length;
                int spaces = (screenWidth - stringWidth) / 2;
                if (spaces < 0) spaces = 0;
                string spaceString = new string(' ', spaces);
                Console.WriteLine(spaceString + text);
            }

          // User should input the name first before proceeding
            Console.Clear();
            CenterText("==================================");
            CenterText("STUDENT REPORT");
            CenterText("==================================");
            Console.WriteLine();
            Console.WriteLine("Instructions: Put the necessary information below and make sure to enter the right format. The grade should be in percentage format. Type stop if you're done putting all of your courses.");

            Console.Write("\n Enter Student Name: ");
            string studentName = Console.ReadLine();

            Console.Clear();
            CenterText("-------------------------------------------------------------------");
            CenterText($"Welcome, {studentName}! Fill up the information needed below.");
            CenterText("-------------------------------------------------------------------\n");
            Console.WriteLine("Instructions: Type finish if you are done inputting all of your courses to see your final grade.\n");

            // Arrays to store and track the user's data
            string[] courses = new string[10];
            double[] gradesE = new double[10];
            int[] gradesP = new int[10];
            int count = 0;

            // Input loop
            for (int i = 0; i < courses.Length; i++)
            {
                Console.Write($"Enter Course Name #{i + 1}: ");
                string course = Console.ReadLine();

                if (course.ToLower() == "finish")
                {
                    Console.WriteLine("Stopping input...");
                    break;
                }

                // User should input their grade in integer format
                int gradeVal;
                while (true)
                {
                    Console.Write("Enter Grade: ");
                    string gradeInput = Console.ReadLine();

                    if (!int.TryParse(gradeInput, out gradeVal))
                    {
                        Console.WriteLine("Invalid grade. Try again.");
                        Thread.Sleep(1000);
                        continue;
                    }

                    if (gradeVal < 50 || gradeVal > 100)
                    {
                        Console.WriteLine("Invalid grade. Try again.");
                        Thread.Sleep(1000);
                        continue;
                    }

                    break;
                }

                double Eqgrade = Egrade(gradeVal);

                courses[count] = course;
                gradesE[count] = Eqgrade;
                gradesP[count] = gradeVal;
                count++;
                Console.WriteLine();
            }

            // Calculations for average and overall grade
            double maxGrade = gradesP[0];
            double minGrade = gradesP[0];
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                maxGrade = Math.Max(maxGrade, gradesP[i]);
                minGrade = Math.Min(minGrade, gradesP[i]);
                sum += gradesP[i]; 
            }

            double averagePercent = Math.Round(sum / count, 2);
            double overallPercent = averagePercent;
            double overallEquivalentGrade = Egrade(overallPercent);

            // Output
            Console.Clear();
            CenterText("==================================");
            CenterText("GRADE REPORT");
            CenterText("==================================");
            Console.WriteLine($"Student Name: {studentName}\n");
            Console.WriteLine("Course Name        |  Grade  | Equivalent grade");
            Console.WriteLine("----------------------------------------------------");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{courses[i],-18} | {gradesP[i],7} | {gradesE[i],10:0.00}");
            }

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Maximum Grade: {maxGrade}%");
            Console.WriteLine($"Minimum Grade: {minGrade}%");
            Console.WriteLine($"Average Grade: {averagePercent}%");
            Console.WriteLine($"Overall Grade: {overallPercent}%");
            Console.WriteLine($"Equivalent Grade: {overallEquivalentGrade:0.00}");
            Console.WriteLine($"Status: {(overallEquivalentGrade <= 3.00 ? "PASSED!" : "FAILED")}");
            Console.WriteLine("----------------------------------------------------\n\n");
            Console.WriteLine("Author by: Rana");
        }

        // Conversion from grade to grade equivalent
        static double Egrade(double g)
        {
            if (g >= 97.50 && g <= 100) return 1.00;
            else if (g >= 94.50 && g <= 97.49) return 1.25;
            else if (g >= 91.50 && g <= 94.49) return 1.50;
            else if (g >= 86.50 && g <= 91.49) return 1.75;
            else if (g >= 81.50 && g <= 86.49) return 2.00;
            else if (g >= 76.00 && g <= 81.49) return 2.25;
            else if (g >= 70.50 && g <= 75.99) return 2.50;
            else if (g >= 65.00 && g <= 70.49) return 2.75;
            else if (g >= 59.50 && g <= 64.99) return 3.00;
            else return 5.00;
        }

    }
   
 }


