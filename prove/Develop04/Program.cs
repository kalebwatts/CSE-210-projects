using System;

public class UserInterface
{
    public void DisplayMenu()
    {
        ShowMessage("Select an activity:");
        ShowMessage("1. Breathing Activity");
        ShowMessage("2. Reflection Activity");
        ShowMessage("3. Listing Activity");
        ShowMessage("4 Quit");
    }

    public string GetInput()
    {
        return Console.ReadLine();
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        UserInterface ui = new UserInterface();
        bool running = true;
        while (running)
        {
            ui.DisplayMenu();
            string choice = ui.GetInput();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new Breathing();
                    break;
                case "2":
                    activity = new Reflection();
                    break;
                case "3":
                    activity = new Listing();
                    break;
                case "4":
                    running = false;
                    ui.ShowMessage("Closing minduflness app. May you find peace random person.");
                    break;
                default:
                    ui.ShowMessage("Invalid choice. Please choose an option 1-4. ");
                    break;
            }
            if (activity !=null)
            {
            activity.StartActivity();
            activity.ExecuteActivity();
            activity.EndActivity(); 
            }
        }
    }
}