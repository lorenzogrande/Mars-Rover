using System.Text.RegularExpressions;

namespace Kata
{
    internal class StartingPositionParser
    {
        private readonly Regex _validPositionFormat = new Regex(@"^(?<x>-?\d),(?<y>-?\d),(?<direction>[NSWE])$");
        public Coordinate Position { get; private set; }

        public CardinalDirection Direction { get; private set; }

        public StartingPositionParser(string position)
        {
            var positionParsed = ParsePosition(position);
            MapParsedPositionToProperties(positionParsed);
        }

        private Match ParsePosition(string position)
        {
            Match positionParsed = _validPositionFormat.Match(position);

            if (!positionParsed.Success)
            {
                throw new InvalidPosition();
            }

            return positionParsed;
        }

        private void MapParsedPositionToProperties(Match positionParsed)
        {
            var x = int.Parse(positionParsed.Groups["x"].Value);
            var y = int.Parse(positionParsed.Groups["y"].Value);
            Position = new Coordinate(x, y);

            var direction = positionParsed.Groups["direction"].Value.ToCharArray()[0];

            switch (direction)
            {
                case 'N':
                    Direction = CardinalDirection.NORTH;
                    break;
                case 'S':
                    Direction = CardinalDirection.SOUTH;
                    break;
                case 'W':
                    Direction = CardinalDirection.WEST;
                    break;
                case 'E':
                    Direction = CardinalDirection.EAST;
                    break;
                default:
                    throw new InvalidDirection();
            }
        }
    }
}