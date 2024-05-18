using System;
using System.Collections.Generic;


public class Journal
{
    public List<string> Dates { get; private set; } = new List<string>();
    public List<string> Prompts { get; private set; } = new List<string>();
    public List<string> Entries { get; private set; } = new List<string>();

    public void SaveEntry(string date, string prompt, string entry)
    {
        Dates.Add(date);
        Prompts.Add(prompt);
        Entries.Add(entry);
        Console.WriteLine("Entry saved to journal.");
    }
}


