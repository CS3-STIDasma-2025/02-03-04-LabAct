using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestRun.Student
 
{
internal class Garrido : Student
    { 
            public override void Run()   
    {
        // instructions
        Console.WriteLine("=== GRADE CALCULATOR ===");
        Console.WriteLine("Step 1: Enter your name.");
        Console.WriteLine("Step 2: Enter number of subjects/courses.");
        Console.WriteLine("Step 3: For each course, enter the course name and grade.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        Console.Clear();

        // Get student name
        Console.Write("Enter your full name: ");
        string studentName = Console.ReadLine();

        // Number of courses
        Console.Write("Enter the number of courses: ");
        int courseCount = int.Parse(Console.ReadLine());

        // Arrays to hold course names and grades
        string[] courseNames = new string[courseCount];
        double[] courseGrades = new double[courseCount];

   
        for (int i = 0; i < courseCount; i++)
        {
            Console.WriteLine($"\nCourse #{i + 1}");
            Console.Write("Enter course name: ");
            courseNames[i] = Console.ReadLine();

            double grade;
            while (true)
            {
                Console.Write("Enter numeric grade (50-100): ");
                grade = double.Parse(Console.ReadLine());

                if (grade >= 50 && grade <= 100)
                {
                    break; // valid grade entered
                }
                else
                {
                    Console.WriteLine("Invalid grade. Please enter a number between 50 and 100.");
                }
            }

            courseGrades[i] = grade;
        }

        Console.Clear();

        // Output Section
        Console.WriteLine("=========== GRADE REPORT ===========\n");
        Console.WriteLine($"Student Name: {studentName}\n");
        Console.WriteLine("Course\t\tGrade\tEquivalent");

        double total = 0;
        double maxGrade = courseGrades[0];
        double minGrade = courseGrades[0];

        // Loop to print courses and calculate totals
        for (int i = 0; i < courseCount; i++)
        {
            double grade = courseGrades[i];
            string equivalent = GetGradeEquivalent(grade);

            Console.WriteLine($"{courseNames[i],-15} | {grade,5} | {equivalent}");

            total += grade;
            maxGrade = Math.Max(maxGrade, grade);
            minGrade = Math.Min(minGrade, grade);
        }

        // Calculate average and equivalent
        double average = Math.Round(total / courseCount, 2);
        string overallEquivalent = GetGradeEquivalent(average);

        // Final Summary
        Console.WriteLine("\n=========== SUMMARY ===========");
        Console.WriteLine($"Maximum Grade: {maxGrade}");
        Console.WriteLine($"Minimum Grade: {minGrade}");
        Console.WriteLine($"Average Grade: {average}");
        Console.WriteLine($"Overall Grade: {Math.Round(average, 2)}");
        Console.WriteLine($"Equivalent Grade: {overallEquivalent}");

        Console.WriteLine("\nAuthor: Your Name Here");
    }

    // Method to get grade equivalent
    static string GetGradeEquivalent(double grade)
    {
        if (grade >= 97 && grade <= 100)
            return "1.00";
        else if (grade >= 94)
            return "1.25";
        else if (grade >= 91)
            return "1.50";
        else if (grade >= 88)
            return "1.75";
        else if (grade >= 85)
            return "2.00";
        else if (grade >= 82)
            return "2.25";
        else if (grade >= 79)
            return "2.50";
        else if (grade >= 76)
            return "2.75";
        else if (grade >= 75)
            return "3.00";
        else
            return "5.00 (Fail)";
    }
}

}