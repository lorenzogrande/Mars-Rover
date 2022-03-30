using CSharpFunctionalExtensions;

namespace Kata
{
    public class East : FacingDirection
    {
        private Planet _planet;

        public East(Planet planet)
        {
            this._planet = planet;
        }

        public override string ToString()
        {
            return "E";
        }


        internal override Result<Coordinate> NextCoordinateForward(Coordinate currentCoordinate)
        {
            var nextCoordinate = _planet.MapCoordinateToPlanet(
                                    new Coordinate(
                                            currentCoordinate.X + 1,
                                            currentCoordinate.Y
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
                                currentCoordinate.X - 1,
                                currentCoordinate.Y
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
            return new North(_planet);
        }

        internal override FacingDirection NextFacingDirectionRight()
        {
            return new South(_planet);
        }
    }
}
