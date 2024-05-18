using System;

public class Entry
{
    public string GetDateTime()
    {
        return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Current date and time
    }

    public void AddEntry(string prompt, string entry, Journal journal)
    {
        string dateTime = GetDateTime();
        journal.SaveEntry(dateTime, prompt, entry);
    }
}