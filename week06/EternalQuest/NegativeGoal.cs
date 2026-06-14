public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int penalty)
        : base(name, description, penalty)
    {
    }

    public override int RecordEvent()
    {
        return -_points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal|{_name}|{_description}|{_points}";
    }
}