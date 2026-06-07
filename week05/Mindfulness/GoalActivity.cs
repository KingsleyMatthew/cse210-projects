using System;

public class GoalActivity : Activity
{
    public GoalActivity()
        : base(
              "Goal Activity",
              "This activity helps you think about and write a personal goal.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.Write("What goal would you like to achieve? ");

        string goal = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine($"Great! Spend {_duration} seconds thinking about steps to achieve:");
        Console.WriteLine(goal);

        ShowSpinner(_duration);

        DisplayEndingMessage();
    }
}