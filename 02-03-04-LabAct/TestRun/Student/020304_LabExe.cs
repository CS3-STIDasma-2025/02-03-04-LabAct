using System;

class GradeManagementSystem
{
    static void Main()
    {
        DisplayWelcomeMessage();

        Console.Write("Student Name: ");
        string studentName = Console.ReadLine();

        Console.Write("Number of Subjects: ");
        int numberOfCourses = int.Parse(Console.ReadLine());

        string[] courseNames = new string[numberOfCourses];
        double[] grades = new double[numberOfCourses];
        string[] equivalentGrades = new string[numberOfCourses];

        for (int i = 0; i < numberOfCourses; i++)
        {
            Console.WriteLine($"\nCourse {i + 1}");
            Console.Write("Subject Name: ");
            courseNames[i] = Console.ReadLine();

            while (true)
            {
                Console.Write("Grade (1.0 - 3.0): ");
                if (double.TryParse(Console.ReadLine(), out grades[i]) && grades[i] >= 1.0 && grades[i] <= 3.0)
                {
                    break;
                }
                Console.WriteLine("Invalid input. Enter a grade between 1.0 and 3.0.");
            }

            equivalentGrades[i] = GetEquivalentGrade(grades[i]);
        }

        double maxGrade = CalculateMaximum(grades);
        double minGrade = CalculateMinimum(grades);
        double averageGrade = CalculateAverage(grades);
        double overallGrade = Math.Round(averageGrade, 2);
        string overallEquivalent = GetEquivalentGrade(overallGrade);

        Console.Clear();
        Console.WriteLine("====== Grade Report ======\n");
        Console.WriteLine($"Student: {studentName}\n");

        Console.WriteLine("Subjects\t\tGrade\tEquivalent");
        Console.WriteLine("-------------------------------");
        for (int i = 0; i < courseNames.Length; i++)
        {
            Console.WriteLine($"{courseNames[i],-15} {grades[i],-5} {equivalentGrades[i]}");
        }

        Console.WriteLine("\n--- Summary ---");
        Console.WriteLine($"Max Grade:     {maxGrade}");
        Console.WriteLine($"Min Grade:     {minGrade}");
        Console.WriteLine($"Avg Grade:     {averageGrade}");
        Console.WriteLine($"Overall Grade: {overallGrade} ({overallEquivalent})");

        PerformGradeAnalysis(grades, equivalentGrades);

        Console.WriteLine("\nAuthor:Shawn Hernandez");
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void DisplayWelcomeMessage()
    {
        Console.Clear();
        Console.WriteLine("===== Grade Management System =====\n");
        Console.WriteLine("Enter student details and subjects grades (1.0 to 3.0).\n");
    }

    static string GetEquivalentGrade(double grade)
    {
        return grade switch
        {
            1.0 => "Excellent",
            1.25 => "Very Good+",
            1.5 => "Very Good",
            1.75 => "Good+",
            2.0 => "Good",
            2.25 => "Satisfactory+",
            2.5 => "Satisfactory",
            2.75 => "Pass+",
            3.0 => "Pass",
            _ => "Invalid"
        };
    }

    static double CalculateMaximum(double[] grades)
    {
        double max = grades[0];
        foreach (double grade in grades)
            max = Math.Max(max, grade);
        return max;
    }

    static double CalculateMinimum(double[] grades)
    {
        double min = grades[0];
        foreach (double grade in grades)
            min = Math.Min(min, grade);
        return min;
    }

    static double CalculateAverage(double[] grades)
    {
        double sum = 0;
        foreach (double grade in grades)
            sum += grade;
        return Math.Round(sum / grades.Length, 2);
    }

    static void PerformGradeAnalysis(double[] grades, string[] equivalents)
    {
        int excellent = 0, good = 0, pass = 0;

        foreach (var eq in equivalents)
        {
            if (eq.Contains("Excellent")) excellent++;
            else if (eq.Contains("Good") || eq.Contains("Very Good")) good++;
            else pass++;
        }

        Console.WriteLine("\n--- Grade Breakdown ---");
        Console.WriteLine($"Excellent: {excellent}");
        Console.WriteLine($"Good:      {good}");
        Console.WriteLine($"Pass:      {pass}");

        double avg = CalculateAverage(grades);
        Console.Write("Performance: ");
        if (avg <= 1.5) Console.WriteLine("Outstanding!");
        else if (avg <= 2.0) Console.WriteLine("Good, but can improve.");
        else Console.WriteLine("Needs improvement.");
    }
}
