using CSharpFunctionalExtensions;
using System;

namespace Kata
{
    public abstract class FacingDirection
    {
        internal abstract Result<Coordinate> NextCoordinateForward(Coordinate currentCoordinate);
        internal abstract Result<Coordinate> NextCoordinateBackward(Coordinate currentCoordinate);
        internal abstract FacingDirection NextFacingDirectionLeft();
        internal abstract FacingDirection NextFacingDirectionRight();

    }
}