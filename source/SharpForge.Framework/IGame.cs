using SharpForge.Core.Nodes;

namespace SharpForge.Framework;

public interface IGame : IDisposable
{
    public string StartingSceneFile { get; set; }

    // Internal
    public Node SceneTree { get; set;}

    public void Run();
}
