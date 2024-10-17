using SharpForge.Core.Nodes;
using SharpForge.Core.Persistence;

namespace SharpForge.Framework.Scenes;

public static class SceneParser
{
    public static Node LoadScene(string sceneName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(sceneName);
        var normalizedName = NormalizeSceneName(sceneName);
        VerifySceneExists(normalizedName);

        string sceneContents = File.ReadAllText(normalizedName);
        
        // TODO: how do we know the root is type Node? What if it's a Sprite, will this return Sprite as the root?
        var sceneTree = new NodeSerializer().Deserialize<Node>(sceneContents);
        return sceneTree;
    }

    internal static string NormalizeSceneName(string sceneName)
    {
        if (sceneName.ToLower().EndsWith(".scene"))
        {
            return sceneName;
        }

        return $"{sceneName}.scene";
    }

    internal static void VerifySceneExists(string sceneName)
    {
        if (!File.Exists(sceneName))
        {
            throw new ArgumentException($"Scene {sceneName} doesn't seem to exist!");
        }
    }
}
