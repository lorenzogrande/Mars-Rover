using CSharpFunctionalExtensions;
using System.Collections.Generic;

namespace Kata
{
    public class Coordinate : ValueObject
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return X;
            yield return Y;
        }
    }
}