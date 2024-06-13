using System;
using System.Collections.Generic;

public class Listing : Activity
{
    private static readonly List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public Listing() : base("Listing Activity", 
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    private string SelectPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    public override void ExecuteActivity()
    {
        ShowMessage(SelectPrompt());
        DisplayCountdown(5);
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("List an item: ");
            items.Add(Console.ReadLine());
        }
        ShowMessage($"You listed {items.Count} items.");
    }
}
