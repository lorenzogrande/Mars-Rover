using CSharpFunctionalExtensions;

namespace Kata
{
    public class South : FacingDirection
    {
        private Planet planet;

        public South(Planet planet)
        {
            this.planet = planet;
        }

        public override string ToString()
        {
            return "S";
        }

        internal override Result<Coordinate> NextCoordinateForward(Coordinate currentCoordinate)
        {
            var nextCoordinate = planet.MapCoordinateToPlanet(
            new Coordinate(
                    currentCoordinate.X,
                    currentCoordinate.Y - 1
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
                           currentCoordinate.X,
                           currentCoordinate.Y + 1
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
            return new East(planet);
        }

        internal override FacingDirection NextFacingDirectionRight()
        {
            return new West(planet);
        }
    }
}
