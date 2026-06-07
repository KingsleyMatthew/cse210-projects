using System;

/*
CREATIVITY AND EXCEEDING REQUIREMENTS

1. Added a Goal Activity.
2. Added Activity Tracking.
3. Displays total activities completed during the session.
*/

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");

        ActivityLog log = new ActivityLog();

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Start Goal Activity");
            Console.WriteLine("  5. View Activity Log");
            Console.WriteLine("  6. Quit");

            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    log.RecordActivity();
                    break;

                case "2":
                    ReflectingActivity reflection = new ReflectingActivity();
                    reflection.Run();
                    log.RecordActivity();
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    log.RecordActivity();
                    break;

                case "4":
                    GoalActivity goal = new GoalActivity();
                    goal.Run();
                    log.RecordActivity();
                    break;

                case "5":
                    log.DisplayLog();
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    break;

                case "6":
                    running = false;
                    break;
            }
        }
    }
}