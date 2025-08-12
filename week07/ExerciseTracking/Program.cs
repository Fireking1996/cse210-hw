using System;
using System.Collections.Generic;

namespace ActivityTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>
            {
                new Running(new DateTime(2022, 11, 3), 30, 3.0),
                new Cycling(new DateTime(2022, 11, 3), 45, 12.0),
                new Swimming(new DateTime(2022, 11, 3), 25, 20)
            };

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
