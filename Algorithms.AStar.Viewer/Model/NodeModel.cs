using ReactiveUI;
using Algorithms.AStar.Graphs;
using Algorithms.AStar.Primitives;

namespace Algorithms.AStar.Viewer.Model
{
    internal sealed class NodeModel : ReactiveObject
    {
        private NodeState nodeState;

        public NodeModel(INode node, GridPosition gridPosition)
        {
            this.Node = node;
            this.GridPosition = gridPosition;
            this.nodeState = NodeState.None;
        }

        public INode Node { get; }
        public GridPosition GridPosition { get; }

        public float X => this.Node.Position.X;
        public float Y => this.Node.Position.Y;

        public NodeState NodeState
        {
            get => this.nodeState;
            set => this.RaiseAndSetIfChanged(ref this.nodeState, value);
        }

        public float Z => 2;

        public IReactiveCommand LeftClickCommand { get; set; }
        public IReactiveCommand RightClickCommand { get; set; }
    }
}
