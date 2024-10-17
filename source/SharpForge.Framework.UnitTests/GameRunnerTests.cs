using System.Security.Cryptography.X509Certificates;
using NSubstitute;
using SharpForge.Core.Nodes;

namespace SharpForge.Framework.UnitTests;

[TestFixture]
public class GameRunnerTests
{
    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase("            ")]
    public void Run_Throws_IfStartingSceneFileIsNullOrWhitespace(string startingScene)
    {
        // Arrange
        var game = Substitute.For<IGame>();
        game.StartingSceneFile.Returns(startingScene);

        // Act/Assert
        Assert.Throws<InvalidOperationException>(() => GameRunner.Run(game));
    }

    [Test]
    public void Run_SetsSceneTreeAndRunsGame()
    {
        // Arrange
        var game = Substitute.For<IGame>();
        game.StartingSceneFile.Returns(Path.Join("TestFiles", "Scenes", "SplashScene.scene"));

        // Act
        GameRunner.Run(game);

        // Assert
        Assert.That(game.SceneTree, Is.Not.Null);
        Assert.That(game.SceneTree, Is.TypeOf<Node>());
        Assert.That(game.SceneTree.Contents.Count, Is.EqualTo(2));
        game.Received(1).Run();
    }
}