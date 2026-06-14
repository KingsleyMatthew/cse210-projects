using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.Clear();

            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("---------------------");
            Console.WriteLine($"Current Score: {_score} points");
            Console.WriteLine();

            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("\nSelect a choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                choice = 0;
            }

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;

                case 2:
                    ListGoals();
                    break;

                case 3:
                    SaveGoals();
                    break;

                case 4:
                    LoadGoals();
                    break;

                case 5:
                    RecordEvent();
                    break;

                case 6:
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    Pause();
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.Clear();

        Console.WriteLine("Goal Types");
        Console.WriteLine("----------");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");

        Console.Write("\nChoose goal type: ");
        int type = int.Parse(Console.ReadLine());

        Console.Write("Goal Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;

            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;

            case 3:
                Console.Write("Target completions: ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(
                    new ChecklistGoal(
                        name,
                        description,
                        points,
                        target,
                        bonus));
                break;

            case 4:
                _goals.Add(new NegativeGoal(name, description, points));
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }

        Console.WriteLine("\nGoal created successfully.");
        Pause();
    }

    private void ListGoals()
    {
        Console.Clear();

        Console.WriteLine("Your Goals");
        Console.WriteLine("----------");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        Pause();
    }

    private void RecordEvent()
    {
        Console.Clear();

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            Pause();
            return;
        }

        Console.WriteLine("Record Event");
        Console.WriteLine("------------");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        Console.Write("\nWhich goal did you accomplish? ");
        int goalNumber = int.Parse(Console.ReadLine());

        if (goalNumber < 1 || goalNumber > _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            Pause();
            return;
        }

        Goal selectedGoal = _goals[goalNumber - 1];

        int earnedPoints = selectedGoal.RecordEvent();

        _score += earnedPoints;

        if (earnedPoints >= 0)
        {
            Console.WriteLine(
                $"\nCongratulations! You earned {earnedPoints} points.");
        }
        else
        {
            Console.WriteLine(
                $"\nPenalty! You lost {Math.Abs(earnedPoints)} points.");
        }

        Console.WriteLine($"Current Score: {_score}");

        Pause();
    }

    private void SaveGoals()
    {
        Console.Clear();

        Console.Write("Enter filename: ");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("\nGoals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError saving file: {ex.Message}");
        }

        Pause();
    }

    private void LoadGoals()
    {
        Console.Clear();

        Console.Write("Enter filename: ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            Pause();
            return;
        }

        try
        {
            _goals.Clear();

            string[] lines = File.ReadAllLines(fileName);

            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');

                switch (parts[0])
                {
                    case "SimpleGoal":
                        _goals.Add(
                            new SimpleGoal(
                                parts[1],
                                parts[2],
                                int.Parse(parts[3]),
                                bool.Parse(parts[4])));
                        break;

                    case "EternalGoal":
                        _goals.Add(
                            new EternalGoal(
                                parts[1],
                                parts[2],
                                int.Parse(parts[3])));
                        break;

                    case "ChecklistGoal":
                        _goals.Add(
                            new ChecklistGoal(
                                parts[1],
                                parts[2],
                                int.Parse(parts[3]),
                                int.Parse(parts[5]),
                                int.Parse(parts[4]),
                                int.Parse(parts[6])));
                        break;

                    case "NegativeGoal":
                        _goals.Add(
                            new NegativeGoal(
                                parts[1],
                                parts[2],
                                int.Parse(parts[3])));
                        break;
                }
            }

            Console.WriteLine("\nGoals loaded successfully.");
            Console.WriteLine($"Current Score: {_score}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError loading file: {ex.Message}");
        }

        Pause();
    }

    private void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}