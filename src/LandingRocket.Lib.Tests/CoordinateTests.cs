using LandingRocket.Lib.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace LandingRocket.Lib.Tests
{
    public class CoordinateTests
    {
        /////////////////////////////// SHOULD CREATE INSTANCE /////////////////////////////
        [Theory]
        [MemberData(nameof(Get_Params_For_Should_Create_Instance))]
        public void Should_Create_Instance(int x, int y)
        {
            Coordinate coordinate = new Coordinate(x, y);
            Assert.NotNull(coordinate);
            Assert.Equal(x, coordinate.X);
            Assert.Equal(y, coordinate.Y);
        }


        public static IEnumerable<object[]> Get_Params_For_Should_Create_Instance()
        {
            yield return new object[] { 0, 0 };
            yield return new object[] { 1, 0 };
            yield return new object[] { 0, 1 };
            yield return new object[] { -1, 0 };
            yield return new object[] { 0, -1 };
        }


        //////////////////////////////////// SHOULD EQUAL //////////////////////////////////
        [Theory]
        [MemberData(nameof(Get_Params_For_Should_Equal))]
        public void Should_Equal(Coordinate coordinate)
        {
            Coordinate newCoordinate = new Coordinate(coordinate.X, coordinate.Y);
            Assert.NotNull(coordinate);
            Assert.NotNull(newCoordinate);
            Assert.Equal(coordinate.X, newCoordinate.X);
            Assert.Equal(coordinate.Y, newCoordinate.Y);
            Assert.Equal(coordinate, newCoordinate);
            Assert.True(coordinate.Equals(newCoordinate));
        }


        public static IEnumerable<object[]> Get_Params_For_Should_Equal()
        {
            yield return new object[] { new Coordinate(0, 0) };
            yield return new object[] { new Coordinate(1, 0) };
            yield return new object[] { new Coordinate(0, 1) };
            yield return new object[] { new Coordinate(-1, 0) };
            yield return new object[] { new Coordinate(0, -1) };
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

            yield return new object[] { new Coordinate(0, 0), new Coordinate(0, 0) };
            yield return new object[] { new Coordinate(0, 0), new Coordinate(1, 0) };
            yield return new object[] { new Coordinate(0, 0), new Coordinate(0, 1) };
        }
    }



}
