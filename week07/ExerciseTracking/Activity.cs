using System;

namespace ActivityTracker
{
    public abstract class Activity
    {
        private DateTime _date;
        private double _minutes;

        public Activity(DateTime date, double minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        public DateTime Date => _date;
        public double Minutes => _minutes;

        public abstract double GetDistance(); // miles
        public abstract double GetSpeed();    // mph
        public abstract double GetPace();     // min/mile

        public virtual string GetSummary()
        {
            return $"{Date:dd MMM yyyy} {GetType().Name} ({Minutes} min): " +
                   $"Distance {GetDistance():0.0} miles, " +
                   $"Speed {GetSpeed():0.0} mph, " +
                   $"Pace: {GetPace():0.00} min per mile";
        }
    }
}
