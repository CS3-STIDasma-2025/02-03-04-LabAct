using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    class Subject
    {
        public string name { get; set; }
        public int grade { get; set; }
        public float average { get; set; }
    }
    internal class Alberto : Student
    {
        public override void Run()
        {
            List<Subject> subjs = new List<Subject>();

            Console.Write("Enter student's surname: ");
            string student = Console.ReadLine().ToUpper();
            while (true)
            {
                Console.Write("Enter subject (or type 'STOP' to exit): ");
                string sub = Console.ReadLine().ToUpper();
                if (sub == "STOP")
                {
                    break;
                }

                Console.Write("Enter grade: ");
                int grd = int.Parse(Console.ReadLine());
                float avg = getEquival(grd);

                subjs.Add(new Subject { name = sub, grade = grd, average = avg });
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nStudent: " + student);
            foreach (var subject in subjs)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{subject.name} | {subject.grade} | {subject.average}");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            subjs.Sort((a, b) => a.grade.CompareTo(b.grade));
            Subject largest = subjs[subjs.Count - 1];
            Console.WriteLine("Highest Grade: ");
            Console.WriteLine($"{largest.name} | {largest.grade} | {largest.average}");

            Console.ForegroundColor = ConsoleColor.Red;
            Subject smallest = subjs[0];
            Console.WriteLine("Lowest Grade: ");
            Console.WriteLine($"{smallest.name} | {smallest.grade} | {smallest.average}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            double average = subjs.Average(s => s.grade);
            Console.WriteLine($"Average Grade: {average:F2} | {getEquival((float)average):F2}");
            int overall = subjs.Sum(s => s.grade);
            Console.WriteLine($"Total Grade: {overall}");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nAuthored by: Alberto");
            Console.ReadKey();

        }
        static float getEquival(float n)
        {
            if (n >= 97.5)
            {
                return 1f;
            }
            else if (n >= 94.5)
            {
                return 1.25f;
            }
            else if (n >= 91.5)
            {
                return 1.5f;
            }
            else if (n >= 86.5)
            {
                return 1.75f;
            }
            else if (n >= 81.5)
            {
                return 2f;
            }
            else if (n >= 76)
            {
                return 2.25f;
            }
            else if (n >= 70.5)
            {
                return 2.5f;
            }
            else if (n >= 65)
            {
                return 2.75f;
            }
            else if (n >= 59.5)
            {
                return 3f;
            }
            else
            {
                return 5f;
            }
        }

    }
}