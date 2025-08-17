using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Salangsang : Student
    {
        public static int SubjectCount;
        public static string[] Subjects;
        public static string Header;
        public static float[] RawGrades;
        public static string[] ArraySubnameGrade;
        public static float[] EquivalentGrades;
        public static void Toptext()
        {
            // This is the top text, it also handles the headers of which method is being used
            Console.Clear();
            string firstMessage = "Grade Visualizer and GWA Calculator v1";
            int position = (Console.WindowWidth - firstMessage.Length) / 2;
            Console.SetCursorPosition(position, Console.CursorTop);
            Console.WriteLine(firstMessage);
            // Simple check to see if header is not empty so it does not print out an empty header
            if (Header != null)
            {
                int headerPosition = (Console.WindowWidth - Header.Length) / 2;
                Console.SetCursorPosition(headerPosition, Console.CursorTop + 1);
                Console.WriteLine(Header);
            }
        }
        public static void Startprocess()
        {
            // Just the instructions for the user
            Toptext();
            Console.WriteLine("Instructions:");
            Thread.Sleep(1000);
            Console.WriteLine("1. Enter subject name (e.g. Computer Programming 3).");
            Thread.Sleep(400);
            Console.WriteLine("2. Enter raw grade (e.g 98).");
            Thread.Sleep(400);
            Console.WriteLine("The equivalent grade will then be calculated through the raw grade.");
            Thread.Sleep(400);
            Console.WriteLine("Press any button to proceed...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void SetArrayOfSubjects()
        {
            // Asks the user how many subjects they want to evaluate
            // Also handles errors
            Header = "Subject Count";
            Toptext();
            while (true)
            {
                Console.Write("Insert amount of subjects to be evaluated: ");
                try
                {
                    SubjectCount = int.Parse(Console.ReadLine());
                    if (SubjectCount > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a positive integer.");
                    }
                }
                catch
                {
                    Console.Clear();
                    Toptext();
                    Console.WriteLine("Invalid Format");
                }
            }
            // Setter for the subject names
            Header = "Subject Name Setter";
            Subjects = new String[SubjectCount];
            for (int i = 0; i < SubjectCount; i++)
            {
                Toptext();
                if (Subjects != null) { Console.WriteLine(string.Join(" | ", Subjects)); }
                Console.Write("Enter subject name: ");
                Subjects[i] = Console.ReadLine();
            }
            Console.Clear();
            Toptext();
            Console.WriteLine("These are the inputted subjects: ");
            Console.WriteLine(string.Join(" | ", Subjects));
            Console.WriteLine("Press any button to proceed...");
            Console.ReadKey();
            Header = null;
            Console.Clear();
        }
        public static void SetRawGrade()
        {
            // sets the raw grades for each subject
            Header = "Raw Grade Setter";
            RawGrades = new float[SubjectCount];
            ArraySubnameGrade = new string[SubjectCount];
            for (int i = 0; i < SubjectCount; i++)
            {
                // This is used to show the user which subject they are currently inputting the raw grade for
                // the dollar sign is used to show the variable value in the string
                Toptext();
                for (int j = 0; j < SubjectCount; j++)
                {
                    if (j < i) ArraySubnameGrade[j] = $"{Subjects[j]}: {RawGrades[j]}";
                    else if (j == i) ArraySubnameGrade[j] = $"{Subjects[j]}:...";
                    else ArraySubnameGrade[j] = $"{Subjects[j]}: N/A";
                }
                Console.WriteLine(string.Join(" | ", ArraySubnameGrade));
                Console.Write($"Enter raw grade for {Subjects[i]}: ");
                // This loop is used to handle errors in the input format
                while (true)
                {
                    try
                    {
                        RawGrades[i] = float.Parse(Console.ReadLine());
                        ArraySubnameGrade[i] = $"{Subjects[i]}: {RawGrades[i]}";
                        break;
                    }
                    catch
                    {
                        Console.Clear();
                        Toptext();
                        Console.WriteLine(string.Join(" | ", ArraySubnameGrade));
                        Console.WriteLine("Invalid Format");
                        Console.Write($"Enter raw grade for {Subjects[i]} ");
                    }
                }
            }
            Console.Clear();
            Toptext();
            Console.WriteLine("These are the inputted raw grades: ");
            Console.WriteLine(string.Join(" | ", ArraySubnameGrade));
            Console.WriteLine("Press any button to proceed...");
            Console.ReadKey();
            Header = null;
        }
        public static void EquivalentConditions()
        {
            // This method is used to calculate the equivalent grades based on the raw grades (refer to one sti)
            Header = "Equivalent Grades";
            Toptext();
            float[] EqGr = new float[SubjectCount];
            for (int i = 0; i < SubjectCount; i++)
            {
                Console.SetCursorPosition(Console.CursorLeft + 5, Console.CursorTop);
                if (RawGrades[i] >= 97.49) { EqGr[i] = 1.00f; }
                else if (RawGrades[i] >= 94.49) { EqGr[i] = 1.25f; }
                else if (RawGrades[i] >= 91.49) { EqGr[i] = 1.50f; }
                else if (RawGrades[i] >= 86.49) { EqGr[i] = 1.75f; }
                else if (RawGrades[i] >= 81.49) { EqGr[i] = 2.00f; }
                else if (RawGrades[i] >= 75.99) { EqGr[i] = 2.25f; }
                else if (RawGrades[i] >= 70.49) { EqGr[i] = 2.50f; }
                else if (RawGrades[i] >= 65.49) { EqGr[i] = 2.75f; }
                else if (RawGrades[i] >= 59.49) { EqGr[i] = 3.00f; }
                else { EqGr[i] = 5.00f; }
                // Used to change subject: rawGrade to subject | rawGrade
                ArraySubnameGrade[i] = $"{Subjects[i]} | {RawGrades[i]}";
                Console.WriteLine($"{ArraySubnameGrade[i]} | {EqGr[i]:0.00}");
            }
            Console.WriteLine("Press any key to proceed...");
            Console.ReadKey();
            EquivalentGrades = EqGr;
        }
        public static void OperationMenu()
        {
            // This method is used to show the user the operations they can do with the grades
            // Admittedly, this uses some outsourced code from the internet to make the menu work
            bool running = true;
            while (running)
            {
                Header = "What would you like to do with the grades?";
                Toptext();
                ConsoleKeyInfo key;
                Console.WriteLine("Use the Up/Down arrow to navigate and press Enter or Return to select");
                int selectedIndex = 0;
                bool isSelected = false;
                string[] operations = new string[]
                {
            "Get Maximum Grade",
            "Get Average Grade",
            "Get Minimum Grade",
            "Get Overall Grade",
            "Stop The Program"
                };
                string color = "\u001b[32m";
                Console.CursorVisible = false;
                while (!isSelected)
                {
                    Console.Clear();
                    Toptext();

                    for (int i = 0; i < operations.Length; i++)
                    {

                        if (i == selectedIndex)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"{color} {operations[i]}");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ResetColor();
                            Console.WriteLine($"  {operations[i]}");
                        }
                    }

                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedIndex = (selectedIndex == 0) ? operations.Length - 1 : selectedIndex - 1;
                            break;
                        case ConsoleKey.DownArrow:
                            selectedIndex = (selectedIndex == operations.Length - 1) ? 0 : selectedIndex + 1;
                            break;
                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;
                    }
                }
                Console.Clear();
                // This switch statement handles the operations based on the user's selection
                switch (operations[selectedIndex])
                {
                    case "Get Maximum Grade":
                        Header = "Maximum Grade";
                        Toptext();
                        float maxGrade = RawGrades[0];
                        for (int i = 1; i < SubjectCount; i++) { maxGrade = Math.Max(maxGrade, RawGrades[i]); }
                        Console.WriteLine($"Maximum Grade: {maxGrade}");
                        Console.WriteLine("Press any button to return to the menu...");
                        Console.ReadKey();
                        break;
                    case "Get Average Grade":
                        Header = "Average Grade";
                        Toptext();
                        float total = 0;
                        for (int i = 0; i < SubjectCount; i++) { total += RawGrades[i]; }
                        float average = (float)Math.Round(total / SubjectCount, 2);
                        Console.WriteLine($"Average Grade: {average}");
                        Console.WriteLine("Press any button to return to the menu...");
                        Console.ReadKey();
                        break;
                    case "Get Minimum Grade":
                        Header = "Minimum Grade";
                        Toptext();
                        float minGrade = RawGrades[0];
                        for (int i = 1; i < SubjectCount; i++) { minGrade = Math.Min(minGrade, RawGrades[i]); }
                        Console.WriteLine($"Minimum Grade: {minGrade}");
                        Console.WriteLine("Press any button to return to the menu...");
                        Console.ReadKey();
                        break;
                    case "Get Overall Grade":
                        Header = "Overall Grade";
                        Toptext();
                        Console.WriteLine("Overall Grade: ");
                        float rawTotal = 0;
                        float eqTotal = 0;
                        for (int i = 0; i < SubjectCount; i++)
                        {
                            rawTotal += RawGrades[i];
                            eqTotal += EquivalentGrades[i];
                        }
                        float overallGrade = (float)Math.Round(rawTotal / SubjectCount, 2);
                        float overallEquivalent = (float)Math.Round(eqTotal / SubjectCount, 2);
                        Console.WriteLine($"Overall Grade: {overallGrade} | {overallEquivalent}.");
                        Console.WriteLine("Press any button to return to the menu...");
                        Console.ReadKey();
                        break;
                    case "Stop The Program":
                        Console.Clear();
                        Header = "Exit Program";
                        Toptext();
                        Thread.Sleep(1000);
                        running = false;
                        break;
                }
            }
        }
        public override void Run()
        {
            Console.WriteLine("Running Salangsang's code...");
            Startprocess();
            SetArrayOfSubjects();
            SetRawGrade();
            EquivalentConditions();
            OperationMenu();
            // To counteract the cursor visibility being set to false in previous methods (menu method)
            Console.CursorVisible = true;
            Console.WriteLine("\nAuthored by: Aaron Salangsang");
        }
   
    }
}
//THIS IS A TEMPLATE FILE 
