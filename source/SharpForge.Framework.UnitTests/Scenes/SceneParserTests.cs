using SharpForge.Core.Nodes;
using SharpForge.Framework.Scenes;

namespace SharpForge.Framework.UnitTests.Scenes;

[TestFixture]
public class SceneParserTests
{
    [Test]
    [TestCase("fake.scene")]
    [TestCase("not a scene file")]
    [TestCase("hi.bmp")]
    [TestCase("LOGO.png")]
    [TestCase("splash.SCENE")]
    public void VerifySceneExists_Throws_IfSceneDoesntExist(string sceneFile)
    {
        // Act/Assert
        Assert.Throws<ArgumentException>(() => SceneParser.VerifySceneExists(Path.Join("TestFiles", "Scenes", sceneFile)));
    }

    [Test]
    public void VerifySceneExists_DoesNotThrow_IfSceneExists()
    {
        // Act/Assert. DOes not throw.
        SceneParser.VerifySceneExists(Path.Join("TestFiles", "Scenes", "SplashScene.scene"));
    }

    [Test]
    // Missing extension
    [TestCase("missing", "missing.scene")]
    [TestCase("MISSINGO", "MISSINGO.scene")]
    [TestCase("weird scene.scene.exe", "weird scene.scene.exe.scene")]
    [TestCase("weird scene.scen", "weird scene.scen.scene")]
    // Extension present
    [TestCase("abc.scene", "abc.scene")]
    [TestCase("case_insensitive.SCENE", "case_insensitive.SCENE")]
    [TestCase("hi there", "hi there.scene")]
    public void NormalizeSceneName_AddsExtensionIfMissing(string input, string expected)
    {
        // Act
        var actual = SceneParser.NormalizeSceneName(input);
        
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void LoadScene_Throws_IfSceneNameIsNull()
    {
        // Act/Assert
        Assert.Throws<ArgumentNullException>(() => SceneParser.LoadScene(null));
    }

    [Test]
    [TestCase("")]
    [TestCase("              ")]
    public void LoadScene_Throws_IfSceneNameIsWhitespace(string sceneName)
    {
        // Act/Assert
        Assert.Throws<ArgumentException>(() => SceneParser.LoadScene(sceneName));
    }

    [Test]
    public void LoadScene_Throws_IfSceneDoesntExist()
    {
        // Act/Assert
        Assert.Throws<ArgumentException>(() => SceneParser.LoadScene("boop.scene"));
    }

    [Test]
    public void LoadScene_ReturnsSceneTreeFromSceneFile()
    {
        // Act
        var tree = SceneParser.LoadScene(Path.Join("TestFiles", "Scenes", "SplashScene.scene"));
        
        // Assert
        Assert.That(tree, Is.TypeOf<Node>());
        Assert.That(tree.Contents.Count, Is.EqualTo(2));
        var logo = tree.Contents[0];
        Assert.That(logo, Is.InstanceOf<Sprite>());
        Assert.That((logo as Sprite).IsCentered, Is.True);
        var caption = tree.Contents[1];
        Assert.That(caption, Is.TypeOf<Label>());
        Assert.That((caption as Label).Text, Is.EqualTo("SharpForge"));
    }
}
