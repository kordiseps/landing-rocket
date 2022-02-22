using LandingRocket.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LandingRocket.Lib.Tests
{
    public class AreaTests
    {
        /////////////////////////////// SHOULD CREATE INSTANCE /////////////////////////////
        [Fact]
        public void Should_Create_Instance()
        {
            Coordinate start = new Coordinate(0, 0);
            Coordinate end = new Coordinate(1, 1);
            Area area = new Area(start, end);
            Assert.NotNull(area);
            Assert.Equal(start, area.Start);
            Assert.Equal(end, area.End);
        }

        /////////////////////////////// SHOULD THROW EXCEPTION /////////////////////////////
        [Theory]
        [MemberData(nameof(Get_Params_For_Should_Throw_Exception))]
        public void Should_Throw_Exception(
            Coordinate start,
            Coordinate end)
        {

            Action act = () => new Area(start, end);

            ArgumentException exception = Assert.Throws<ArgumentException>(act);


            Assert.NotNull(exception.Message);
            Assert.StartsWith("Invalid", exception.Message);
            Assert.Contains("cannot be equal or bigger then", exception.Message);
        }
        public static IEnumerable<object[]> Get_Params_For_Should_Throw_Exception()
        {
            yield return new object[] { new Coordinate(0, 0), new Coordinate(0, 0) };
            yield return new object[] { new Coordinate(1, 0), new Coordinate(0, 0) };
            yield return new object[] { new Coordinate(0, 1), new Coordinate(0, 0) };
            yield return new object[] { new Coordinate(1, 1), new Coordinate(0, 0) };
        }
    }
}
