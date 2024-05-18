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
                    Entry entryManager = new Entry(prompt, entryText);
                    journal.SaveEntry(entryManager);
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter the filename to save the journal: ");
                    string saveFileName = Console.ReadLine();
                    SaveJournalToFile(saveFileName);
                    break;
                case "4":
                    Console.Write("Enter the filename to load the journal: ");
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
        foreach (var entry in journal.Entries)
        {
            Console.WriteLine($"Date: {entry.DateTime}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Entry: {entry.EntryText}");
            Console.WriteLine();
        }
    }

    static void SaveJournalToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in journal.Entries)
            {
                writer.WriteLine(entry.DateTime);
                writer.WriteLine(entry.Prompt);
                writer.WriteLine(entry.EntryText);
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
                    string entryText = reader.ReadLine();
                    journal.SaveEntry(new Entry(prompt, entryText, date));
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