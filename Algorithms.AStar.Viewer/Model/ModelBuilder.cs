using System;
using System.Collections.Generic;
using ReactiveUI;
using Algorithms.AStar.Grids;
using Algorithms.AStar.Primitives;

namespace Algorithms.AStar.Viewer.Model
{
    internal sealed class ModelBuilder
    {
        public static IEnumerable<ReactiveObject> BuildModel(Grid grid, Action<NodeModel> leftClick, Action<NodeModel> rightClick)
        {
            var models = new List<ReactiveObject>();

            for (var x = 0; x < grid.Columns; x++)
            {
                for (var y = 0; y < grid.Rows; y++)
                {
                    var gridPosition = new GridPosition(x, y);

                    var node = grid.GetNode(gridPosition);

                    if (node.Outgoing.Count > 0)
                    {

                        var nodeModel = new NodeModel(node, gridPosition);
                        nodeModel.LeftClickCommand = ReactiveCommand.Create(() => leftClick(nodeModel));
                        nodeModel.RightClickCommand = ReactiveCommand.Create(() => rightClick(nodeModel));

                        models.Add(nodeModel);

                        foreach (var edge in node.Outgoing)
                        {
                            var edgeModel = new EdgeModel(edge);
                            models.Add(edgeModel);
                        }
                    }
                }
            }

            return models;
        }
    }
}
