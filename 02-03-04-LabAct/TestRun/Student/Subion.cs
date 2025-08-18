using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Subion : Student
    {
        public override void Run()
        {
            Console.WriteLine("GRADE CALCULATOR — INSTRUCTIONS");
            Console.WriteLine("1) Enter the Author (your name) and the Student name.");
            Console.WriteLine("2) Choose how many courses you want to input (max you decide).");
            Console.WriteLine("3) For each course, type the Course Name and the numeric Grade (0–100).");
            Console.WriteLine("   Tip: Type 'done' as a course name if you want to stop early.");
            Console.WriteLine("4) After input, you can choose to sort results by grade (high→low) for clarity.");
            Console.WriteLine("5) The app will display per-course results and overall stats.");
            Console.WriteLine();
            Console.Write("Press ENTER to start...");
            Console.ReadLine();

            Console.Clear();

            // --- Collect names ---
            Console.Write("Enter Author's Name: ");
            string authorName = Console.ReadLine()?.Trim() ?? "Unknown Author";

            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine()?.Trim() ?? "Unknown Student";

            // --- Number of courses & arrays (arrays: string + double) ---
            int capacity = ReadInt("How many courses will you enter? ", min: 1, max: 100);

            string[] courses = new string[capacity];
            double[] grades = new double[capacity];
            double[] equivalents = new double[capacity];

            // --- Input loop with validation; allows early exit via 'done' (uses break) ---
            Console.WriteLine();
            Console.WriteLine("Enter course details (type 'done' for Course Name to stop):");

            int count = 0;
            for (int i = 0; i < capacity; i++)
            {
                Console.Write($"\nCourse #{i + 1} name: ");
                string? name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name) &&
                    name.Trim().Equals("done", StringComparison.OrdinalIgnoreCase))
                {
                    if (i == 0)
                    {
                        Console.WriteLine("You must enter at least one course.");
                        i--; // stay on the same index
                        continue;
                    }
                    // requirement: use break
                    break;
                }

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Course name cannot be empty. Try again.");
                    i--;
                    continue;
                }

                double grade = ReadDouble($"Numeric grade for \"{name}\" (0–100): ", 0, 100);
                courses[i] = name.Trim();
                grades[i] = grade;
                equivalents[i] = PercentToEquivalent(grade);
                count++;
            }

            // Optional visual/UX improvement: allow sorting by grade
            Console.Write("\nSort courses by grade (high → low)? [Y/N]: ");
            string? sortAnswer = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(sortAnswer) &&
                sortAnswer.Trim().StartsWith("Y", StringComparison.OrdinalIgnoreCase))
            {
                // simple selection sort to keep arrays aligned
                for (int i = 0; i < count - 1; i++)
                {
                    int maxIdx = i;
                    for (int j = i + 1; j < count; j++)
                    {
                        if (grades[j] > grades[maxIdx]) maxIdx = j;
                    }
                    if (maxIdx != i)
                    {
                        Swap(ref courses[i], ref courses[maxIdx]);
                        Swap(ref grades[i], ref grades[maxIdx]);
                        Swap(ref equivalents[i], ref equivalents[maxIdx]);
                    }
                }
            }

            // --- Calculations using Math class ---
            double max = grades[0];
            double min = grades[0];
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                max = Math.Max(max, grades[i]);
                min = Math.Min(min, grades[i]);
                sum += grades[i];
            }

            double average = sum / count;
            average = Math.Round(average, 2);

            double overallEquivalent = PercentToEquivalent(average);
            overallEquivalent = Math.Round(overallEquivalent, 2);
            string overallKeyword = EquivalentKeyword(overallEquivalent);

            // --- Clear before results (Console.Clear as required/feature) ---
            Console.Clear();

            // --- Output (formatted for easy reading) ---
            Console.WriteLine("==============================================");
            Console.WriteLine("               GRADE RESULTS");
            Console.WriteLine("==============================================");
            Console.WriteLine($"Student Name : {studentName}");
            Console.WriteLine($"Author       : {authorName}");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"{"Course",-30} | {"Grade",6} | {"Eqv.",5} | Keyword");
            Console.WriteLine(new string('-', 30) + "-+-" + new string('-', 6) + "-+-" + new string('-', 5) + "-+-" + new string('-', 8));

            for (int i = 0; i < count; i++)
            {
                string keyword = EquivalentKeyword(equivalents[i]); // if/else mapping usage
                Console.WriteLine($"{courses[i],-30} | {grades[i],6:F2} | {equivalents[i],5:0.00} | {keyword}");
            }

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Maximum Grade: {max:F2}");
            Console.WriteLine($"Minimum Grade: {min:F2}");
            Console.WriteLine($"Average Grade: {average:F2}");
            Console.WriteLine($"Overall Grade: {overallEquivalent:0.00}");
            Console.WriteLine($"Equivalent Grade: {overallKeyword}");
            Console.WriteLine("==============================================");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        // --- Helpers ---

        // Map 0–100% to 1.00–3.00 (or 5.00 if < 75). Adjust ranges as needed for your school.
        static double PercentToEquivalent(double p)
        {
            // Uses else-if and else (requirement)
            if (p >= 97) return 1.00;
            else if (p >= 94) return 1.25;
            else if (p >= 91) return 1.50;
            else if (p >= 88) return 1.75;
            else if (p >= 85) return 2.00;
            else if (p >= 82) return 2.25;
            else if (p >= 79) return 2.50;
            else if (p >= 76) return 2.75;
            else if (p >= 75) return 3.00;
            else return 5.00; // Failed (common in PH grading scales)
        }

        // Keyword for specified equivalents: 1, 1.25, 1.5, 1.75, 2, 2.25, 2.5, 2.75, 3
        static string EquivalentKeyword(double eq)
        {
            // Uses if statements as required. 
            // Compare with tolerance to handle rounding.
            double e = Math.Round(eq, 2);
            if (Nearly(e, 1.00)) return "Excellent";
            else if (Nearly(e, 1.25)) return "Superior";
            else if (Nearly(e, 1.50)) return "Very Good";
            else if (Nearly(e, 1.75)) return "Good";
            else if (Nearly(e, 2.00)) return "Satisfactory";
            else if (Nearly(e, 2.25)) return "Fair+";
            else if (Nearly(e, 2.50)) return "Fair";
            else if (Nearly(e, 2.75)) return "Pass";
            else if (Nearly(e, 3.00)) return "Barely Pass";
            else return "Failed";
        }

        static bool Nearly(double a, double b, double tol = 0.001) => Math.Abs(a - b) < tol;

        static int ReadInt(string prompt, int min, int max)
        {
            while (true) // loop requirement
            {
                Console.Write(prompt);
                string? s = Console.ReadLine();
                if (int.TryParse(s, out int val) && val >= min && val <= max)
                    return val;

                Console.WriteLine($"Please enter an integer from {min} to {max}.");
            }
        }

        static double ReadDouble(string prompt, double min, double max)
        {
            while (true) // loop requirement
            {
                Console.Write(prompt);
                string? s = Console.ReadLine();
                if (double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out double val)
&& val >= min && val <= max)
                    return val;

                Console.WriteLine($"Please enter a number from {min} to {max}.");
            }
        }

        static void Swap<T>(ref T a, ref T b)
        {
            (b, a) = (a, b);
        }

    }
}
//THIS IS A TEMPLATE FILE 
