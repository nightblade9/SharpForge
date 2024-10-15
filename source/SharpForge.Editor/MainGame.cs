
namespace SharpForge.Editor;

using SharpForge.Framework;
using System.IO;

public class MainGame : Game
{
    protected override void Initialize()
    {
        base.Initialize();
        LoadAndShowScene(Path.Join("Content", "scenes", "SplashScene"));
    }
}
