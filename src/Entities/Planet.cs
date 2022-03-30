using System;
using System.Collections.Generic;

namespace Kata
{
    public class Planet
    {
        private int _semicircleLength;
        private List<Coordinate> _obstaclePositions;

        public Planet(int semicircleLength, string[] obstaclePositions)
        {
            if (semicircleLength == 0)
            {
                throw new InvalidPlanetLength();
            }

            this._semicircleLength = semicircleLength;

            this._obstaclePositions = ParseObstaclePositions(obstaclePositions); ;
        }

        private List<Coordinate> ParseObstaclePositions(string[] obstaclePositions)
        {
            var obstaclePositionCoordinates = new List<Coordinate>();

            if (obstaclePositions != null)
            {
                foreach (var obstacle in obstaclePositions)
                {
                    var obstacleParser = new ObstaclePositionParser(obstacle);
                    var obstaclePositionMapped = MapCoordinateToPlanet(obstacleParser.Position);
                    obstaclePositionCoordinates.Add(obstaclePositionMapped);
                }
            }

            return obstaclePositionCoordinates;
        }

        public bool CoordinateIsAnObstacle(Coordinate coordinate)
        {
            foreach (var obstacle in _obstaclePositions)
            {
                if (coordinate == obstacle)
                {
                    return true;
                }
            }
            return false;
        }
        public Coordinate MapCoordinateToPlanet(Coordinate coordinate)
        {
            return new Coordinate(
                        MapSingleValueToPlanet(coordinate.X),
                        MapSingleValueToPlanet(coordinate.Y)
                    );
        }

        private int MapSingleValueToPlanet(int singleCoordinateValue)
        {
            var coordinateModulus = singleCoordinateValue % (_semicircleLength * 2);
            var mappedValue = coordinateModulus;

            if (coordinateModulus >= 0 && coordinateModulus > _semicircleLength)
            {
                mappedValue = mappedValue - (_semicircleLength * 2);
            }
            else if (coordinateModulus < 0 && coordinateModulus < -_semicircleLength)
            {
                mappedValue = (_semicircleLength * 2) + coordinateModulus;
            }

            return mappedValue;
        }
    }
}