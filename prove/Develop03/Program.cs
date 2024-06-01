using System;


    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            Reference reference = GetReferenceFromUser();
            string text = GetScriptureTextFromUser();
            Scripture scripture = new Scripture(reference, text);

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.ToString());
                Console.WriteLine("\nPress Enter to hide a word or part of the reference, or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }

                scripture.HideElement();

                if (scripture.IsAllHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.ToString());
                    Console.WriteLine("\nYou rock!");
                    break;
                }
            }
        }

        static Reference GetReferenceFromUser()
        {
            while (true)
            {
                Console.WriteLine("What is the scripture reference (e.g., 1 Nephi 3:7 or Proverbs 3:5-6)?");
                string input = Console.ReadLine();

                int lastSpaceIndex = input.LastIndexOf(' ');
                if (lastSpaceIndex == -1)
                {
                    Console.WriteLine("Invalid format. Please try again.");
                    continue;
                }

                string book = input.Substring(0, lastSpaceIndex);
                string[] chapterVerseParts = input.Substring(lastSpaceIndex + 1).Split(new[] { ':', '-' });

                if (chapterVerseParts.Length < 2 || chapterVerseParts.Length > 4)
                {
                    Console.WriteLine("Invalid format. Please try again.");
                    continue;
                }

                try
                {
                    int startChapter = int.Parse(chapterVerseParts[0]);
                    int startVerse = int.Parse(chapterVerseParts[1]);

                    if (chapterVerseParts.Length == 2)
                    {
                        return new Reference(book, startChapter, startVerse);
                    }
                    else if (chapterVerseParts.Length == 3)
                    {
                        int endVerse = int.Parse(chapterVerseParts[2]);
                        return new Reference(book, startChapter, startVerse, startChapter, endVerse);
                    }
                    else if (chapterVerseParts.Length == 4)
                    {
                        int endChapter = int.Parse(chapterVerseParts[2]);
                        int endVerse = int.Parse(chapterVerseParts[3]);
                        return new Reference(book, startChapter, startVerse, endChapter, endVerse);
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid format. Please try again.");
                }
            }
        }

        static string GetScriptureTextFromUser()
        {
            Console.WriteLine("What is the scripture verse?");
            return Console.ReadLine();
        }
    }