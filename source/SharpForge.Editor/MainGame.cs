
namespace SharpForge.Editor;

using System.IO;

public class MainGame : SharpForge.Framework.Game
{
    public MainGame()
    {
        this.LoadAndShowScene(Path.Join("scenes", "HelloWorld"));
    }
}
