namespace SharpForge.Framework.UnitTests;

public class GameTests
{
    [Test]
    [TestCase("hi there")]
    [TestCase("123#$%456")]
    [TestCase("one.two.three")]
    [TestCase("fourtyfive")]
    [TestCase("endswithscene")]
    [TestCase("wrongspelling.scenee")]
    public void NormalizeSceneName_AppendsDotScene_IfNotPresent(string input)
    {
        // Act
        var actual = Game.NormalizeSceneName(input);
        Assert.That(actual, Is.EqualTo($"{input}.scene"));
    }

    [Test]
    [TestCase("hi there.scene")]
    [TestCase("IgNoreCase.SCEne")]
    [TestCase("one.two.three.SCENE")]
    public void NormalizeSceneName_DoesNotAppendDotScene_IfPresent(string input)
    {
        // Act
        var actual = Game.NormalizeSceneName(input);
        Assert.That(actual, Is.EqualTo(input));
    }

    [Test]
    public void VerifySceneExists_Throws_IfSceneFileDoesntExist()
    {
        // Act
        var ex = Assert.Throws<ArgumentException>(() => Game.VerifySceneExists(Path.Join("TestFiles", "Scenes", "DOES_NOT_EXIST.scene")));
        Assert.That(ex, Is.Not.Null);
    }

    [Test]
    public void VerifySceneExists_DoesNotThrow_IfSceneFileExists()
    {
        // Act/Assert
        Game.VerifySceneExists(Path.Join("TestFiles", "Scenes", "Empty.scene"));
        // Does. Not. Throw.
    }
}