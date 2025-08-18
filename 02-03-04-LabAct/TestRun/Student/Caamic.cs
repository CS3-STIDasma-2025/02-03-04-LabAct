using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Caamic : Student
    {
        public override void Run()
        {
            Console.WriteLine("========= Grade Calculator =========\n");

            //Name
            Console.Write("Please Enter your Name: ");
            string studentName = Console.ReadLine();

            Console.WriteLine();

            // Number of Courses
            Console.Write("How many Courses did you Take?: ");

            int coursesNum;
            while (!int.TryParse(Console.ReadLine(), out coursesNum) || coursesNum <= 0)// Kung Wrongg Input Inilagay nila
            {
                Console.WriteLine();
                Console.Write("!------------ Invalid Input ------------!\n");
                Console.Write("Please Enter the Valid Number of Courses: ");
            }

            string[] courses = new string[coursesNum];
            float[] grades = new float[coursesNum];



            for (int i = 0; i < coursesNum; i++)
            {
                Console.Write("\nCourse No. " + (i + 1) + " Name: ");
                courses[i] = Console.ReadLine();

                Console.Write("Grades for " + courses[i] + ": ");
                while (!float.TryParse(Console.ReadLine(), out grades[i]) || grades[i] < 1 || grades[i] > 3) 
                {
                    Console.WriteLine();
                    Console.Write("!------------ Invalid Input ------------!\n");
                    Console.Write("Please enter a valid grade (1.0 to 3.0): ");
                }

            }

            float maxGrade = grades[0];
            float minGrade = grades[0];
            float total = 0f;

            foreach (float grade in grades)
            {

                total += grade;
                maxGrade = Math.Max(maxGrade, grade);
                minGrade = Math.Min(minGrade, grade);
            }

            float avgGrade = total / coursesNum;

            Console.Clear(); // Additional Requirments
            Console.WriteLine("Student Name: " + studentName);
            Console.WriteLine();
            Console.WriteLine("========= Grade Report =========\n");

            for (int i = 0; i < coursesNum; i++)
            {
                string equivGrade = GetEquivGrade(grades[i]);
                Console.WriteLine(courses[i] + " | " + grades[i].ToString("0.00") + " | " + equivGrade);
            }
            Console.WriteLine();
            Console.WriteLine("========= Summary =========\n");
            Console.WriteLine("Maximun Grade: " + maxGrade.ToString("0.00"));
            Console.WriteLine();
            Console.WriteLine("Minimun Grade: " + minGrade.ToString("0.00"));
            Console.WriteLine();
            Console.WriteLine("Average Grade: " + avgGrade.ToString("0.00"));
            Console.WriteLine();
            Console.WriteLine("Overall Grade: " + total.ToString("0.00"));
            Console.WriteLine();
            Console.WriteLine("Equivalent Grade: " + GetEquivGrade(avgGrade));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Author by: Caamic");
        }

        static string GetEquivGrade(float grade)
        {

            if (grade >= 1.00f && grade < 1.25f) return "100 - 97.50 (Excellent)";
            else if (grade >= 1.25f && grade < 1.50f) return "97.49 - 94.50 (Very Good)";
            else if (grade >= 1.50f && grade < 1.75f) return "94.49 - 91.50  (Very Good)";
            else if (grade >= 1.75f && grade < 2.00f) return "91.49 - 86.50 (Very Good)";
            else if (grade >= 2.00f && grade < 2.25f) return "86.49 - 81.50 (Satisfactory)";
            else if (grade >= 2.25f && grade < 2.50f) return "81.49 - 76.00 (Satisfactory)";
            else if (grade >= 2.50f && grade < 2.75f) return "75.99 - 70.50 (Satisfactory)";
            else if (grade >= 2.75f && grade < 3.00f) return "70.49 - 65.00 (Fair)";
            else if (grade == 3.00f) return "64.99 - 59.50 (Fair)";
            else return "Invalid Grade";
        }

    }
}
