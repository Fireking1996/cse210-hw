using System;
using System.Collections.Generic;
using System.Threading;

class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
        : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience.") {}

    protected override void RunActivity()
    {
        Random rand = new Random();
        Console.WriteLine("\n" + prompts[rand.Next(prompts.Length)] + "\n");
        ShowSpinner(3);

        int elapsed = 0;
        while (elapsed < GetDuration())
        {
            string question = questions[rand.Next(questions.Length)];
            Console.WriteLine($"> {question}");
            ShowSpinner(5);
            elapsed += 5;
        }
    }
}
