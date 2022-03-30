
namespace Kata.Tests
{
    public class PlanetBuilder
    {

        private string[] _obstaclePositions;
        private int _semicircleLength;
        public PlanetBuilder WithObstacles(string[] obstaclePositions)
        {
            _obstaclePositions = obstaclePositions;
            return this;
        }

        public PlanetBuilder WithSemicircleLength(int semicircleLength)
        {
            _semicircleLength = semicircleLength;
            return this;
        }

        public Planet Build() => new Planet(_semicircleLength, _obstaclePositions);
    }
}