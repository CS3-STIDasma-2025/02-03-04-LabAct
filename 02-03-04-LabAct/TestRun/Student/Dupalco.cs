using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Dupalco : Student
    {
        public override void Run()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("         STUDENT GRADE CALCULATOR APP         ");
            Console.WriteLine("==============================================");
            Console.WriteLine("Instructions:");
            Console.WriteLine("1. Enter your name.");
            Console.WriteLine("2. Enter the number of courses.");
            Console.WriteLine("3. For each course, input the course name and grade.");
            Console.WriteLine("4. Grades should be 1.00 - 3.00 (e.g., 1, 1.25, 2.5).");
            Console.WriteLine("5. Program will calculate Max, Min, Average, Overall, and Equivalent.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();

            Console.Write("Enter number of courses: ");
            int courseCount = int.Parse(Console.ReadLine());

            string[] courseNames = new string[courseCount];
            double[] courseGrades = new double[courseCount];

            for (int i = 0; i < courseCount; i++)
            {
                Console.WriteLine($"\nCourse #{i + 1}");
                Console.Write("Enter Course Name: ");
                courseNames[i] = Console.ReadLine();

                Console.Write("Enter Grade (1.00 - 3.00): ");
                courseGrades[i] = double.Parse(Console.ReadLine());
            }

            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine($" Student Name: {studentName}");
            Console.WriteLine("==============================================");
            Console.WriteLine("Course Results:");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"{"Course",-25} {"Grade",-10} {"Equivalent",-15}");
            Console.WriteLine("------------------------------------------------------");

            double total = 0;
            double maxGrade = courseGrades[0];
            double minGrade = courseGrades[0];

            for (int i = 0; i < courseCount; i++)
            {
                double grade = courseGrades[i];
                total += grade;

                maxGrade = Math.Max(maxGrade, grade);
                minGrade = Math.Min(minGrade, grade);

                string equivalent = grade switch
                {
                    1.00 => "Excellent",
                    1.25 => "Very Good",
                    1.50 => "Good",
                    1.75 => "Above Average",
                    2.00 => "Average",
                    2.25 => "Satisfactory",
                    2.50 => "Fair",
                    2.75 => "Passing",
                    3.00 => "Barely Passing",
                    _ => "Invalid"
                };

                Console.WriteLine($"{courseNames[i],-25} {grade,-10} {equivalent,-15}");
            }

            double average = total / courseCount;
            double overall = Math.Round(average, 2);

            string overallEquivalent = overall switch
            {
                <= 1.00 => "Excellent",
                <= 1.25 => "Very Good",
                <= 1.50 => "Good",
                <= 1.75 => "Above Average",
                <= 2.00 => "Average",
                <= 2.25 => "Satisfactory",
                <= 2.50 => "Fair",
                <= 2.75 => "Passing",
                <= 3.00 => "Barely Passing",
                _ => "Invalid"
            };

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"Maximum Grade: {maxGrade}");
            Console.WriteLine($"Minimum Grade: {minGrade}");
            Console.WriteLine($"Average Grade: {average}");
            Console.WriteLine($"Overall Grade: {overall}");
            Console.WriteLine($"Equivalent Grade: {overallEquivalent}");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Author: Dupalco");
            Console.WriteLine("======================================================");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
   
    }
}
//THIS IS A TEMPLATE FILE 
