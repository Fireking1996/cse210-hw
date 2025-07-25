using System;
using System.Threading;

abstract class MindfulnessActivity
{
    private int _duration;
    private string _name;
    private string _description;

    public MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Starts the full activity: intro, core, outro
    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---\n");
        Console.WriteLine($"{_description}\n");

        Console.Write("Enter duration in seconds: ");
        string input = Console.ReadLine();
        while (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a valid positive number: ");
            input = Console.ReadLine();
        }

        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(3);

        RunActivity();

        Console.WriteLine("\nGreat job!");
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    // Used by child classes to get the duration
    protected int GetDuration()
    {
        return _duration;
    }

    // Spinner animation with \b for realism
    protected void ShowSpinner(int seconds)
    {
        string[] spinnerFrames = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinnerFrames[i % spinnerFrames.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
        Console.WriteLine();
    }

    // Countdown (3, 2, 1)
    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
        Console.WriteLine();
    }

    // All derived classes must implement this
    protected abstract void RunActivity();
}
