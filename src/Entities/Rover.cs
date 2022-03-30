using System;
using System.Collections.Generic;

namespace Kata
{
    public class Rover
    {
        private Coordinate _currentCoordinate;
        private Planet _planet { get; }

        public Coordinate CurrentCoordinate
        {
            get { return _currentCoordinate; }
            set { _currentCoordinate = _planet.MapCoordinateToPlanet(value); }
        }

        public FacingDirection CurrentFacingDirection { get; set; }

        private Rover(
            Coordinate startingCoordinate,
            FacingDirection startingFacingDirection,
            Planet planet)
        {
            if (planet == null)
            {
                throw new PlanetRequired();
            }

            _planet = planet;

            if (startingCoordinate == null)
            {
                throw new CoordinateRequired();
            }

            CurrentCoordinate = startingCoordinate;

            if (startingFacingDirection == null)
            {
                throw new FacingDirectionRequired();
            }

            CurrentFacingDirection = startingFacingDirection;
        }

        public static Rover CreateRover(string startingPosition, Planet planet)
        {
            if (planet == null)
            {
                throw new PlanetRequired();
            }

            var positionParsed = new StartingPositionParser(startingPosition);
            var facingDirection = new FacingDirectionFactory().CreateDirection
                                    (positionParsed.Direction, planet);

            return new Rover
                    (positionParsed.Position,
                    facingDirection,
                    planet);
        }

        public void Move(char[] commands)
        {
            var parsedCommands = new CommandParser(commands, this).Commands;

            Move(parsedCommands);
        }

        private static void Move(IEnumerable<Command> commands)
        {
            foreach (var command in commands)
            {
                command.Execute();
            }
        }

        public string CurrentPosition()
        {
            return $"{this.CurrentCoordinate.X},{this.CurrentCoordinate.Y},{CurrentFacingDirection.ToString()}";
        }


    }
}