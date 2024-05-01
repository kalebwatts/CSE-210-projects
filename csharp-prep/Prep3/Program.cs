using System;

class Program
{
    static void Main(string[] args)
    {
        // For parts 1 and 2
        // Console.Write("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());
        Random random = new Random();
        int magicNumber = random.Next(1, 101);

        Console.WriteLine("Welcome to Guess My Number Game!");
        Console.WriteLine("I've picked a magic number between 1 and 100.");
        Console.WriteLine("Try to guess it!");

        int guess;
        do
        {
            Console.Write("Enter your guess: ");
            guess = Convert.ToInt32(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }

            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }

            else
            {
                Console.WriteLine("You guessed it!");
            }
        } while (guess != magicNumber);
    }
}