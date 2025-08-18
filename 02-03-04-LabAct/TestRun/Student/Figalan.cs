using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal abstract class Figalan : Student
    {
        public override void Run()
        {

            Thread.Sleep(900);
            Console.WriteLine("PLEASE ENTER THESE FOLLOWING:: ");
            Thread.Sleep(900);
            Console.WriteLine("- STUDENT'S NAME");
            Thread.Sleep(900);
            Console.WriteLine("- COURSE NAME");
            Thread.Sleep(900);
            Console.WriteLine("- GRADES FOR PRELIM, MIDTERM, PRE FINALS AND FINALS");
            Console.WriteLine("");
            Thread.Sleep(900);
            Console.WriteLine("PRESS ANY KEY TO START");
            Console.ReadKey();
            Console.Clear();

            //---------------------------------------------------------//

            Thread.Sleep(1000);
            Console.WriteLine("Please enter your name:: ");
            string name = Console.ReadLine();
            string[] studentName = { name };

            Console.WriteLine("Please enter your course name:: ");
            string input = Console.ReadLine();

            string[] term = { "PRELIM", "MIDTERM", "PRE FINALS", "FINALS" };

            string[] course = { input };

            float[] grades = new float[4];
            int i = 0;

            do
            {
                Console.Write($"Enter grade for {term[i]}: ");
                grades[i] = float.Parse(Console.ReadLine());
                if (grades[i] < 0)
                {
                    Console.WriteLine("You can't input a negative number/grade");
                    break;
                }
                i++;
            } while (i < grades.Length);

            Console.WriteLine("\nGrades you entered:");
            foreach (float g in grades)
            {
                Console.WriteLine(g);
            }

            Thread.Sleep(1000);
            Console.WriteLine("Calculating...");
            Thread.Sleep(1000);
            Console.WriteLine("PLEASE WAIT...");
            Thread.Sleep(1800);

            //---------------------------------------------------------//

            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine($"Grades you entered for {course[0]}:\n");
            Thread.Sleep(1800);
            for (int w = 0; w < term.Length; w++)
            {
                string equi;
                if (grades[w] >= 97.50) equi = "1.00";
                else if (grades[w] >= 94.50) equi = "1.25";
                else if (grades[w] >= 91.50) equi = "1.50";
                else if (grades[w] >= 86.50) equi = "1.75";
                else if (grades[w] >= 81.50) equi = "2.00";
                else if (grades[w] >= 76.00) equi = "2.25";
                else if (grades[w] >= 70.50) equi = "2.50";
                else if (grades[w] >= 65.00) equi = "2.75";
                else if (grades[w] >= 59.50) equi = "3.00";
                else equi = "5.00";

                Console.WriteLine($"{course[0]} | {term[w],-10} | {grades[w]} | {equi}");
                Thread.Sleep(900);
            }

            float max = grades[0];
            float min = grades[0];
            float total = 0; ;

            foreach (float r in grades)
            {
                max = Math.Max(max, r);
                min = Math.Min(min, r);
                total += r;
            }
            float avg = total / grades.Length;
            avg = (float)Math.Round(avg, 2);
            Console.WriteLine("");
            Thread.Sleep(900);

            Console.WriteLine("HI! " + name + " these are all of the results::\n ");
            Thread.Sleep(900);
            Console.WriteLine($"Results:: ");
            Thread.Sleep(900);
            Console.WriteLine($"Maximum Grade: {max:F2}");
            Thread.Sleep(900);
            Console.WriteLine($"Minimum Grade: {min:F2}");
            Thread.Sleep(900);
            Console.WriteLine($"Average Grade: {avg:F2}");
            Thread.Sleep(900);
            float sum = grades[0] + grades[1] + grades[2] + grades[3];
            Console.WriteLine($"Overall Grade: {sum:F2}");

            string overallEqui;
            if (avg >= 97.50) overallEqui = "1.00";
            else if (avg >= 94.50) overallEqui = "1.25";
            else if (avg >= 91.50) overallEqui = "1.50";
            else if (avg >= 86.50) overallEqui = "1.75";
            else if (avg >= 81.50) overallEqui = "2.00";
            else if (avg >= 76.00) overallEqui = "2.25";
            else if (avg >= 70.50) overallEqui = "2.50";
            else if (avg >= 65.00) overallEqui = "2.75";
            else if (avg >= 59.50) overallEqui = "3.00";
            else overallEqui = "5.00";

            Thread.Sleep(900);
            Console.WriteLine($"Equivalent Grade: {overallEqui}");

            Console.WriteLine("");
            Thread.Sleep(900);
            Console.WriteLine($"{course[0]} | {avg:F2} | {overallEqui}");
            Thread.Sleep(1000);

            Console.WriteLine("");
            Console.WriteLine("Author: FIGALAN");
            Thread.Sleep(1000);
        }
    }
}