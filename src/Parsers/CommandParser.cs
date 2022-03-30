using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kata
{
    internal class CommandParser
    {
        private readonly Regex _validCommandPattern = new Regex(@"^[FBLR]$");

        private List<Command> _commands = new List<Command>();
        public IReadOnlyCollection<Command> Commands => _commands.AsReadOnly();

        public CommandParser(char[] commands, Rover rover)
        {
            if (rover == null)
            {
                throw new RoverRequired();
            }


            foreach (var command in commands)
            {
                var commandParsed = ParseCommand(command);

                MapParsedCommandToProperties(commandParsed, rover);
            }
        }

        private string ParseCommand(char command)
        {
            Match commandParsed = _validCommandPattern.Match(command.ToString());

            if (!commandParsed.Success)
            {
                throw new InvalidCommand();
            }

            return commandParsed.Value;
        }

        private void MapParsedCommandToProperties(string commandParsed, Rover rover)
        {
            switch (commandParsed)
            {
                case "F":
                    _commands.Add(new ForwardMove(rover));
                    break;
                case "B":
                    _commands.Add(new BackwardMove(rover));
                    break;
                case "L":
                    _commands.Add(new RotateLeft(rover));
                    break;
                case "R":
                    _commands.Add(new RotateRight(rover));
                    break;
                default:
                    throw new InvalidCommand();
            }
        }
    }
}