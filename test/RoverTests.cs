using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Kata.Tests
{
    public class A_Rover
    {
        private readonly RoverBuilder _roverBuilder = new();
        private readonly PlanetBuilder _planetBuilder = new();
        private const int PLANET_SEMICIRCLE_LENGTH = 5;

        [Fact]
        public void Gives_An_Error_Without_A_Planet()
        {
            Action methodToCall = () => _roverBuilder
                            .WithStartingPosition("0,0,N")
                            .Build();

            methodToCall.Should().Throw<PlanetRequired>();
        }

        [Theory]
        [InlineData("")]
        [InlineData("a,b,c")]
        [InlineData("0,E")]
        [InlineData("0,W,E")]
        [InlineData("0,E,1")]
        [InlineData("E,E,1")]
        [InlineData("E,E,E")]
        public void Gives_An_Error_With_An_Invalid_Starting_Position(string invalidPosition)
        {
            var planet = _planetBuilder
                           .WithSemicircleLength(PLANET_SEMICIRCLE_LENGTH)
                           .Build();
            Action methodToCall = () => _roverBuilder
                            .WithPlanet(planet)
                            .WithStartingPosition(invalidPosition)
                            .Build();

            methodToCall.Should().Throw<InvalidPosition>();
        }

        [Theory]
        [InlineData("0,0,N", new char[] { 'A' })]
        public void Gives_An_Error_With_Invalid_Command(string initialPosition, char[] commands)
        {
            var planet = _planetBuilder
                .WithSemicircleLength(PLANET_SEMICIRCLE_LENGTH)
                .Build();
            var rover = _roverBuilder
                            .WithStartingPosition(initialPosition)
                            .WithPlanet(planet)
                            .Build();

            Action methodToCall = () => rover.Move(commands);

            methodToCall.Should().Throw<InvalidCommand>();
        }

        [Theory]
        [InlineData("0,0,N", "0,0,N")]
        [InlineData("1,1,N", "1,1,N")]
        public void Returns_Its_Current_Position(string initialPosition, string expectedPosition)
        {
            var planet = _planetBuilder
                            .WithSemicircleLength(PLANET_SEMICIRCLE_LENGTH)
                            .Build();
            var rover = _roverBuilder
                            .WithStartingPosition(initialPosition)
                            .WithPlanet(planet)
                            .Build();

            expectedPosition.Should().Be(rover.CurrentPosition());
        }

        [Theory]
        [InlineData("0,0,N", new char[] { 'F' }, "0,1,N")]
        [InlineData("0,0,N", new char[] { 'F', 'F' }, "0,2,N")]
        public void Moves_Forward(string initialPosition, char[] commands, string expectedPosition)
        {
            var planet = _planetBuilder
                .WithSemicircleLength(PLANET_SEMICIRCLE_LENGTH)
                .Build();
            var rover = _roverBuilder
                            .WithStartingPosition(initialPosition)
                            .WithPlanet(planet)
                            .Build();

            rover.Move(commands);

            expectedPosition.Should().Be(rover.CurrentPosition());
        }

        [Theory]
        [InlineData("0,0,N", new char[] { 'F', 'F', 'F' }, "0,-1,N")]
        [InlineData("0,0,N", new char[] { 'B', 'B', 'B' }, "0,1,N")]
        [InlineData("0,0,N", new char[] { 'L', 'F', 'F', 'F' }, "1,0,W")]
        [InlineData("0,0,N", new char[] { 'R', 'F', 'F', 'F' }, "-1,0,E")]
        public void Wraps_Around_Planet_Borders(
            string initialPosition,
            char[] commands,
            string expectedPosition)
        {
            var planet = _planetBuilder
                .WithSemicircleLength(2)
                .Build();
            var rover = _roverBuilder
                            .WithStartingPosition(initialPosition)
                            .WithPlanet(planet)
                            .Build();

            rover.Move(commands);

            expectedPosition.Should().Be(rover.CurrentPosition());
        }

        [Theory]
        [InlineData("0,0,N", new char[] { 'B' }, "0,-1,N")]
        [InlineData("0,0,N", new char[] { 'B', 'B' }, "0,-2,N")]
        [InlineData("0,0,S", new char[] { 'B' }, "0,1,S")]
        [InlineData("0,0,S", new char[] { 'B', 'B' }, "0,2,S")]
        [InlineData("0,0,E", new char[] { 'B' }, "-1,0,E")]
        [InlineData("0,0,E", new char[] { 'B', 'B' }, "-2,0,E")]
        [InlineData("0,0,W", new char[] { 'B' }, "1,0,W")]
        [InlineData("0,0,W", new char[] { 'B', 'B' }, "2,0,W")]
        public void Moves_Backward(string initialPosition, char[] commands, string expectedPosition)
        {
            var planet = _planetBuilder
                .WithSemicircleLength(PLANET_SEMICIRCLE_LENGTH)
                .Build();
            var rover = _roverBuilder
                            .WithStartingPosition(initialPosition)
                            .WithPlanet(planet)
                            .Build();

            rover.Move(commands);

            expectedPosition.Should().Be(rover.CurrentPosition());
        }

        [Theory]
        [InlineData("0,0,N", new char[] { 'L' }, "0,0,W")]
        [InlineData("0,0,N", new char[] { 'L', 'L' }, "0,0,S")]
        [InlineData("0,0,N", new char[] { 'L', 'L', 'L' }, "0,0,E")]
        [InlineData("0,0,N", new char[] { 'L', 'L', 'L', 'L' }, "0,0,N")]
        public void Rotates_Left(string initialPosition, char[] commands, string expectedPosition)
        {
            var planet = _planetBuilder
                .WithSemicircleLength(PLANET_SEMICIRCLE_LENGTH)
                .Build();
            var rover = _roverBuilder
                            .WithStartingPosition(initialPosition)
                            .WithPlanet(planet)
                            .Build();

            rover.Move(commands);

            expectedPosition.Should().Be(rover.CurrentPosition());
        }

        [Theory]
        [InlineData("0,0,N", new char[] { 'R' }, "0,0,E")]
        [InlineData("0,0,N", new char[] { 'R', 'R' }, "0,0,S")]
        [InlineData("0,0,N", new char[] { 'R', 'R', 'R' }, "0,0,W")]
        [InlineData("0,0,N", new char[] { 'R', 'R', 'R', 'R' }, "0,0,N")]
        public void Rotates_Right(string initialPosition, char[] commands, string expectedPosition)
        {
            var planet = _planetBuilder
                .WithSemicircleLength(PLANET_SEMICIRCLE_LENGTH)
                .Build();
            var rover = _roverBuilder
                            .WithStartingPosition(initialPosition)
                            .WithPlanet(planet)
                            .Build();

            rover.Move(commands);

            expectedPosition.Should().Be(rover.CurrentPosition());
        }

        [Theory]
        [InlineData("0,0,N", new char[] { 'R', 'F', 'F', 'L', 'B' }, "2,-1,N")]
        [InlineData("0,0,N", new char[] { 'L', 'F', 'F', 'L', 'F' }, "-2,-1,S")]
        [InlineData("0,0,N", new char[] { 'F', 'L', 'F', 'L', 'F' }, "-1,0,S")]
        public void Moves_Around_The_Planet(string initialPosition, char[] commands, string expectedPosition)
        {
            var planet = _planetBuilder
                .WithSemicircleLength(PLANET_SEMICIRCLE_LENGTH)
                .Build();
            var rover = _roverBuilder
                            .WithStartingPosition(initialPosition)
                            .WithPlanet(planet)
                            .Build();

            rover.Move(commands);

            expectedPosition.Should().Be(rover.CurrentPosition());
        }

        [Theory]
        [InlineData("0,0,N", new string[] { "0,1" }, new char[] { 'F', 'F', }, "0,0,N")]
        [InlineData("0,0,N", new string[] { "0,-1" }, new char[] { 'B', 'B', }, "0,0,N")]

        public void Gives_An_Error_While_Moving_Towards_An_Obstacle(
            string initialPosition,
            string[] obstaclePositions,
            char[] commands,
            string expectedPosition)
        {
            var planet = _planetBuilder
                .WithSemicircleLength(PLANET_SEMICIRCLE_LENGTH)
                .WithObstacles(obstaclePositions)
                .Build();
            var rover = _roverBuilder
                            .WithStartingPosition(initialPosition)
                            .WithPlanet(planet)
                            .Build();

            Action methodToCall = () => rover.Move(commands);

            methodToCall.Should().Throw<InvalidMove>();
            expectedPosition.Should().Be(rover.CurrentPosition());
        }
    }
}
