using Nez;
using SharpForge.Backend.MonoGameAndNez.Adapter;

namespace SharpForge.BackEnd.MonoGameAndNez.UnitTests.Adapter;

[TestFixture]
public class PopulatorTests
{
    // Can't test farther than the constructor, since it requires the MG framework to be initialized.
    // That, by definition, would NOT be a unit test, but an integration test.
    [Test]
    public void Constructor_Throws_IfSceneTreeIsNull()
    {
        // Act/Assert
        Assert.Throws<ArgumentNullException>(() => new PopulatorStub(null));
    }

    private class PopulatorStub : Populator
    {
        public PopulatorStub(Scene currentScene) : base(currentScene)
        {
        }
    }
}
