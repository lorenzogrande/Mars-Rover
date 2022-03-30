namespace Kata
{
    internal class ForwardMove : Command
    {
        private Rover _rover;

        public ForwardMove(Rover rover)
        {
            this._rover = rover;
        }

        public void Execute()
        {
            var nextCoordinate = _rover.CurrentFacingDirection.NextCoordinateForward(_rover.CurrentCoordinate);
            if (nextCoordinate.IsFailure)
            {
                throw new InvalidMove(nextCoordinate.Error + " - Current position is: " + _rover.CurrentPosition());
            }
            _rover.CurrentCoordinate = nextCoordinate.Value;
        }
    }
}