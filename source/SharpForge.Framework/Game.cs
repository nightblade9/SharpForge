namespace SharpForge.Framework;

using System.IO;
using SharpForge.Core.Nodes;
using SharpForge.Core.Persistence;

public class Game : SharpForge.Core.Game
{
    internal static string NormalizeSceneName(string input)
    {
        if (input.ToLower().EndsWith(".scene"))
        {
            return input;
        }

        return $"{input}.scene";
    }

    internal static void VerifySceneExists(string normalizedName)
    {
        if (!File.Exists(normalizedName))
        {
            throw new ArgumentException($"Scene {normalizedName} doesn't seem to exist!");
        }
    }

    public void LoadAndShowScene(string sceneName)
    {
        var normalizedName = NormalizeSceneName(sceneName);
        VerifySceneExists(normalizedName);

        string sceneContents = File.ReadAllText(normalizedName);
        // TODO: how do we know the root is type Node? What if it's a Sprite, will this return Sprite as the root?
        var sceneTree = new NodeSerializer().Deserialize<Node>(sceneContents);
        ;
    }

}
