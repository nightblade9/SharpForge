namespace SharpForge.Editor;

using SharpForge.Framework;

public class Program
{
    public static void Main(string[] args)
    {
        ConfigureNezBackend();
        new GameRunner().Run();
        Console.WriteLine("Goodbye!");
    }

    private static void ConfigureNezBackend()
    {
    }
}
