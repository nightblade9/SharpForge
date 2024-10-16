namespace SharpForge.Framework;

public class GameRunner : IDisposable
{
    private IGame _game;

    public GameRunner(IGame game)
    {
        _game = game;
    }

    public void Dispose()
    {
        _game.Dispose();
    }

    public void Run()
    {
        _game.Run();
    }
}
