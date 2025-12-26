using System.Collections.Generic;
using Algorithms.AStar.Primitives;

namespace Algorithms.AStar.Graphs
{
    public interface INode
    {
        Position Position { get; }
        IList<IEdge> Incoming { get; }
        IList<IEdge> Outgoing { get; }
    }
}
