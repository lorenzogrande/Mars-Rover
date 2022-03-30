using CSharpFunctionalExtensions;

namespace Kata
{
    public class North : FacingDirection
    {
        private Planet _planet;

        public North(Planet planet)
        {
            this._planet = planet;
        }

        public override string ToString()
        {
            return "N";
        }

        internal override Result<Coordinate> NextCoordinateForward(Coordinate currentCoordinate)
        {
            var nextCoordinate = _planet.MapCoordinateToPlanet(
                                    new Coordinate(
                                            currentCoordinate.X,
                                            currentCoordinate.Y + 1
                                            )
                                        );

            if (_planet.CoordinateIsAnObstacle(nextCoordinate))
            {
                return Result.Failure<Coordinate>("Unable to move forward. There is an obstacle");
            }

            return Result.Success(nextCoordinate);
        }

        internal override Result<Coordinate> NextCoordinateBackward(Coordinate currentCoordinate)
        {
            var nextCoordinate = _planet.MapCoordinateToPlanet(
                        new Coordinate(
                                currentCoordinate.X,
                                currentCoordinate.Y - 1
                                )
                            );

            if (_planet.CoordinateIsAnObstacle(nextCoordinate))
            {
                return Result.Failure<Coordinate>("Unable to move forward");
            }

            return Result.Success(nextCoordinate);
        }

        internal override FacingDirection NextFacingDirectionLeft()
        {
            return new West(_planet);
        }

        internal override FacingDirection NextFacingDirectionRight()
        {
            return new East(_planet);
        }
    }
}
