public class Breathing : Activity
{
    public Breathing() : base("Breathing Activity", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void ExecuteActivity()
    {
        int cycles = _duration / 6;

        for (int i = 0; i < cycles; i++)
        {
            BreatheIn(3); 
            BreatheOut(3);
        }
    }

    private void BreatheIn(int seconds)
    {
        for (int i = 1; i <= seconds; i++)
        {
            Console.Clear();
            string spaces = new string(' ', i * 2);
            Console.WriteLine($"{spaces}Breathe in...");
            DrawCircle(i * 2, 'o');
            Thread.Sleep(1000);
        }
    }

    private void BreatheOut(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Clear();
            string spaces = new string(' ', i * 2);
            Console.WriteLine($"{spaces}Breathe out...");
            DrawCircle(i * 2, 'o');
            Thread.Sleep(1000); 
        }
    }

    private void DrawCircle(int radius, char fillChar)
    {
        int diameter = radius * 2;
        for (int y = 0; y <= diameter; y++)
        {
            for (int x = 0; x <= diameter; x++)
            {
                // Calculate distance from the center of the circle
                double distance = Math.Sqrt(Math.Pow(x - radius, 2) + Math.Pow(y - radius, 2));
                // Print fillChar if within the radius
                if (distance <= radius)
                    Console.Write(fillChar);
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
