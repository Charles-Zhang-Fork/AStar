using System;
using Algorithms.AStar.Graphs;
using Algorithms.AStar.Primitives;

namespace Algorithms.AStar.Paths
{
    internal sealed class PathFinderNode : IComparable<PathFinderNode>
    {
        public PathFinderNode(INode node, Duration durationSoFar, Duration expectedRemainingTime)
        {
            this.Node = node;
            this.DurationSoFar = durationSoFar;
            this.ExpectedRemainingTime = expectedRemainingTime;
            this.ExpectedTotalTime = this.DurationSoFar + this.ExpectedRemainingTime;
        }

        public INode Node { get; }
        public Duration DurationSoFar { get; }
        public Duration ExpectedRemainingTime { get; }
        public Duration ExpectedTotalTime { get; }

        public int CompareTo(PathFinderNode other) => this.ExpectedTotalTime.CompareTo(other.ExpectedTotalTime);
        public override string ToString() => $"📍{{{this.Node.Position.X}, {this.Node.Position.Y}}}, ⏱~{this.ExpectedTotalTime}";
    }
}
