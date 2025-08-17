using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Template : Student
    {
        public override void Run()
        {
            Console.WriteLine(" Enter Students Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("\n\n\n  Welcome To STI-Dasmarinas: " + name);

            Console.WriteLine("\n\n\n Enter the Number of Courses: ");
            int courses = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n\n\n Number of Courses: " + courses);

            string[] nameCourse = new string[courses];
            double[] grade = new double[courses];
            for (int i = 0; i < courses; i++)
            {
                Console.WriteLine($"\n\n\n  Enter the Courses Name {i + 1}: ");
                nameCourse[i] = Console.ReadLine();
                Console.WriteLine($"\n\n\n  Enter the Grade for {nameCourse[i]}: ");
                grade[i] = Convert.ToDouble(Console.ReadLine());

                if (grade[i] < 0 || grade[i] > 100)
                {
                    Console.WriteLine(" Invalid Grade! ");
                    break;
                }


            }
            double[] equivalent = new double[courses];
            for (int i = 0; i < courses; i++)
            {
                if (grade[i] >= 97.5 && grade[i] <= 100)
                {
                    equivalent[i] = 1.0;
                }
                else if (grade[i] >= 94.5 && grade[i] <= 97.49)
                {
                    equivalent[i] = 1.25;
                }
                else if (grade[i] >= 91.5 && grade[i] <= 94.49)
                {
                    equivalent[i] = 1.5;
                }
                else if (grade[i] >= 86.5 && grade[i] <= 91.49)
                {
                    equivalent[i] = 1.75;
                }
                else if (grade[i] >= 81.5 && grade[i] <= 86.49)
                {
                    equivalent[i] = 2.0;
                }
                else if (grade[i] >= 76 && grade[i] <= 81.49)
                {
                    equivalent[i] = 2.25;
                }
                else if (grade[i] >= 70.5 && grade[i] <= 75.99)
                {
                    equivalent[i] = 2.5;
                }
                else if (grade[i] >= 65 && grade[i] <= 70.49)
                {
                    equivalent[i] = 2.75;
                }
                else if (grade[i] >= 59.5 && grade[i] <= 64.99)
                {
                    equivalent[i] = 3.0;
                }
                else
                {
                    equivalent[i] = 5.0;
                }
            }
            double maximumGrade = grade[0];
            double minimumGrade = grade[0];

            double sum = 0;
            foreach (double g in grade)
            {
                sum += g;
                maximumGrade = Math.Max(maximumGrade, g);
                minimumGrade = Math.Min(minimumGrade, g);
            }
            double average = sum / courses;
            double overall = Math.Round(average, 2);

            double overallEquivalent;
                if (overall >= 97.5 && overall <= 100)
                {
                    overallEquivalent = 1.0;
                }
                else if (overall >= 94.5)
                {
                    overallEquivalent = 1.25;
                }
                else if (overall >= 91.5)
                {
                    overallEquivalent = 1.5;
                }
                else if (overall >= 86.5)
                {
                    overallEquivalent = 1.75;
                }
                else if (overall >= 81.5)
                {
                    overallEquivalent = 2.0;
                }
                else if (overall >= 76)
                {
                    overallEquivalent = 2.25;
                }
                else if (overall >= 70.5)
                {
                    overallEquivalent = 2.5;
                }
                else if (overall >= 65.5)
                {
                    overallEquivalent = 2.75;
                }
                else if (overall >= 59.5)
                {
                    overallEquivalent = 3.0;
                }
                else
                {
                    overallEquivalent = 5.0;
                }
            Console.WriteLine("\n\n\n");
            for (int i = 0; i < courses; i++) 
            {              
                Console.WriteLine($"\n  {nameCourse[i]}|{grade[i]}|{equivalent[i]}");
            }
            Console.WriteLine($"\n\n\n {name}'s Grades: ");
            Console.WriteLine("\n Maximum Grade: " + maximumGrade);
            Console.WriteLine(" Minimum Grade: " + minimumGrade);
            Console.WriteLine(" Average Grade: " + average);
            Console.WriteLine(" Overall Grade: " + overall);
            Console.WriteLine(" Equivalent Grade: " + overallEquivalent);
            Console.WriteLine("\n\n\n Thank you for using the STI-Dasmarinas Grade Calculator!");
            Console.WriteLine("\n\n\n Author: Balajadia");

        }
    }
}






//THIS IS A TEMPLATE FILE 

