using System.Collections.Generic;
using Algorithms.AStar.Graphs;
using Algorithms.AStar.Primitives;

namespace Algorithms.AStar.Paths
{
    public sealed class Path
    {
        public Path(PathType type, IReadOnlyList<IEdge> edges)
        {
            this.Type = type;
            this.Edges = edges;

            for (var i = 0; i < this.Edges.Count; i++)
            {
                this.Duration += this.Edges[i].TraversalDuration;
                this.Distance += this.Edges[i].Distance;
            }
        }

        public PathType Type { get; }

        public Duration Duration { get; }

        public IReadOnlyList<IEdge> Edges { get; }
        public Distance Distance { get; }
    }
}
