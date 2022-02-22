using System;

namespace LandingRocket.Lib.Models
{
    public class Area
    {
        public Area(Coordinate start, Coordinate end)
        {

            if (start.X >= end.X )
            {
                throw new ArgumentException($"Invalid {nameof(Coordinate.X)} for {nameof(Area)}. {nameof(start)}.{nameof(Coordinate.X)} cannot be equal or bigger then {nameof(end)}.{nameof(Coordinate.X)}");
            }

            if (start.Y >= end.Y)
            {
                throw new ArgumentException($"Invalid {nameof(Coordinate.Y)} for {nameof(Area)}. {nameof(start)}.{nameof(Coordinate.Y)} cannot be equal or bigger then {nameof(end)}.{nameof(Coordinate.Y)}");
            }

            Start = start;
            End = end;
        }

        public Coordinate Start { get; }
        public Coordinate End { get; }
    }
}
