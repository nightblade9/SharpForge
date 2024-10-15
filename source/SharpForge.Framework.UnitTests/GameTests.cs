namespace SharpForge.Framework.UnitTests;

public class GameTests
{
    [Test]
    [TestCase("hi there")]
    [TestCase("123#$%456")]
    [TestCase("one.two.three")]
    [TestCase("fourtyfive")]
    public void NormalizeSceneName_AppendsDotScene_IfNotPresent(string input)
    {
        // Act
        var actual = Game.NormalizeSceneName(input);
        Assert.That(actual, Is.EqualTo($"{input}.scene"));
    }
}