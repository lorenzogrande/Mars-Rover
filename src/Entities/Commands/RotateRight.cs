namespace Kata
{
    internal class RotateRight : Command
    {
        private Rover _rover;

        public RotateRight(Rover rover)
        {
            this._rover = rover;
        }

        public void Execute()
        {
            _rover.CurrentFacingDirection = _rover.CurrentFacingDirection.NextFacingDirectionRight();
        }
    }
}