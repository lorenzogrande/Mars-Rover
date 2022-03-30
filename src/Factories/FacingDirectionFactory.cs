using System;

namespace Kata
{
    internal abstract class DirectionFactory
    {
        public abstract FacingDirection CreateDirection(CardinalDirection direction, Planet planet);
    }

    internal class FacingDirectionFactory : DirectionFactory
    {
        public override FacingDirection CreateDirection(CardinalDirection direction, Planet planet)
        {
            if (planet is null)
            {
                throw new PlanetRequired();
            }

            switch (direction)
            {
                case CardinalDirection.NORTH:
                    return new North(planet);
                case CardinalDirection.SOUTH:
                    return new South(planet);
                case CardinalDirection.EAST:
                    return new East(planet);
                case CardinalDirection.WEST:
                    return new West(planet);
                default:
                    throw new InvalidDirection();
            }
        }
    }
}