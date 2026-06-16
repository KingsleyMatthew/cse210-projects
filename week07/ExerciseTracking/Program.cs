using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");

        List<Activity> activities = new List<Activity>
        {
            new RunningActivity(new DateTime(2026, 6, 16), 30, 3.0),
            new CyclingActivity(new DateTime(2026, 6, 16), 45, 12.0),
            new SwimmingActivity(new DateTime(2026, 6, 16), 40, 30)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
    
}