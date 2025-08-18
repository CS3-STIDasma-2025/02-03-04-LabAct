using System;

namespace TestRun.Student
{
    internal class Hernandez : Student
    {
        public override void Run()
        {
            // Intro and Instructions
            Console.WriteLine("Welcome to the Student Grade Calculator!");
            Console.WriteLine("You'll enter your courses and grades (0–100), and we'll show your results.\n");

            Console.Write("Enter your name: ");
            string studentName = Console.ReadLine();

            Console.Write("How many courses? ");
            int n = Convert.ToInt32(Console.ReadLine());

            string[] courseNames = new string[n];
            int[] OrigGrades = new int[n];
            double[] equivalents = new double[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nCourse #{i + 1}");
                Console.Write("Course name: ");
                courseNames[i] = Console.ReadLine();

                int grade;
                while (true)
                {
                    Console.Write("Grade (0–100): ");
                    if (int.TryParse(Console.ReadLine(), out grade) && grade >= 0 && grade <= 100)
                        break;
                    Console.WriteLine("Invalid input. Enter a number from 0 to 100.");
                }

                OrigGrades[i] = grade;

                if (grade < 50)
                {
                    Console.WriteLine("\n⚠️  Failing grade entered. Program stopped.");
                    return;
                }

                equivalents[i] = ConvertToEquivalent(grade);
            }

            Console.Clear();
            Console.WriteLine("====== GRADE REPORT ======\n");
            Console.WriteLine($"Student: {studentName}\n");

            Console.WriteLine("Course             | Grade | Equivalent");
            Console.WriteLine("------------------|-------|-----------");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{courseNames[i],-18} | {OrigGrades[i],5} | {equivalents[i]}");
            }

            int maxGrade = OrigGrades[0];
            int minGrade = OrigGrades[0];
            int total = 0;

            foreach (int g in OrigGrades)
            {
                maxGrade = Math.Max(maxGrade, g);
                minGrade = Math.Min(minGrade, g);
                total += g;
            }

            double average = (double)total / n;
            double overall = Math.Round(ConvertToEquivalent((int)average), 2);

            Console.WriteLine("\n------ SUMMARY ------");
            Console.WriteLine($"Highest Grade : {maxGrade}");
            Console.WriteLine($"Lowest Grade  : {minGrade}");
            Console.WriteLine($"Average Grade : {Math.Round(average, 2)}");
            Console.WriteLine($"Overall GPA   : {overall}");

            Console.WriteLine("\nThank you for using the Grade Calculator.");
            Console.WriteLine("Author: Hernandez, Shawn"); 
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static float ConvertToEquivalent(float grade)
        {
            if (grade >= 97) return 1.0f;
            else if (grade >= 94) return 1.25f;
            else if (grade >= 91) return 1.5f;
            else if (grade >= 86) return 1.75f;
            else if (grade >= 81) return 2.0f;
            else if (grade >= 76) return 2.25f;
            else if (grade >= 70) return 2.5f;
            else if (grade >= 65) return 2.75f;
            else if (grade >= 59) return 3.0f;
            else return 5.0f; // Failing grade
        }
    }
}
