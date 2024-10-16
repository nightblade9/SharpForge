using System.Numerics;

namespace SharpForge.Core.Nodes;

/// <summary>
/// A node, the basic class for everything that you see and interact with in-game. It's a 2D object with no contents.
/// Nodes are hierarchial. Children are rendered in the order they're added.
/// </summary>
public class Node
{
    public Vector2 Position { get; set; } = Vector2.Zero;
    public IList<Node> Contents = new List<Node>();
}