using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Anda : Student
    {
        public override void Run() 
        { 
            Init init = new Init();
        }








        
        public class Student
        {
            string name { get; set; }
            string[] courses;
            float[] grades;
            GradeEvaluator gradeEvaluator = new GradeEvaluator();
            public Student(string name, string[] courses, float[] inputGrades)
            {
                this.name = name;
                this.courses = courses;
                this.grades = inputGrades;
            }
            public float GetMaxGrade()
            {
                float max = 0;
                foreach (var grade in grades)
                {
                    max = Math.Max(max, grade);
                }
                return max;
            }
            public float GetMinGrade()
            {
                float min = grades[0];
                if (grades.Length == 1)
                {
                    return grades[0];
                }
                foreach (var grade in grades)
                {
                    min = Math.Min(min, grade);
                }
                return min;
            }
            public float GetAverageGrade()
            {
                float average = 0;
                foreach (var grade in grades)
                {
                    average += grade;
                }
                average /= grades.Length;

                return average;
            }
            public void Display()
            {
                Console.Clear();
                Console.WriteLine($"Grade for {this.name}:");
                for (int i = 0; i < grades.Length; i++)
                {
                    Console.WriteLine($"{courses[i]}  |    {grades[i]}  | {gradeEvaluator.EvaluateGrade(grades[i]):F2}");
                }
            }
            public float GetOverallGrade()
            {
                float average = 0;
                foreach (var grade in grades)
                {
                    average += grade;
                }
                average /= grades.Length;

                return (float)Math.Round(average, 2);
            }
        }
        public class GradeEvaluator
        {
            public float EvaluateGrade(float grade)
            {
                //used if statements to evaluate the grade and return a float value instead of to follow instructions
                if (grade > 97.5)
                {
                    return 1.00f;
                }
                else if (grade < 97.49 && grade >= 94.5)
                {
                    return 1.25f;
                }
                else if (grade < 94.49 && grade >= 91.5)
                {
                    return 1.50f;
                }
                else if (grade < 91.49 && grade >= 88.5)
                {
                    return 1.75f;
                }
                else if (grade < 88.49 && grade >= 85.5)
                {
                    return 2.00f;
                }
                else if (grade < 85.49 && grade >= 82.5)
                {
                    return 2.25f;
                }
                else if (grade < 82.49 && grade >= 79.5)
                {
                    return 2.50f;
                }
                else if (grade < 79.49 && grade >= 76.5)
                {
                    return 2.75f;
                }
                else if (grade < 76.49 && grade >= 73.5)
                {
                    return 3.00f;
                }
                else if (grade < 73.49 && grade >= 70.5)
                {
                    return 3.25f;
                }
                else if (grade < 70.49 && grade >= 67.5)
                {
                    return 3.50f;
                }
                else if (grade < 67.49 && grade >= 64.5)
                {
                    return 3.75f;
                }
                else if (grade < 64.49 && grade >= 61.5)
                {
                    return 4.00f;
                }
                return 0.00f;
            }
        }
        public class Init
        {
            PromptHandler promptHandler = new PromptHandler();
            string? name;
            List<string?> courses;
            List<float> grades;
            Student student;

            public Init()
            {
                courses = new List<string?>();
                grades = new List<float>();
                GradeEvaluator gradeEvaluator = new GradeEvaluator();

                name = promptHandler.Prompt("Enter your name: ");
                string? answer = "";

                int i = 0;
                while (true)
                {
                    if (i >= 1)
                    {
                        Console.WriteLine("Type 'exit' to finish entering courses.                                      GRADE CALCULATOR Author: Anda");
                    }

                    answer = promptHandler.Prompt("Enter the course name: ");

                    if (string.IsNullOrWhiteSpace(answer))
                        continue;

                    if (answer.ToLower() == "exit" && i > 0)
                        break;

                    courses.Add(answer);

                    string? gradeInput = promptHandler.Prompt($"Enter the grade for {answer}: ");

                    if (float.TryParse(gradeInput, out float f))
                    {
                        if (f < 0 || f > 100)
                        {
                            Console.WriteLine("Grade must be between 0 and 100. Please try again.");
                            courses.RemoveAt(courses.Count - 1);
                            continue;
                        }
                        grades.Add(f);
                    }
                    else
                    {
                        Console.WriteLine("Invalid grade, please try again.");
                        courses.RemoveAt(courses.Count - 1);
                        continue;
                    }
                    Console.Clear();
                    i++;
                }

                student = new Student(name, courses.ToArray(), grades.ToArray());
                while (true)
                {
                    answer = promptHandler.Prompt($"Grade analyzer for {name}, type display, max, min, avg, overall; Author: Anda");

                    switch (answer?.ToLower())
                    {
                        case "display":
                            student.Display();
                            promptHandler.Prompt("Press any key to continue...");
                            Console.Clear();
                            break;

                        case "max":
                            {
                                float grade = student.GetMaxGrade();
                                Console.WriteLine($"{grade:F2}    | {gradeEvaluator.EvaluateGrade(grade):F2}");
                                promptHandler.Prompt("Press any key to continue...");
                                Console.Clear();
                            }
                            break;

                        case "min":
                            {
                                float grade = student.GetMinGrade();
                                Console.WriteLine($"{grade:F2}    | {gradeEvaluator.EvaluateGrade(grade):F2}");
                                promptHandler.Prompt("Press any key to continue...");
                                Console.Clear();
                            }
                            break;

                        case "avg":
                            {
                                float avg = student.GetAverageGrade();
                                Console.WriteLine($"Average grade: {avg:F2}    | {gradeEvaluator.EvaluateGrade(avg):F2}");
                                promptHandler.Prompt("Press any key to continue...");
                                Console.Clear();
                            }
                            break;

                        case "overall":
                            Console.WriteLine($"Overall grade: {student.GetOverallGrade():F2}");
                            promptHandler.Prompt("Press any key to continue...");
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("Invalid command, please try again.");
                            break;
                    }
                }
            }
        }
        public class PromptHandler
        {
            public string? Prompt(String prompt)
            {
                Console.WriteLine(prompt);
                return Console.ReadLine();
            }
        }

    }
}
