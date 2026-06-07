using System;

public class ActivityLog
{
    private int _totalActivities = 0;

    public void RecordActivity()
    {
        _totalActivities++;
    }

    public void DisplayLog()
    {
        Console.WriteLine();
        Console.WriteLine($"Activities completed this session: {_totalActivities}");
    }
}