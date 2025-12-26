using Algorithms.AStar.Primitives;

namespace Algorithms.AStar.Viewer
{
    public static class Settings
    {
        public static readonly Velocity MaxSpeed = Velocity.FromKilometersPerHour(100);
        public static readonly Velocity MinSpeed = Velocity.FromKilometersPerHour(10);
    }
}
