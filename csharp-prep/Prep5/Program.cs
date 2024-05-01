using System;

class Program
{
    static void Main(string[] args)
    {
        // Display welcome message
        DisplayWelcomeMessage();

        // Prompt user for name and store it
        string userName = PromptUserName();

        // Prompt user for favorite number and store it
        int userNumber = PromptUserNumber();

        // Calculate square of the user's number
        int squaredNumber = SquareNumber(userNumber);

        // Display the result
        DisplayResult(userName, squaredNumber);
    }

    // Function to display welcome message
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function to prompt user for their name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Function to prompt user for their favorite number and return it
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Function to square a given number and return the result
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    // Function to display the user's name and the squared number
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}
