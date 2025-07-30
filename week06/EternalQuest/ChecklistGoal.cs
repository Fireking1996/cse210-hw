using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int currentCount = 0, int bonusPoints = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = currentCount;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            if (_currentCount == _targetCount)
            {
                // Give bonus points on completion
                return _points + _bonusPoints;
            }
            return _points;
        }
        return 0; // Already complete
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus() => $"[{(IsComplete() ? "X" : " ")}] Completed {_currentCount}/{_targetCount}";

    public override string Serialize()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_currentCount}|{_targetCount}|{_bonusPoints}";
    }

    public static ChecklistGoal Deserialize(string data)
    {
        var parts = data.Split('|');
        return new ChecklistGoal(
            parts[1],
            parts[2],
            int.Parse(parts[3]),
            int.Parse(parts[5]),
            int.Parse(parts[4]),
            int.Parse(parts[6])
        );
    }
}
