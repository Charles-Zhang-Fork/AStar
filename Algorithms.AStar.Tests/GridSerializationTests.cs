using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Algorithms.AStar.Graphs;
using Algorithms.AStar.Grids;
using Algorithms.AStar.Paths;
using Algorithms.AStar.Primitives;
using Algorithms.AStar.Serialization;

namespace Algorithms.AStar.Tests
{
    public sealed class GridSerializationTests
    {
        [Test]
        public void GraphIsEqualAfterSerializeAndDeSerialize()
        {
            var grid = Grid.CreateGridWithLateralConnections(new GridSize(2, 4),
                new Size(Distance.FromMeters(2.0f), Distance.FromMeters(1.0f)), Velocity.FromKilometersPerHour(3));

            var stringGrid = GridSerializer.SerializeGrid(grid);
            var deserializedGrid = GridSerializer.DeSerializeGrid(stringGrid);

            Assert.AreEqual(grid.Rows, deserializedGrid.Rows);
            Assert.AreEqual(grid.Columns, deserializedGrid.Columns);
            for (int i = 0; i < grid.Columns; i++)
            {
                for (int j = 0; j < grid.Rows; j++)
                {
                    var gridPosition = new GridPosition(i, j);
                    var originalNode = grid.GetNode(gridPosition);
                    var deserializedNode = deserializedGrid.GetNode(gridPosition);
                    Assert.AreEqual(originalNode.Position, deserializedNode.Position);
                    Assert.AreEqual(originalNode.Outgoing.Count, deserializedNode.Outgoing.Count);
                    Assert.AreEqual(originalNode.Incoming.Count, deserializedNode.Incoming.Count);
                    foreach (var edge in originalNode.Outgoing)
                    {
                        var matchingEdge = deserializedNode.Outgoing.Single(o =>
                            o.Start.Position.Equals(edge.Start.Position) && o.End.Position.Equals(edge.End.Position));
                        Assert.AreEqual(edge.Distance, matchingEdge.Distance);
                        Assert.AreEqual(edge.TraversalDuration, matchingEdge.TraversalDuration);
                        Assert.AreEqual(edge.TraversalVelocity, matchingEdge.TraversalVelocity);
                    }

                    foreach (var edge in originalNode.Incoming)
                    {
                        var matchingEdge = deserializedNode.Incoming.Single(o =>
                            o.Start.Position.Equals(edge.Start.Position) && o.End.Position.Equals(edge.End.Position));
                        Assert.AreEqual(edge.Distance, matchingEdge.Distance);
                        Assert.AreEqual(edge.TraversalDuration, matchingEdge.TraversalDuration);
                        Assert.AreEqual(edge.TraversalVelocity, matchingEdge.TraversalVelocity);
                    }
                }
            }
        }
    }
}