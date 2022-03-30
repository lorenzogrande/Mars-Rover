using CSharpFunctionalExtensions;

namespace Kata
{
    public class West : FacingDirection
    {
        private Planet planet;

        public West(Planet planet)
        {
            this.planet = planet;
        }

        public override string ToString()
        {
            return "W";
        }

        internal override Result<Coordinate> NextCoordinateForward(Coordinate currentCoordinate)
        {
            var nextCoordinate = planet.MapCoordinateToPlanet(
                   new Coordinate(
                           currentCoordinate.X - 1,
                           currentCoordinate.Y
                           )
                       );

            if (planet.CoordinateIsAnObstacle(nextCoordinate))
            {
                return Result.Failure<Coordinate>("Unable to move forward. There is an obstacle");
            }

            return Result.Success(nextCoordinate);
        }

        internal override Result<Coordinate> NextCoordinateBackward(Coordinate currentCoordinate)
        {
            var nextCoordinate = planet.MapCoordinateToPlanet(
                   new Coordinate(
                           currentCoordinate.X + 1,
                           currentCoordinate.Y
                           )
                       );

            if (planet.CoordinateIsAnObstacle(nextCoordinate))
            {
                return Result.Failure<Coordinate>("Unable to move forward");
            }

            return Result.Success(nextCoordinate);
        }

        internal override FacingDirection NextFacingDirectionLeft()
        {
            return new South(planet);
        }

        internal override FacingDirection NextFacingDirectionRight()
        {
            return new North(planet);
        }
    }
}
