namespace SharpForge.Core.Persistence;

using Microsoft.VisualBasic;
using Newtonsoft.Json;
using SharpForge.Core.Nodes;

/// <summary>
/// The thing that handles standardized serialization and deserialization of nodes.
/// </summary>
public class NodeSerializer()
{
    private JsonSerializerSettings _defaultSettings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.All, // Store and use type info to deserialize.
    };

    public string Serialize(Node root)
    {
        if (root == null)
        {
            throw new ArgumentNullException(nameof(root));
        }
        
        return JsonConvert.SerializeObject(root, _defaultSettings);
    }

    public T Deserialize<T>(string input) where T : Node
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        var toReturn = JsonConvert.DeserializeObject<T>(input, _defaultSettings);
        if (toReturn == null)
        {
            throw new ArgumentException($"Input JSON doesn't deserialize into a Node.");
        }

        return toReturn;
    }
}