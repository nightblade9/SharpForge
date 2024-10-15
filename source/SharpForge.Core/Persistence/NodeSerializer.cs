namespace SharpForge.Core.Persistence;

using Newtonsoft.Json;
using SharpForge.Core.Nodes;

/// <summary>
/// The thing that handles standardized serialization and deserialization of nodes.
/// </summary>
public class NodeSerializer()
{
    public string Serialize(Node root)
    {
        if (root == null)
        {
            throw new ArgumentNullException(nameof(root));
        }
        
        return JsonConvert.SerializeObject(root);
    }

    public T Deserialize<T>(string input) where T : Node
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        var toReturn = JsonConvert.DeserializeObject<T>(input);
        if (toReturn == null)
        {
            throw new ArgumentException($"Input JSON doesn't deserialize into a Node.");
        }

        return toReturn;
    }
}