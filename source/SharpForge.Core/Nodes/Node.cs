namespace SharpForge.Core.Nodes;

/// <summary>
/// A node, the basic class for everything that you see and interact with in-game. It's a 2D object with no contents.
/// Nodes are hierarchial. Children are rendered in the order they're added.
/// </summary>
public class Node
{
    // TODO: do we have a Vector2 type for position?

    // TODO: replace with an enum, once we have more node types. How do we handle scenes as node types?
    public string NodeType { get; protected set; } = "Node";
    public IList<Node> Contents = new List<Node>();
}