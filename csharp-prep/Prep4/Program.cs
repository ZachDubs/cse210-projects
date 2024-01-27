using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNumbers = -1;

        Console.WriteLine("Please enter your numbers. We will stop at 0. ");

        while (userNumbers != 0)
        {
            Console.Write("Enter your number: ");
            string numbersEntered = Console.ReadLine();
            userNumbers = int.Parse(numbersEntered);

            if (userNumbers != 0)
            {
            numbers.Add(userNumbers);
            }
        }

        int sum = 0;

        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The total is: {sum}");

        float average = (float)sum/numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int maximum = numbers[0];

        foreach (int number in numbers)
        {
            if (number > maximum)
            {
                maximum = number;
            }
        }

        Console.Write($"The biggest number is: {maximum}");
    }
}