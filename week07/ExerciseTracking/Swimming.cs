using System;

namespace ActivityTracker
{
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, double minutes, int laps)
            : base(date, minutes)
        {
            _laps = laps;
        }

        // Distance in miles: laps * 50 meters * 0.00062 (meters to miles)
        public override double GetDistance() => _laps * 50 / 1000.0 * 0.62;

        public override double GetSpeed() => (GetDistance() / Minutes) * 60;

        public override double GetPace() => Minutes / GetDistance();
    }
}
