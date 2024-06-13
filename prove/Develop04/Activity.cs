using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        ShowMessage($"Starting {_name}");
        ShowMessage(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        ShowMessage("Prepare to begin...");
        DisplayCountdown(3);
    }

    public void EndActivity()
    {
        ShowMessage($"Inner peace accomplished! You've completed the {_name} for {_duration} seconds.");
        DisplayCountdown(3);
    }

    protected void DisplayCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}...\r");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public abstract void ExecuteActivity();
}