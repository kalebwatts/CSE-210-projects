using System;
using System.Collections.Generic;


public class Journal
{
    public List<Entry> Entries { get; private set; } = new List<Entry>();

    public void SaveEntry(Entry entry)
    {
        Entries.Add(entry);
        Console.WriteLine("Entry saved to journal.");
    }
}


