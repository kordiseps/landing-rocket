using LandingRocket.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LandingRocket.Lib
{
    public class Ground 
    {
        private List<Reserved> reservedAreas = new List<Reserved>();

        private readonly Area platformArea;
        private readonly Area landingArea;

        public Ground(
            int areaWidth, int areaHeight,
            Coordinate platformStart,
            Coordinate platformEnd) 
        {
            this.landingArea = new Area(new Coordinate(0, 0), new Coordinate(areaWidth, areaHeight));

            if (!platformStart.IsIn(this.landingArea))
            {
                throw new ArgumentException($"{nameof(platformStart)} is not a valid area. It must be between (0, 0) and ({areaWidth},{areaHeight})");
            }


            if (!platformEnd.IsIn(this.landingArea))
            {
                throw new ArgumentException($"{nameof(platformEnd)} is not a valid area. It must be between (0, 0) and ({areaWidth},{areaHeight})");
            }

            this.platformArea = new Area(platformStart, platformEnd);
        }


        public string Query(int rocketId, Coordinate coordinate)
        {

            if (!coordinate.IsIn(platformArea))
            {
                return "out of platform";
            }
            else
            {

                foreach (var _reservedArea in reservedAreas)
                {
                    if (rocketId != _reservedArea.RocketId &&
                        coordinate.IsIn(_reservedArea.ReservedArea))
                    {
                        return "clash";
                    }
                }

                var start = new Coordinate(coordinate.X - 1, coordinate.Y - 1);
                var end = new Coordinate(coordinate.X + 1, coordinate.Y + 1);

                if (reservedAreas.Any(x => x.RocketId == rocketId))
                {
                    reservedAreas.RemoveAll(x => x.RocketId == rocketId);
                }

                var reservedArea = new Reserved
                {
                    RocketId = rocketId,
                    ReservedArea = new Area(start, end)
                };

                reservedAreas.Add(reservedArea);


                return "ok for landing";
            }
        }
    }
}
