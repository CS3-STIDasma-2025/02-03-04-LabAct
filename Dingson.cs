using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Dingson : Student
    {
        public override void Run()
        {
            Console.WriteLine("This program will calculate your grades in the said subject.\n");

            Console.Write("Enter your name: ");
            string studentName = Console.ReadLine();

            Console.Write("Enter your course: ");
            string courseName = Console.ReadLine();

            Console.Write("Enter the subject: ");
            string subjectName = Console.ReadLine();

            Console.WriteLine("Enter your grades:");

            double[] grades = new double[4];
            string[] terms = { "Prelim", "Midterm", "Prefinal", "Finals" };

            for (int i = 0; i < grades.Length; i++)
            {
                Console.Write($"{terms[i]}: ");
                grades[i] = Convert.ToDouble(Console.ReadLine());
            }

            double maxGrade = grades[0];
            double minGrade = grades[0];
            double sum = 0;

            foreach (double g in grades)
            {
                if (g > maxGrade) maxGrade = g;
                if (g < minGrade) minGrade = g;
                sum += g;
            }

            double average = sum / grades.Length;

            double overall = (grades[0] * 0.20) + (grades[1] * 0.20) + (grades[2] * 0.20) + (grades[3] * 0.40);
            overall = Math.Round(overall, 2, MidpointRounding.AwayFromZero);

            Console.Clear();

            Console.WriteLine(studentName);
            Console.WriteLine(courseName);
            Console.WriteLine("\n----- Your Final Grades -----");
            Console.WriteLine("\nSubject: " + subjectName);

            //Table
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("| Term      |  Grade  |  Equivalent  |");
            Console.WriteLine("--------------------------------------");
            for (int i = 0; i < grades.Length; i++)
            {
                string eq = GetEquivalent(grades[i]);
                Console.WriteLine($"| {terms[i],-9} | {grades[i],6:F2}  | {eq,-12} |");
            }
            Console.WriteLine("--------------------------------------");

            string overallEq = GetEquivalent(overall);
            Console.WriteLine($"| Equivalent Grade:             {overallEq} |");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"\n{subjectName} | {average:F2} | {overallEq}");

            Console.WriteLine($"\nMaximum Grade: {maxGrade}");
            Console.WriteLine($"Minimum Grade: {minGrade}");
            Console.WriteLine($"Overall Grade: {overall}");

            //ME
            Console.WriteLine("\n");
            Console.WriteLine("\nAuthor: Danaia Isabel C. Dingson");

            while (true)
            {
                Console.Write("\nType 'exit' to close the program: ");
                string command = Console.ReadLine();
                if (command.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }
            }
        }
        static string GetEquivalent(double grade)
        {
            if (grade >= 97.50 && grade <= 100) return "1.00";
            else if (grade >= 94.50) return "1.25";
            else if (grade >= 91.50) return "1.50";
            else if (grade >= 86.50) return "1.75";
            else if (grade >= 81.50) return "2.00";
            else if (grade >= 76.00) return "2.25";
            else if (grade >= 70.50) return "2.50";
            else if (grade >= 65.00) return "2.75";
            else if (grade >= 59.50) return "3.00";
            else return "5.00";
        }
    }

            
        }
   
    

//THIS IS A TEMPLATE FILE 
