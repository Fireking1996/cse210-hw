using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    { }

    public override int RecordEvent()
    {
        return _points; // always award points, never complete
    }

    public override bool IsComplete() => false;

    public override string GetStatus() => "[∞]";

    public override string Serialize()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}";
    }

    public static EternalGoal Deserialize(string data)
    {
        var parts = data.Split('|');
        return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
    }
}
