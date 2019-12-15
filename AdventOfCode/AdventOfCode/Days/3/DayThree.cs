using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AdventOfCode.Days._3
{
    public class DayThree
    {
        public int GetClosestIntersectAsManhattan(string[] graph1, string[] graph2)
        {
            var point = GetClosestIntersect(graph1, graph2);
            return Math.Abs(point.X) + Math.Abs(point.Y);
        }

        public int GetShortestCableInterect(string[] graph1, string[] graph2)
        {
            var tracedRoute = WalkTheGraph(graph1);
            var intersects = TraceTheSteps(graph2, tracedRoute);

            var shortest = (new Point(32561, 62561), 123456686,1232164);
            foreach (var intersect in intersects)
            {
                var intersectManhattan = GetCableLength(intersect);
                var shortestManhattan = GetCableLength(shortest);
                if (intersectManhattan < shortestManhattan)
                {
                    shortest = intersect;
                }
            }

            return GetCableLength(shortest);
        }

        private int GetCableLength((Point p, int stepsGraph1, int stepsGraph2) point)
        {
            return point.stepsGraph1 + point.stepsGraph2;
        }

        public (int X, int Y) GetClosestIntersect(string[] graph1, string[] graph2)
        {
            var tracedRoute = WalkTheGraph(graph1);
            var intersects = TraceTheSteps(graph2, tracedRoute);

            Point shortest = new Point(32561, 62561);
            foreach (var intersect in intersects)
            {
                var intersectManhattan = GetManhattanDistanceFromCenter(intersect.p);
                var shortestManhattan = GetManhattanDistanceFromCenter(shortest);
                if (intersectManhattan < shortestManhattan)
                {
                    shortest = intersect.p;
                }
            }

            return (X: shortest.X, Y: shortest.Y);
        }

        private static int GetManhattanDistanceFromCenter(Point point)
        {
            return Math.Abs(point.X) + Math.Abs(point.Y);
        }

        public List<(Point p, int stepsGraph1, int stepsGraph2)> TraceTheSteps(string[] graph, IDictionary<string, int> tracedRoute)
        {
            var position = new Point(0, 0);
            var list = new List<(Point cross, int graph1, int graph2)>();

            var steps = 1;
            foreach (var instruction in graph)
            {
                (position, steps) = WalkTheDirection((point, stepsTaken) =>
                    {
                        var key = CreateKey(point);
                        if (tracedRoute.TryGetValue(key, out var value))
                        {
                            list.Add((point, value, stepsTaken));
                        }
                    }
                    , instruction
                    , position,
                    steps);
            }
            return list;
        }

        public IDictionary<string, int> WalkTheGraph(string [] graph)
        {
            var dict = new Dictionary<string, int>();

            int steps = 1;
            var position = new Point(0, 0);
            foreach (var instruction in graph)
            {
                (position, steps) = WalkTheDirection((point, stepsTaken) =>
                    {
                        var key = CreateKey(point);
                        if (!dict.ContainsKey(key))
                        {
                            dict.Add(key, stepsTaken);
                        }
                    }
                    , instruction
                    , position
                    , steps);
            }

            return dict;
        }

        private static string CreateKey(Point point)
        {
            return $"{point.X},{point.Y}";
        }

        private (Point p, int stepsTaken) WalkTheDirection(Action<Point, int> actionOnEachCell, string operation, Point startingPosition, int stepsStarting)
        {
            var currentPosition = new Point(startingPosition.X, startingPosition.Y);
            var direction = operation.First();
            var steps = int.Parse(operation.Substring(1));

            for (int i = 0; i < steps; i++)
            {
                switch (direction)
                {
                    case 'R':
                        currentPosition.X = currentPosition.X + 1;
                        break;
                    case 'U':
                        currentPosition.Y = currentPosition.Y + 1;
                        break;
                    case 'L':
                        currentPosition.X = currentPosition.X - 1;
                        break;
                    case 'D':
                        currentPosition.Y = currentPosition.Y - 1;
                        break;
                }

                actionOnEachCell(currentPosition, stepsStarting);
                stepsStarting++;
            }

            return (currentPosition, stepsStarting);
        }
    }
}
