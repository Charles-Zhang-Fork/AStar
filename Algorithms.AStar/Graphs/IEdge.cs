using Algorithms.AStar.Primitives;

namespace Algorithms.AStar.Graphs
{
    public interface IEdge
    {
        Velocity TraversalVelocity { get; set; }
        Duration TraversalDuration { get; }
        Distance Distance { get; }
        INode Start { get; }
        INode End { get; }
    }
}