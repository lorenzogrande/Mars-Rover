namespace Kata
{
    internal class BackwardMove : Command
    {
        private Rover _rover;

        public BackwardMove(Rover rover)
        {
            this._rover = rover;
        }

        public void Execute()
        {
            var nextCoordinate =
                _rover
                .CurrentFacingDirection
                .NextCoordinateBackward(_rover.CurrentCoordinate);

            if (nextCoordinate.IsFailure)
            {
                throw new InvalidMove(nextCoordinate.Error + " - Current position is: " + _rover.CurrentPosition());
            }
            _rover.CurrentCoordinate = nextCoordinate.Value;
        }
    }
}