using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradePercentage = Console.ReadLine();
        int grade = int.Parse(gradePercentage);

         string letter = "";

         if (grade >= 90.0)
         {
            letter = "A";
         }
         else if (grade >= 80 && grade < 90)
         {
            letter = "B";
         }
         else if (grade >= 70 && grade < 80)
         {
            letter = "C";
         }
         else if (grade >= 60 && grade < 70)
         {
            letter = "D";
         }
         else
         {
            letter = "F";
         }

         Console.WriteLine($"Your grade is: {letter}");

         if (grade >= 70)
         {
            Console.Write("You passed! :)");
         }
         else
         {
            Console.Write("You did not pass :(");
         }
    }
}