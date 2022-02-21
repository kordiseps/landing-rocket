using LandingRocket.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LandingRocket.Lib.Tests
{
    public class GroundTests
    {
        //Arrange – Act – Assert

        //out of platform
        //clash
        //o


        ///////////////////// SHOULD GET OK FOR LANDING FOR ONE ROCKET /////////////////////

        [Theory]
        [MemberData(nameof(Get_Locations_For_Should_Get_Ok_For_Landing_For_One_Rocket))]
        public void Should_Get_Ok_For_Landing_For_One_Rocket(
            Coordinate platformStart,
            Coordinate platformEnd,
            Coordinate coordinate)
        {
            var ground = new Ground(100, 100, platformStart, platformEnd);
            Assert.Equal("ok for landing", ground.Query(1, coordinate));
        }


        public static IEnumerable<object[]> Get_Locations_For_Should_Get_Ok_For_Landing_For_One_Rocket()
        {
            var platformStart = new Coordinate(5, 5);
            var platformEnd = new Coordinate(15, 15);

            for (int x = platformStart.X; x <= platformEnd.X; x++)
            {
                for (int y = platformStart.Y; y <= platformEnd.Y; y++)
                {
                    var currentCoordinate = new Coordinate(x, y);

                    yield return new object[] { platformStart, platformEnd, currentCoordinate };
                }
            }
        }


        ///////////////////// SHOULD GET OUT OF PLATFORM FOR ONE ROCKET ////////////////////

        [Theory]
        [MemberData(nameof(Get_Locations_For_Should_Get_Out_Of_Platform_For_One_Rocket))]
        public void Should_Get_Out_Of_Platform_For_One_Rocket(
            int areaWidth, 
            int areaHeight,
            Coordinate platformStart,
            Coordinate platformEnd,
            Coordinate coordinate
            )
        {
            var ground = new Ground(areaWidth, areaHeight, platformStart, platformEnd);

            Assert.Equal("out of platform", ground.Query(1, coordinate));
        }
        public static IEnumerable<object[]> Get_Locations_For_Should_Get_Out_Of_Platform_For_One_Rocket()
        {
            int areaWidth = 100;
            int areaHeight = 100;
            var platformStart = new Coordinate(5, 5);
            var platformEnd = new Coordinate(15, 15);
            var platform = new Area( platformStart, platformEnd);

            for (int x = 0; x <= areaWidth; x++)
            {
                for (int y = 0; y <= areaHeight; y++)
                {
                    var currentCoordinate = new Coordinate(x, y);
                    if (currentCoordinate.IsIn(platform))
                    {
                        continue;
                    }

                    yield return new object[] { areaWidth, areaHeight, platformStart, platformEnd, currentCoordinate };
                }
            }
        }


        ////////////////////////// SHOULD CLASH FOR SECOND ROCKET //////////////////////////

        [Theory]
        [MemberData(nameof(Get_Locations_For_Should_Clash_For_Second_Rocket))]
        public void Should_Clash_For_Second_Rocket(Coordinate first, Coordinate second)
        {
            var platformStart = new Coordinate(5, 5);
            var platformEnd = new Coordinate(25, 25);
            var ground = new Ground(100, 100, platformStart, platformEnd);

            Assert.Equal("ok for landing", ground.Query(1, first));
            Assert.Equal("clash", ground.Query(2, second));
        }


        public static IEnumerable<object[]> Get_Locations_For_Should_Clash_For_Second_Rocket()
        {
            var coordinate = new Coordinate(15, 15);
            foreach (var nearCoordinate in coordinate.Get_Neighbours())
            {
                yield return new object[] { coordinate, nearCoordinate };
            }
        }


        // SHOULD GET OK FOR LANDING FOR SECOND ROCKET AFTER FIRST ROCKET QUERIES 2 TIMES //  
        [Theory]
        [MemberData(nameof(Get_Locations_For_Should_Get_Ok_For_Landing_For_Second_Rocket_After_First_Rocket_Queries_2_Times))]
        public void Should_Get_Ok_For_Landing_For_Second_Rocket_After_First_Rocket_Queries_2_Times(
            Coordinate platformStart,
            Coordinate platformEnd,
            Coordinate first,
            Coordinate second)
        {
            var ground = new Ground(100, 100, platformStart, platformEnd);

            Assert.Equal("ok for landing", ground.Query(1, first));
            Assert.Equal("ok for landing", ground.Query(1, second));
            Assert.Equal("ok for landing", ground.Query(2, first));
        }


        public static IEnumerable<object[]> Get_Locations_For_Should_Get_Ok_For_Landing_For_Second_Rocket_After_First_Rocket_Queries_2_Times()
        {
            var platformStart = new Coordinate(5, 5);
            var platformEnd = new Coordinate(25, 25);

            var coordinate = new Coordinate(15, 15);

            var nearCoordinates = coordinate.Get_Neighbours().ToList();

            for (int x = platformStart.X; x <= platformEnd.X; x++)
            {
                for (int y = platformStart.Y; y <= platformEnd.Y; y++)
                {
                    var currentCoordinate = new Coordinate(x, y);

                    if (nearCoordinates.Any(nearCoordinate => nearCoordinate.Equals(currentCoordinate)))
                    {
                        continue;
                    }

                    yield return new object[] { platformStart, platformEnd, coordinate, currentCoordinate };
                }
            }
        }
    }
}
