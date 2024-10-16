namespace SharpForge.Editor;

using Microsoft.Extensions.DependencyInjection;
using SharpForge.Backend.MonoGameAndNez;
using SharpForge.Framework;

public class Program
{
    private ServiceProvider _serviceProvider = default!;

    public static void Main(string[] args)
    {
        new Program().Run();
    }

    private void Run()
    {
        ConfigureNezBackend();

        var game = _serviceProvider.GetRequiredService<IGame>();
        game.Run();

        Console.WriteLine("Goodbye!");
    }

    private void ConfigureNezBackend()
    {
        // 1. Create the service collection.
        var services = new ServiceCollection();

        // 2. Register (add and configure) the services.
        services.AddSingleton<IGame, Game>();

        // 3. Build the service provider from the service collect
        _serviceProvider = services.BuildServiceProvider();
    }
}
