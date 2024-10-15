namespace SharpForge.Core.UnitTests.Nodes;

using SharpForge.Core.Persistence;
using SharpForge.Core.Nodes;

[TestFixture]
public class NodeSerializerTests
{
    [Test]
    public void SerializeAndDeserialize_DeserializesNodeType()
    {
        // Arrange
        var input = new Node();
        var serializer = new NodeSerializer();
        var serialized = serializer.Serialize(input);

        // Act
        var actual = serializer.Deserialize<Node>(serialized);

        // Assert
        Assert.That(actual, Is.TypeOf<Node>());
        Assert.That(actual.Contents.Count, Is.EqualTo(0));
    }

    [Test]
    public void SerializeAndDeserialize_DeserializesChildrenNodeTypes()
    {
        // TODO: test with different node types that have different properties
        // Arrange
        var input = new Node();
        input.Contents.Add(new Node());
        var nestedNodeParent = new Node();
        nestedNodeParent.Contents.Add(new Node());
        input.Contents.Add(nestedNodeParent);
        var serializer = new NodeSerializer();
        var serialized = serializer.Serialize(input);

        // Act
        var actual = serializer.Deserialize<Node>(serialized);

        // Assert
        Assert.That(actual, Is.TypeOf<Node>());
        Assert.That(actual.Contents.Count, Is.EqualTo(2));

        foreach (var node in actual.Contents)
        {
            Assert.That(node, Is.Not.Null);
            Assert.That(node, Is.TypeOf<Node>());
        }

        // Nested deserialization
        Assert.That(actual.Contents[1].Contents.Count, Is.EqualTo(1));
        Assert.That(actual.Contents[1].Contents[0], Is.TypeOf<Node>());
    }

    [Test]
    public void SerializeAndDeserialize_DeserializeSpriteTypeAndImageFilename()
    {
        // Arrange
        var sprite = new Sprite();
        var expectedImageFile = "Content/images/foo/bar.png";
        sprite.ImageFile = expectedImageFile;
        var serializer = new NodeSerializer();

        // Act
        var actual = serializer.Deserialize<Sprite>(serializer.Serialize(sprite));

        // Assert
        Assert.That(actual, Is.TypeOf<Sprite>());
        Assert.That(actual.ImageFile, Is.EqualTo(expectedImageFile));
    }

    [Test]
    public void SerializeAndDeserialize_DeserializesSplashScene()
    {
        // Arrange
        var sceneContents = GetSceneContents("SplashScene.scene");
        var serializer = new NodeSerializer();

        // Act
        var actualRoot = serializer.Deserialize<Node>(sceneContents);

        // Assert
        Assert.That(actualRoot, Is.TypeOf<Node>());
        Assert.That(actualRoot.Contents.Count, Is.EqualTo(1));

        Sprite actualSprite = actualRoot.Contents[0] as Sprite; // Redundant but it works?
        Assert.That(actualSprite, Is.Not.Null);
        Assert.That(actualSprite, Is.InstanceOf<Sprite>());
        Assert.That(actualSprite, Is.TypeOf<Sprite>());
        Assert.That(actualSprite.ImageFile, Is.EqualTo("Contents/Images/logo.png"));
    }

    private string GetSceneContents(string sceneFile)
    {
        var path = Path.Join("TestFiles", "Scenes", sceneFile);
        var contents = File.ReadAllText(path);
        return contents;
    }
}