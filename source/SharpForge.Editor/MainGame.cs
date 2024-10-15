
namespace SharpForge.Editor;

using SharpForge.Framework;
using System.IO;

public class MainGame : Game
{
    public MainGame()
    {
        LoadAndShowScene(Path.Join("Content", "scenes", "SplashScene"));
    }
}
