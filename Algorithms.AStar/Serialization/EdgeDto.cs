namespace Algorithms.AStar.Serialization
{
    public class EdgeDto
    {
        public VelocityDto TraversalVelocity { get; set; }

        public GridPositionDto Start { get; set; }

        public GridPositionDto End { get; set; }
    }
}
