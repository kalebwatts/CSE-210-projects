using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    static Journal journal = new Journal();

    static void Main(string[] args)
    {
        Program program = new Program();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            program.DisplayMenu();
            Console.Write("Please enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GeneratePrompt();
                    Console.WriteLine(prompt);
                    Console.WriteLine("Write your entry:");
                    string entryText = Console.ReadLine();
                    Entry entryManager = new Entry();
                    entryManager.AddEntry(prompt, entryText, journal);
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    Console.WriteLine("Enter the filename to save to the journal:");
                    string saveFileName = Console.ReadLine();
                    SaveJournalToFile(saveFileName);
                    break;
                case "4":
                    Console.WriteLine("Enter the filename to load from the journal:");
                    string loadFileName = Console.ReadLine();
                    LoadJournalFromFile(loadFileName);
                    break;
                case "5":
                    Console.WriteLine("Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                    break;
            }
        }
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the Journal");
        Console.WriteLine("3. Save to file");
        Console.WriteLine("4. Load from file");
        Console.WriteLine("5. Quit");
    }

    static void DisplayJournal()
    {
        Console.WriteLine("Journal Entries:");
        for (int i = 0; i < journal.Dates.Count; i++)
        {
            Console.WriteLine($"Date: {journal.Dates[i]}");
            Console.WriteLine($"Prompt: {journal.Prompts[i]}");
            Console.WriteLine($"Entry: {journal.Entries[i]}");
            Console.WriteLine();
        }
    }

    static void SaveJournalToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            for (int i = 0; i < journal.Dates.Count; i++)
            {
                writer.WriteLine(journal.Dates[i]);
                writer.WriteLine(journal.Prompts[i]);
                writer.WriteLine(journal.Entries[i]);
            }
        }
        Console.WriteLine($"Journal entries saved to {fileName}.");
    }

    static void LoadJournalFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            journal = new Journal(); // Reset journal to avoid duplicate entries

            using (StreamReader reader = new StreamReader(fileName))
            {
                string date;
                while ((date = reader.ReadLine()) != null)
                {
                    string prompt = reader.ReadLine();
                    string entry = reader.ReadLine();
                    journal.SaveEntry(date, prompt, entry);
                }
            }
            Console.WriteLine($"Journal entries loaded from {fileName}.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}