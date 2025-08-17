using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Tolentino : Student
    {
        public override void Run()
        {
            //Instructions 
            ShowInstructions();
            Console.Clear();

            //Student Name
            Console.WriteLine("Enter Student Name: ");
            string studentName = Console.ReadLine();

            //Asks how many courses 
            int capacity = ReadIntInRange("Enter the number of Courses (1-20)? ", 1, 20);

            //Arrays to store the courses and grades (string + double)
            string[] coursesName = new string[capacity];
            double[] rawGrades = new double[capacity];             //Grades Range: 0-100
            double[] equiGrades = new double[capacity];            //Equivalent Grades Range: 1.00 - 5.00
            int count = 0;

            //Entering courses and grades
            for (int i = 0; i < capacity; i++)
            {
                Console.WriteLine($"\nCourse {i + 1} Name (or Type 'DONE' to finish early): ");
                string course = (Console.ReadLine() ?? "").Trim();
                if (course.Equals("DONE", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Finished entering courses.");
                    break;  // Exit the loop if 'DONE' is entered
                }

                // Validating course name
                double grade;
                do
                {
                    Console.Write($"Enter the grade for {course} (0-100): ");
                    string input = Console.ReadLine()?.Trim() ?? "";
                    if (double.TryParse(input, out grade) && grade >= 0 && grade <= 100)
                    {
                        grade = Math.Round(grade, 2);  // Round to 2 decimal places
                        break;
                    }
                    Console.WriteLine("  Invalid input. Please enter a number between 0 and 100.");
                } while (true);


                coursesName[count] = course;
                rawGrades[count] = grade;
                equiGrades[count] = ToEquivalent(grade);  // Convert to equivalent grade
                count++;

            }

            //Calculate Maximum, Minimum, Average, Overall GPA, and Equivalent of Average
            double max = rawGrades[0];
            double min = rawGrades[0];
            double sum = 0;
            double sumEqui = 0;

            for (int i = 0; i < count; i++)
            {
                if (rawGrades[i] > max) max = rawGrades[i];       //Finds the max grade
                if (rawGrades[i] < min) min = rawGrades[i];       //Finds the minm grade
                sum += rawGrades[i];
                sumEqui += equiGrades[i];
            }

            double average = sum / count;
            double overallGPA = sumEqui / count;              //Overall GPA 
            double equiOfAverage = ToEquivalent(average);     //Equivalent of the average grade

            //Output the results
            Console.Clear(); // Clear the console
            Header($"GRADE REPORT - {studentName}");
            Console.WriteLine("{0,-35} | {1,7} | {2,6} | {3,-12}", "Course", "Grade", "Eqv", "Keyword");
            Console.WriteLine(new string('-', 70));

            for (int i = 0; i < count; i++)
            {
                string kw = Keyword(equiGrades[i]);  // Get the keyword for the equivalent grade
                Console.WriteLine("{0,-35} | {1,7:0.##} | {2,6:0.00} | {3,-12}",
                    coursesName[i], rawGrades[i], equiGrades[i], kw);
            }

            Console.WriteLine(new string('-', 70));

            //output lines
            Console.WriteLine($"Maximum Grade: {Math.Round(max, 2):0.##}");
            Console.WriteLine($"Minimum Grade: {Math.Round(max, 2):0.##}");
            Console.WriteLine($"Average Grade: {Math.Round(average, 2):0.##}");
            Console.WriteLine($"Overall GPA: {Math.Round(overallGPA, 2):0.00}");
            Console.WriteLine($"Equivalent of Average: {Math.Round(equiOfAverage, 2):0.00}");
            Console.WriteLine("\nAuthored by: Tolentino");

        }
        // Converts grade to the equivalent grade
        static double ToEquivalent(double grade)
        {
            double equiGrade;
            if (grade >= 97.50) equiGrade = 1.00;
            else if (grade >= 94.50) equiGrade = 1.25;
            else if (grade >= 91.50) equiGrade = 1.50;
            else if (grade >= 86.50) equiGrade = 1.75;
            else if (grade >= 81.50) equiGrade = 2.00;
            else if (grade >= 76) equiGrade = 2.25;
            else if (grade >= 70.50) equiGrade = 2.50;
            else if (grade >= 65) equiGrade = 2.75;
            else if (grade >= 59.50) equiGrade = 3.00;
            else equiGrade = 5.00; //else failing grades
            return equiGrade;
        }

        // Returns a keyword based on the equivalent grade
        static String Keyword(double equiGrade)
        {

            const double EPS = 0.0001;
            if (Math.Abs(equiGrade - 1.00) < EPS) return "Excellent";
            else if (Math.Abs(equiGrade - 1.25) < EPS) return "Very Good";
            else if (Math.Abs(equiGrade - 1.50) < EPS) return "Very Good";
            else if (Math.Abs(equiGrade - 1.75) < EPS) return "Very Good";
            else if (Math.Abs(equiGrade - 2.00) < EPS) return "Satisfactory";
            else if (Math.Abs(equiGrade - 2.25) < EPS) return "Satisfactory";
            else if (Math.Abs(equiGrade - 2.50) < EPS) return "Satisfactory";
            else if (Math.Abs(equiGrade - 2.75) < EPS) return "Fair";
            else if (Math.Abs(equiGrade - 3.00) < EPS) return "Fair";
            else return "Failed";
        }

        static int ReadIntInRange(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int v) && v >= min && v <= max)
                    return v;
                Console.WriteLine($"Please enter a whole number between {min} and {max}.");
            }

        }

        // Prints the header
        static void Header(string title)
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 70));
            Console.WriteLine(title);
            Console.WriteLine(new string('=', 70));
        }

        // Displays step-by-step instructions for using the program
        static void ShowInstructions()
        {
            Console.WriteLine("GRADE RECORDER — Instructions");
            Console.WriteLine("1) Enter the student name.");
            Console.WriteLine("2) Choose how many courses to record (1–20).");
            Console.WriteLine("3) For each course, type its name and a grade (0–100).");
            Console.WriteLine("   Tip: Type DONE as the course name to finish early.");
            Console.WriteLine("4) The program will calculate Maximum, Minimum, Average,");
            Console.WriteLine("   Overall (GPA), and the Equivalent Grade of the average.");
            Console.WriteLine("5) You’ll see a formatted table: Course | Grade | Eqv | Keyword.");
            Console.ReadLine();
            Console.Clear();
        }

    }



        