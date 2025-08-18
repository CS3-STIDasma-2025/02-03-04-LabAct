using System;

class StudentGrades
{
    static void Main()
    {
        // Student name
        Console.Write("Enter Student Name: ");
        string studentName = Console.ReadLine();

        string[] courses = new string[100];
        double[] grades = new double[100];
        int count = 0;

        // Input loop
        while (true)
        {
            Console.Write("Enter Course Name (or STOP to finish): ");
            string course = Console.ReadLine();

            if (course.ToUpper() == "STOP") break;

            Console.Write("Enter Grade (0-100): ");
            double grade = Convert.ToDouble(Console.ReadLine());

            courses[count] = course;
            grades[count] = grade;
            count++;
        }

        Console.Clear();
        Console.WriteLine($"Student Name: {studentName}\n");

        double sum = 0;
        double max = grades[0];
        double min = grades[0];

        // Display results per course
        for (int i = 0; i < count; i++)
        {
            sum += grades[i];
            max = Math.Max(max, grades[i]);
            min = Math.Min(min, grades[i]);

            double eq = GetEquivalent(grades[i]);
            string keyword = GetKeyword(eq);

            Console.WriteLine($"{courses[i]} | {grades[i]} | {eq} — {keyword}");
        }

        // Overall results
        double average = sum / count;
        double overallEquivalent = GetEquivalent(average);

        Console.WriteLine("\n--- Summary ---");
        Console.WriteLine($"Maximum Grade: {max}");
        Console.WriteLine($"Minimum Grade: {min}");
        Console.WriteLine($"Average Grade: {Math.Round(average, 2)}");
        Console.WriteLine($"Overall Grade: {overallEquivalent}");
        Console.WriteLine($"Equivalent Grade: {GetKeyword(overallEquivalent)}");
        Console.WriteLine("Author: Ratub69");
    }

    static double GetEquivalent(double grade)
    {
        if (grade >= 96) return 1.0;
        else if (grade >= 94) return 1.25;
        else if (grade >= 91) return 1.5;
        else if (grade >= 88) return 1.75;
        else if (grade >= 85) return 2.0;
        else if (grade >= 82) return 2.25;
        else if (grade >= 79) return 2.5;
        else if (grade >= 76) return 2.75;
        else if (grade >= 75) return 3.0;
        else return 5.0;
    }

    static string GetKeyword(double eq)
    {
        if (eq == 1.0) return "Excellent";
        else if (eq == 1.25 || eq == 1.5) return "Very Good";
        else if (eq == 1.75 || eq == 2.0) return "Good";
        else if (eq == 2.25 || eq == 2.5) return "Satisfactory";
        else if (eq == 2.75 || eq == 3.0) return "Passed";
        else return "Failed";
    }
}
