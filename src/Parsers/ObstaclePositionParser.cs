using System.Text.RegularExpressions;

namespace Kata
{
    internal class ObstaclePositionParser
    {
        private readonly Regex _validPositionFormat = new Regex(@"^(?<x>-?\d),(?<y>-?\d)$");
        public Coordinate Position { get; private set; }

        public ObstaclePositionParser(string position)
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
        }
    }
}