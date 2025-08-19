using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Gonzales : Student
    {
        public override void Run()
        {
            string author = "Your Name Here";

            while (true)
            {
                Console.Clear();
                Console.Write("Enter Student Name: ");
                string studentName = Console.ReadLine() ?? "";

                int numCourses = ReadInt("Enter number of courses: ", 1);

                string[] courses = new string[numCourses];
                double[] rawGrades = new double[numCourses];
                double[] equivGwa = new double[numCourses];

                for (int i = 0; i < numCourses; i++)
                {
                    Console.Write($"\nEnter Course Name {i + 1}: ");
                    courses[i] = Console.ReadLine() ?? $"Course {i + 1}";
                    rawGrades[i] = ReadDouble($"Enter numeric grade for {courses[i]} (0–100): ", 0, 100);
                    equivGwa[i] = PercentToGwa(rawGrades[i]);
                }

                Console.Clear();
                Console.WriteLine("=========================================");
                Console.WriteLine($" Student: {studentName}");
                Console.WriteLine("=========================================");
                Console.WriteLine($"{"Course",-30} | {"Grade",5} | {"Equivalent",10}");
                Console.WriteLine(new string('-', 55));

                double totalRaw = 0;
                double totalEquiv = 0;

                for (int i = 0; i < numCourses; i++)
                {
                    totalRaw += rawGrades[i];
                    totalEquiv += equivGwa[i];
                    Console.WriteLine($"{Truncate(courses[i], 30),-30} | {rawGrades[i],5:0} | {equivGwa[i],10:0.00}");
                }

                double maxRaw = rawGrades[0];
                double minRaw = rawGrades[0];
                for (int i = 1; i < numCourses; i++)
                {
                    maxRaw = Math.Max(maxRaw, rawGrades[i]);
                    minRaw = Math.Min(minRaw, rawGrades[i]);
                }

                double avgRaw = totalRaw / numCourses;
                double overallGwa = Math.Round(totalEquiv / numCourses, 2);
                double overallGwaStepped = RoundToStep(overallGwa);
                string overallKeyword = KeywordForGwa(overallGwaStepped);

                Console.WriteLine("=========================================");
                Console.WriteLine($"Maximum Grade: {maxRaw:0}");
                Console.WriteLine($"Minimum Grade: {minRaw:0}");
                Console.WriteLine($"Average Grade: {Math.Round(avgRaw, 2):0.##}");
                Console.WriteLine($"Overall Grade: {overallGwa:0.00}");
                Console.WriteLine($"Equivalent Grade: {overallGwaStepped:0.00} — {overallKeyword}");
                Console.WriteLine("=========================================");
                Console.WriteLine($"Author: {author}");

                Console.Write("\nPress 'X' to exit, or any key to run again: ");
                string opt = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();
                if (opt == "X")
                {
                    break;
                }
            }
        }

        static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string? s = Console.ReadLine();
                if (int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out int v) && v >= min && v <= max)
                    return v;
                Console.WriteLine("Invalid integer. Try again.");
            }
        }

        static double ReadDouble(string prompt, double min, double max)
        {
            while (true)
            {
                Console.Write(prompt);
                string? s = Console.ReadLine();
                if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out double v) && v >= min && v <= max)
                    return v;
                Console.WriteLine("Invalid number. Try again.");
            }
        }

        static double PercentToGwa(double percent)
        {
            if (percent >= 96) return 1.00;
            else if (percent >= 93) return 1.25;
            else if (percent >= 90) return 1.50;
            else if (percent >= 87) return 1.75;
            else if (percent >= 84) return 2.00;
            else if (percent >= 81) return 2.25;
            else if (percent >= 78) return 2.50;
            else if (percent >= 75) return 2.75;
            else return 3.00;
        }

        static double RoundToStep(double gwa)
        {
            double stepped = Math.Round((gwa - 1.0) / 0.25) * 0.25 + 1.0;
            if (stepped < 1.0) stepped = 1.0;
            if (stepped > 3.0) stepped = 3.0;
            return Math.Round(stepped, 2);
        }

        static string KeywordForGwa(double gwa)
        {
            if (gwa == 1.00) return "Excellent";
            else if (gwa == 1.25) return "Very Good";
            else if (gwa == 1.50) return "Good";
            else if (gwa == 1.75) return "Above Average";
            else if (gwa == 2.00) return "Average";
            else if (gwa == 2.25) return "Satisfactory";
            else if (gwa == 2.50) return "Fair";
            else if (gwa == 2.75) return "Pass";
            else if (gwa == 3.00) return "Conditional Pass";
            else return "Invalid";
        }

        static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);

        }
   
    }
}

