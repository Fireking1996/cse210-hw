using System;
using System.Threading;

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() 
        : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") {}

    protected override void RunActivity()
    {
        int elapsed = 0;
        while (elapsed < GetDuration()) 
        {
            Console.Write("Breathe in... ");
            Countdown(4);
            elapsed += 4;

            if (elapsed >= GetDuration()) break;

            Console.Write("Breathe out... ");
            Countdown(6);
            elapsed += 6;
        }
    }
}
