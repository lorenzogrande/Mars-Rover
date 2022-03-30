
namespace Kata.Tests
{
    public class RoverBuilder
    {
        private string _position;
        private Planet _planet;
        public RoverBuilder WithStartingPosition(string position)
        {
            _position = position;
            return this;
        }

        public RoverBuilder WithPlanet(Planet planet)
        {
            _planet = planet;
            return this;
        }

        public Rover Build() => Rover.CreateRover(_position, _planet);
    }
}