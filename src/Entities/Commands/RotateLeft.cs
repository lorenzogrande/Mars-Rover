namespace Kata
{
    internal class RotateLeft : Command
    {
        private Rover _rover;

        public RotateLeft(Rover rover)
        {
            this._rover = rover;
        }

        public void Execute()
        {
            _rover.CurrentFacingDirection = _rover.CurrentFacingDirection.NextFacingDirectionLeft();
        }
    }
}