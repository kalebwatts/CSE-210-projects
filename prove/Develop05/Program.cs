using System;
using System.IO;
using System.Threading;  


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name:");
            string userName = Console.ReadLine();
            User user = new User(userName);
            GoalManager goalManager = new GoalManager();

            while (true)
            {
                ShowLoadingAnimation("Loading Menu", 3);  
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Create a new goal");
                Console.WriteLine("2. Record an event");
                Console.WriteLine("3. Display goals");
                Console.WriteLine("4. Display score");
                Console.WriteLine("5. Save goals");
                Console.WriteLine("6. Load goals");
                Console.WriteLine("7. Delete saved goals");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateGoal(user, goalManager);
                        break;
                    case "2":
                        RecordEvent(user);
                        break;
                    case "3":
                        user.DisplayGoals();
                        break;
                    case "4":
                        Console.WriteLine(user.DisplayScore());
                        break;
                    case "5":
                        SaveGoals(user);
                        break;
                    case "6":
                        LoadGoals(user);
                        break;
                    case "7":
                        DeleteGoals();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CreateGoal(User user, GoalManager goalManager)
        {
            ShowLoadingAnimation("Creating New Goal", 3);  
            Console.WriteLine("Select goal type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Enter your choice: ");
            string typeChoice = Console.ReadLine();

            string type = typeChoice switch
            {
                "1" => "SimpleGoal",
                "2" => "EternalGoal",
                "3" => "ChecklistGoal",
                _ => null
            };

            if (type == null)
            {
                Console.WriteLine("Invalid choice. Goal not created.");
                return;
            }

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();

            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();

            Console.Write("Enter points for the goal: ");
            int points = int.Parse(Console.ReadLine());

            if (type == "ChecklistGoal")
            {
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());

                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());

                Goal checklistGoal = goalManager.CreateGoal(type, name, description, points, targetCount, bonusPoints);
                user.AddGoal(checklistGoal);
            }
            else
            {
                Goal goal = goalManager.CreateGoal(type, name, description, points);
                user.AddGoal(goal);
            }

            ShowProgressBar("Saving Goal", 5);  
            Console.WriteLine("Goal created successfully!");
        }

        static void RecordEvent(User user)
        {
            user.DisplayGoals();
            Console.Write("Enter the number of the goal to record: ");
            int goalNumber = int.Parse(Console.ReadLine());

            if (goalNumber > 0 && goalNumber <= user.Goals.Count)
            {
                ShowLoadingAnimation("Recording Event", 3);  
                user.RecordEvent(user.Goals[goalNumber - 1]);
                ShowShootingStarsAnimation();  
                Console.WriteLine("Event recorded successfully!");
            }
            else
            {
                Console.WriteLine("Invalid goal number. Please try again.");
            }
        }

        static void SaveGoals(User user)
        {
            Console.Write("Enter the filename to save goals: ");
            string filename = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filename))
            {
                Console.WriteLine("Invalid filename. Goals not saved.");
                return;
            }

            ShowLoadingAnimation("Saving Goals", 3);  
            string savedData = user.SaveGoals();
            File.WriteAllText(filename, savedData);
            Console.WriteLine($"Goals saved successfully to {filename}!");
        }

        static void LoadGoals(User user)
        {
            Console.Write("Enter the filename to load goals: ");
            string filename = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filename))
            {
                Console.WriteLine("Invalid filename. Goals not loaded.");
                return;
            }

            ShowLoadingAnimation("Loading Goals", 3);  
            if (File.Exists(filename))
            {
                string loadedData = File.ReadAllText(filename);
                user.LoadGoals(loadedData);
                Console.WriteLine("Goals loaded successfully!");
            }
            else
            {
                Console.WriteLine($"No saved goals found in {filename}.");
            }
        }

        static void DeleteGoals()
        {
            Console.WriteLine("Saved Goals:");
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");

            if (files.Length == 0)
            {
                Console.WriteLine("No saved goals found.");
                return;
            }

            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}");
            }

            Console.Write("Enter the number of the file to delete: ");
            if (int.TryParse(Console.ReadLine(), out int fileNumber) && fileNumber > 0 && fileNumber <= files.Length)
            {
                string fileToDelete = files[fileNumber - 1];
                Console.Write($"Are you sure you want to delete {Path.GetFileName(fileToDelete)}? (y/n): ");
                string confirmation = Console.ReadLine();

                if (confirmation?.ToLower() == "y")
                {
                    File.Delete(fileToDelete);
                    Console.WriteLine($"{Path.GetFileName(fileToDelete)} deleted successfully!");
                }
                else
                {
                    Console.WriteLine("File deletion canceled.");
                }
            }
            else
            {
                Console.WriteLine("Invalid file number. No file was deleted.");
            }
        }

        static void ShowLoadingAnimation(string message, int dots)
        {
            Console.Write(message);
            for (int i = 0; i < dots; i++)
            {
                Thread.Sleep(500);  
                Console.Write(".");
            }
            Console.WriteLine();
        }

        static void ShowProgressBar(string message, int steps)
        {
            Console.Write(message);
            Console.Write("[");
            for (int i = 0; i < steps; i++)
            {
                Thread.Sleep(300);  
                Console.Write("#");
            }
            Console.WriteLine("]");
        }

        static void ShowShootingStarsAnimation()
        {
            Console.Clear(); 
            string[] shootingStars = new string[]
            {
                @"              *",
                @"            *     ",
                @"         *          ",
                @"      *               ",
                @"         *          ",
                @"            *     ",
                @"              *",
                @"                 *     ",
                @"                    *     ",
                @"                       *     ",
                @"                          *",
                @"                       *",
                @"                    *",
                @"                *",
            };

            foreach (var line in shootingStars)
            {
                Console.WriteLine(line);
                Thread.Sleep(150); 
            }

            Thread.Sleep(1000); 
            Console.Clear(); 
        }
    }

