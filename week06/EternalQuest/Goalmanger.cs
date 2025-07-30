using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int Score => _score;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        var pointsEarned = _goals[index].RecordEvent();
        _score += pointsEarned;
        Console.WriteLine($"You earned {pointsEarned} points!");
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            var goal = _goals[i];
            Console.WriteLine($"{i + 1}. {goal.GetStatus()} {goal.GetName()} - {goal.GetDescription()}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        _goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            _score = int.Parse(reader.ReadLine());
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split('|');
                switch (parts[0])
                {
                    case "SimpleGoal":
                        _goals.Add(SimpleGoal.Deserialize(line));
                        break;
                    case "EternalGoal":
                        _goals.Add(EternalGoal.Deserialize(line));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(ChecklistGoal.Deserialize(line));
                        break;
                }
            }
        }
        Console.WriteLine("Goals loaded.");
    }
}
