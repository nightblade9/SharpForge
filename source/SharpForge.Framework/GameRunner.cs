using SharpForge.Framework.Scenes;

namespace SharpForge.Framework;

public class GameRunner
{
    public static void Run(IGame game)
    {
        if (string.IsNullOrWhiteSpace(game.StartingSceneFile))
        {
            throw new InvalidOperationException("Please set a starting scene before running your game!");
        }

        var tree = SceneParser.LoadScene(game.StartingSceneFile);
        game.SceneTree = tree;
        game.Run();
    }
}
