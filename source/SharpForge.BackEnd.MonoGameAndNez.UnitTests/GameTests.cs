using SharpForge.Backend.MonoGameAndNez;

namespace SharpForge.BackEnd.MonoGameAndNez.UnitTests;

[TestFixture]
public class GameTests
{
    [Test]
    public void Initialize_Throws_IfSceneTreeIsNull()
    {
        // Arrange
        var game = new GameStub();
        
        // Act/Assert
        Assert.Throws<InvalidOperationException>(() => game.Initialize());
    }

    private class GameStub : Game
    {
        new public void Initialize()
        {
            base.Initialize();
        }
    }
}