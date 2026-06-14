using System;

// EXCEEDING REQUIREMENTS:
//
// I added a NegativeGoal class.
// This goal tracks bad habits and deducts points
// whenever an event is recorded.
//
// This provides an additional level of gamification
// beyond the core project requirements.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");

         GoalManager manager = new GoalManager();
        manager.Start();
    }
}
