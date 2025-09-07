using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Kalubiran : Student
    {
        static string[] course_Names;
        static float[] grades;
        static string input_Name;
        static int course_Amount;
        static String studentName;
        public override void Run()
        {
            Console.WriteLine("Running Kalubiran's code...");

            bool user_Choice = true;

            Console.Write("Input Student Name: ");
            studentName = Console.ReadLine();
            Console.WriteLine("Welcome " + studentName + "!");
            do
            {
                string optionInput = "";
                bool validInput = false;

                menu();

                while (!validInput)
                {
                    Console.Write("\nWhat would you like to do? (Please type a keyword) ");
                    optionInput = Console.ReadLine();

                    switch (optionInput.ToLower()) //Switch for menu-action selection
                    {
                        case "input":
                            Console.WriteLine();
                            input_Grades();
                            validInput = true;
                            break;
                        case "view":
                            Console.WriteLine();
                            see_Grades();
                            validInput = true;
                            break;
                        case "minmax":
                            Console.WriteLine();
                            see_MinMaxGrades();
                            validInput = true;
                            break;
                        case "evaluate":
                            Console.WriteLine();
                            see_TotalAndAverage();
                            validInput = true;
                            break;
                        case "equivalent":
                            Console.WriteLine();
                            grade_Equivalent();
                            validInput = true;
                            break;
                        default:
                            Console.WriteLine("\nWrong Input, Please Type The Correct Keyword:");
                            break;
                    }
                }

                if (AskYesNo("Do you want to clear the screen before returning to the menu? (Yes/No)? "))
                {
                    Console.Clear();
                }

                user_Choice = AskYesNo("Do you want to return to the menu? (Yes/No)? "); 

            } while (user_Choice);

            Console.WriteLine("\nThank you for using MyGradeTracker");
            Console.WriteLine("Author: KALUBIRAN, Charlie Heart");

        }

        //Menu display method
        static void menu()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Welcome to MyGradeTracker");
            Console.WriteLine("Student: " + studentName);
            Console.WriteLine("Author: KALUBIRAN, Charlie");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Actions: \n(Keyword - Function)\nInput - Input your Grades \nView - See All Grades \nMinmax - See your Minimum and Maximum Grades and their corresponding course/s \nEvaluate - See the total or overall grade and your average \nEquivalent - See the equivalent grade (% to STI Grading System) of a chosen course");
        }

        /*Handles logic for inputting n amount of courses in an array of both String(course name) &
          float(course grade)*/
        static void input_Grades()
        {
            Console.Write("How many courses would you like to input grades to? ");
            string amountString = Console.ReadLine();
            int tempCourseAmount;

            while (!Validator.isValidInput<int>(amountString, out tempCourseAmount))
            {
                if (string.IsNullOrWhiteSpace(amountString))
                {
                    Console.Write("No input detected, please type a valid input: ");
                }
                else
                {
                    Console.Write("Invalid input, please enter a valid number: ");
                }
                amountString = Console.ReadLine();
            }
            course_Amount = tempCourseAmount; //course amount: iteration variable in the name and grade for-loop

            Console.WriteLine();
            course_Names = new string[course_Amount];
            grades = new float[course_Amount];

            for (int i = 0; i < course_Amount; i++)
            {
                Console.Write($"Please Input Course Name #{i + 1}: ");
                input_Name = Console.ReadLine();
                string inputtedName;

                //Handles input validation
                while (!Validator.isValidInput<string>(input_Name, out inputtedName))
                {
                    if (string.IsNullOrWhiteSpace(input_Name))
                    {
                        Console.Write("No input detected, please type a valid input: ");
                    }
                    input_Name = Console.ReadLine();
                }

                string gradeInputString;
                bool validGradeInput;
                float parsedGrade;
                Console.Write("Please Input the Corresponding Grade: ");

                do //Handles input validation
                {
                    gradeInputString = Console.ReadLine();

                    validGradeInput = Validator.isValidInput<float>(gradeInputString, out parsedGrade);

                    if (!validGradeInput)
                    {
                        Console.Write("Invalid input, please enter a valid number: ");
                    }
                    else if (parsedGrade < 0f || parsedGrade > 100f) //Input value range-validation conditional 
                    {
                        Console.Write("Value is beyond the percentage range. \nPlease enter a number between 0-100: ");
                        validGradeInput = false;
                    }

                } while (!validGradeInput);

                Console.WriteLine();

                course_Names[i] = input_Name;
                grades[i] = parsedGrade;
            }
        }

        //Display inputted course name and their corresponding grade
        static void see_Grades()
        {
            Console.WriteLine("Here are your grades:");
            for (int i = 0; i < course_Amount; i++)
            {
                Console.WriteLine(course_Names[i] + " | " + grades[i]);
            }
            Console.WriteLine();
        }

        /*Calculation of max and min grades in the array; Iterates until max/min found then finds indexes
            of similar values for printing*/
        static void see_MinMaxGrades()
        {
            int currentMin = 0;
            int currentMax = 0;

            for (int i = 1; i < course_Amount; i++) //Loop to find the max and min float value
            {
                if (grades[i] == Math.Max(grades[currentMax], grades[i]))
                    currentMax = grades[i] > grades[currentMax] ? i : currentMax;

                if (grades[i] == Math.Min(grades[currentMin], grades[i]))
                    currentMin = grades[i] < grades[currentMin] ? i : currentMin;
            }

            float minGrade = grades[currentMin];
            float maxGrade = grades[currentMax];

            Console.WriteLine("Maximum Grade(s):");
            for (int i = 0; i < course_Amount; i++) //Loop for finding similar max/min values then print
            {
                if (grades[i] == maxGrade)
                {
                    Console.WriteLine($"{course_Names[i]} | {grades[i]}");
                }
            }

            Console.WriteLine("\nMinimum Grade(s):");
            for (int i = 0; i < course_Amount; i++)
            {
                if (grades[i] == minGrade)
                {
                    Console.WriteLine($"{course_Names[i]} | {grades[i]}");
                }
            }

            Console.WriteLine();
        }

        //Calculation and display of overall grade (Summation of values in grades[]) & average (overall/ # of courses)
        //Rounding to 2 decimal places. Applies 0-4 round down; 5-9 round up
        static void see_TotalAndAverage()
        {
            float totalGrade = 0;

            for (int i = 0; i < course_Amount; i++)
            {
                totalGrade += grades[i];
            }

            float averageGrade = totalGrade / course_Amount;

            totalGrade = (float)Math.Round(totalGrade, 2, MidpointRounding.AwayFromZero);
            averageGrade = (float)Math.Round(averageGrade, 2, MidpointRounding.AwayFromZero);

            float aveGradeConverted = Convert_Grade(averageGrade);
            Console.WriteLine($"Overall Grade: {totalGrade}");
            Console.WriteLine($"Average Grade: {averageGrade} | {aveGradeConverted:F2}\n");

        }
        /*If-else-if statements for calculating the equivalence(In STI College Grading System)
        of the % grade input from user*/
        static void grade_Equivalent()
        {
            float equivalentGrade = 0f;
            String[] lowerCasedNames = new String[course_Amount];
            bool repeat = true;
            see_Grades();

            do
            {
                Console.Write("\nPlease input the course name of the course you want to see its equivalent grades in: ");
                bool invalidInput = true;

                do //Handles input validation
                {
                    for (int i = 0; i < course_Names.Length; i++)
                    {
                        lowerCasedNames[i] = course_Names[i].ToLower();
                    }

                    input_Name = Console.ReadLine();

                    if (!lowerCasedNames.Contains(input_Name.Trim().ToLower()))
                    {
                        Console.WriteLine("\nInvalid Input, name not found in the list");
                        Console.Write("\nPlease input the course name again? ");
                    }
                    else
                    {
                        invalidInput = false;
                    }
                } while (invalidInput);

                int index = Array.IndexOf(lowerCasedNames, input_Name.Trim().ToLower());
                float grade = grades[index];

                equivalentGrade = Convert_Grade(grade);

                Console.WriteLine("\nEquivalent Grade:");
                Console.WriteLine(course_Names[index] + " | " + grade + " | " + $"{equivalentGrade:F2}");

                repeat = AskYesNo("\nDo you still want to find the equivalent grade of a course? (yes/no)? ");
            } while (repeat);
        }

        static float Convert_Grade(float input)
        {
            float equivalentGrade = 0f;
            if (input >= 97.5f && input <= 100.00f)
                equivalentGrade = 1.00f;
            else if (input >= 94.5f)
                equivalentGrade = 1.25f;
            else if (input >= 91.5f)
                equivalentGrade = 1.50f;
            else if (input >= 86.5f)
                equivalentGrade = 1.75f;
            else if (input >= 81.5f)
                equivalentGrade = 2.00f;
            else if (input >= 76.0f)
                equivalentGrade = 2.25f;
            else if (input >= 70.5f)
                equivalentGrade = 2.50f;
            else if (input >= 65.0f)
                equivalentGrade = 2.75f;
            else if (input >= 59.5f)
                equivalentGrade = 3.00f;
            else if (input >= 0f)
                equivalentGrade = 5.00f;
            else
                Console.WriteLine("\nThis course is either dropped or incomplete requirements");

            return equivalentGrade;

        }

        //Input Validation method for Yes or No questions
        static bool AskYesNo(string prompt)
        {
            Console.Write(prompt);
            while (true)
            {
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "yes")
                    return true;
                else if (input == "no")
                    return false;
                else
                    Console.WriteLine("\nInvalid input. Please type 'yes' or 'no'.");
            }
        }

    }

    //Input Validation Class 
    static class Validator
    {
        //Method for all inputs (except yes/no) validation
        /*Validates if user input (String), can be parsed into the specified data type.
            Yes = returns result/input to its specified type; No = repeats ask of valid input*/
        public static bool isValidInput<T>(string input, out T result) //accepts string inputs, if validated, outputs the input into its type
        {
            result = default;
            bool success;
            input = input.Trim();

            if (typeof(T) == typeof(int)) //Validation for int inputs
            {
                int parsedInput;
                success = int.TryParse(input, out parsedInput);
                result = (T)(object)parsedInput;
                return success;
            }
            else if (typeof(T) == typeof(string)) //Validation for string inputs
            {
                success = !string.IsNullOrWhiteSpace(input);
                result = (T)(object)input;
                return success;
            }
            else if (typeof(T) == typeof(float)) //Validation for float inputs
            {
                float parsedInput;
                success = float.TryParse(input, out parsedInput);
                result = (T)(object)parsedInput;
                return success;
            }
            else //Loop back if input is invalid
            {
                return false;
            }
        }
    }
}
//THIS IS A TEMPLATE FILE 
