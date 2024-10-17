using System.Numerics;

namespace SharpForge.Core.Nodes;

/// <summary>
/// A node, the basic class for everything that you see and interact with in-game. It's a 2D object with no contents.
/// Nodes are hierarchial. Children are rendered in the order they're added.
/// </summary>
public class Node
{
    public Vector2 Position { get; set; } = Vector2.Zero;
    public IList<Node> Contents { get; } = new List<Node>();

    // Some JSON.NET magic; don't serialize "Contents" unless it has any entries.
    // This, coupled with the serializer's "IgnoreAndPopulate," means empty lists don't get serialized; but on
    // deserialization, instead of null, they come back as an empty list. Groovy! Clean JSON!
    public bool ShouldSerializeContents()
    {
        return Contents.Any();
    }
}