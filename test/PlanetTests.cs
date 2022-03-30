using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Kata.Tests
{
    public class A_Planet
    {
        private readonly PlanetBuilder _planetBuilder = new();

        [Theory]
        [InlineData(10, 0)]
        [InlineData(6, -4)]
        [InlineData(7, -3)]
        [InlineData(12, 2)]
        [InlineData(-6, 4)]
        [InlineData(-7, 3)]
        [InlineData(-10, 0)]
        [InlineData(-12, -2)]
        [InlineData(20, 0)]
        [InlineData(-20, 0)]
        public void Maps_A_Coordinate_To_The_Planet(int coordinateGiven, int expectedMapping)
        {
            var planet = _planetBuilder
                .WithSemicircleLength(5)
                .Build();
            var coordinateToMap = new Coordinate(coordinateGiven, coordinateGiven);

            var coordinateMapped = planet.MapCoordinateToPlanet(coordinateToMap);

            coordinateMapped.X.Should().Be(expectedMapping);
            coordinateMapped.Y.Should().Be(expectedMapping);
        }
    }
}
