namespace SharpForge.Framework;

using System.IO;

public class Game : SharpForge.Core.Game
{
    public void LoadAndShowScene(string sceneName)
    {
        System.Console.WriteLine($"Loading and displaying {sceneName}!");
        var normalizedName = this.NormalizeSceneName(sceneName);
        this.VerifySceneExists(normalizedName);

        string sceneContents = File.ReadAllText(normalizedName);
        System.Console.WriteLine($"Scene contents: {sceneContents}!");
    }

    private string NormalizeSceneName(string input)
    {
        if (input.ToLower().EndsWith(".scene"))
        {
            return input;
        }

        return $"{input}.scene";
    }

    private void VerifySceneExists(string normalizedName)
    {
        if (!File.Exists(normalizedName))
        {
            throw new ArgumentException($"Scene {normalizedName} doesn't seem to exist!");
        }
    }
}
