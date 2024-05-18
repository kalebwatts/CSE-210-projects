using System;

public class Entry
{
    public string DateTime { get; private set; }
    public string Prompt { get; private set; }
    public string EntryText { get; private set; }

    public Entry(string prompt, string entryText)
    {
        DateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Current date and time
        Prompt = prompt;
        EntryText = entryText;
    }

    public Entry(string prompt, string entryText, string dateTime)
    {
        DateTime = dateTime;
        Prompt = prompt;
        EntryText = entryText;
    }
}