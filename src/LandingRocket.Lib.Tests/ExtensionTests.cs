using LandingRocket.Lib.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace LandingRocket.Lib.Tests
{
    public class ExtensionTests
    {
        /////////////////////////////// SHOULD IN /////////////////////////////
        [Theory]
        [MemberData(nameof(Get_Params_For_Should_In))]
        public void Should_In(
            Area area,
            Coordinate coordinate)
        {
            Assert.True(coordinate.IsIn(area));
        }
        public static IEnumerable<object[]> Get_Params_For_Should_In()
        {
            Coordinate start = new Coordinate(0, 0);
            Coordinate end = new Coordinate(10, 10);
            Area area = new Area(start, end);

            for (int x = start.X; x <= end.X; x++)
            {
                for (int y = start.Y; y <= end.Y; y++)
                {
                    var currentCoordinate = new Coordinate(x, y);

                    yield return new object[] { area, currentCoordinate };
                }
            }
        }


        /////////////////////////////// SHOULD NOT IN /////////////////////////////
        [Theory]
        [MemberData(nameof(Get_Params_For_Should_Not_In))]
        public void Should_Not_In(
            Area area,
            Coordinate coordinate)
        {
            Assert.False(coordinate.IsIn(area));
        }
        public static IEnumerable<object[]> Get_Params_For_Should_Not_In()
        {

            Coordinate largerAreaStart = new Coordinate(10, 10);
            Coordinate largerAreaEnd = new Coordinate(50, 50);
            Area largerArea = new Area(largerAreaStart, largerAreaEnd);

            Coordinate smallerAreaStart = new Coordinate(20, 20);
            Coordinate smallerAreaEnd = new Coordinate(30, 30);
            Area smallerArea = new Area(smallerAreaStart, smallerAreaEnd);

            for (int x = largerArea.Start.X; x <= largerArea.End.X; x++)
            {
                for (int y = largerArea.Start.Y; y <= largerArea.End.Y; y++)
                {

                    if ((x < smallerArea.Start.X && y < smallerArea.Start.Y) ||
                        (x > smallerArea.End.X && y > smallerArea.End.Y))
                    {
                        var currentCoordinate = new Coordinate(x, y);
                        yield return new object[] { smallerArea, currentCoordinate };
                    }

                }
            }
        }


        /////////////////////////////// SHOULD THROW EXCEPTION /////////////////////////////
        [Fact]
        public void Should_Get_Right_Neighbours()
        {

            Coordinate coordinate = new Coordinate(10, 10);
            var neighBours = coordinate.GetNeighboursAndSelf();

            Assert.NotNull(neighBours);

            Assert.Contains(new Coordinate(9, 9), neighBours);
            Assert.Contains(new Coordinate(9, 10), neighBours);
            Assert.Contains(new Coordinate(9, 11), neighBours);
            Assert.Contains(new Coordinate(10, 9), neighBours);
            Assert.Contains(new Coordinate(10, 10), neighBours);
            Assert.Contains(new Coordinate(10, 11), neighBours);
            Assert.Contains(new Coordinate(11, 9), neighBours);
            Assert.Contains(new Coordinate(11, 10), neighBours);
            Assert.Contains(new Coordinate(11, 11), neighBours);

            Assert.DoesNotContain(new Coordinate(5, 9), neighBours);
            Assert.DoesNotContain(new Coordinate(5, 10), neighBours);
            Assert.DoesNotContain(new Coordinate(5, 11), neighBours);
            Assert.DoesNotContain(new Coordinate(15, 9), neighBours);
            Assert.DoesNotContain(new Coordinate(15, 10), neighBours);
            Assert.DoesNotContain(new Coordinate(15, 11), neighBours);
            Assert.DoesNotContain(new Coordinate(9, 5), neighBours);
            Assert.DoesNotContain(new Coordinate(10, 5), neighBours);
            Assert.DoesNotContain(new Coordinate(11, 5), neighBours);
            Assert.DoesNotContain(new Coordinate(9, 15), neighBours);
            Assert.DoesNotContain(new Coordinate(10, 15), neighBours);
            Assert.DoesNotContain(new Coordinate(11, 15), neighBours);
        }
    }


}
