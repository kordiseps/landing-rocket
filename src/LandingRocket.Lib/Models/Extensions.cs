using System.Collections.Generic;

namespace LandingRocket.Lib.Models
{
    public static class Extensions
    {
        public static bool IsIn(this Coordinate coordinate, Area area)
        {
            Coordinate start = area.Start;
            Coordinate end = area.End;

            if (coordinate is null)
            {
                return false;
            }

            if (area is null)
            {
                return false;
            }

            if (start.X > coordinate.X)
            {
                return false;
            }
            if (start.Y > coordinate.Y)
            {
                return false;
            }

            if (end.X < coordinate.X)
            {
                return false;
            }
            if (end.Y < coordinate.Y)
            {
                return false;
            }

            return true;
        }

        public static IEnumerable<Coordinate> GetNeighboursAndSelf(this Coordinate c)
        {
            yield return new Coordinate(c.X - 1, c.Y - 1);
            yield return new Coordinate(c.X - 1, c.Y    );
            yield return new Coordinate(c.X - 1, c.Y + 1);
            yield return new Coordinate(c.X    , c.Y - 1);
            yield return new Coordinate(c.X    , c.Y    );
            yield return new Coordinate(c.X    , c.Y + 1);
            yield return new Coordinate(c.X + 1, c.Y - 1);
            yield return new Coordinate(c.X + 1, c.Y    );
            yield return new Coordinate(c.X + 1, c.Y + 1);
        }
    }
}
