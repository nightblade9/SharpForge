using SharpForge.Core.Nodes;
using SharpForge.Core.Persistence;

namespace SharpForge.Core.UnitTests.Persistence;

[TestFixture]
public class NodeSerializerTests
{
    [Test]
    public void Serialize_ThrowsIfRootIsNull()
    {
        // Act/Assert
        Assert.Throws<ArgumentNullException>(() => new NodeSerializer().Serialize(null));
    }

    [Test]
    public void Serialize_ReturnsPrettyJson()
    {
        // Arrange
        var node = new Node();
        node.Contents.Add(new Sprite() {
            IsCentered = true,
            ImageFile = "logo.png",
            Position = new System.Numerics.Vector2(13, 31),
        });

        // Act
        var actual = new NodeSerializer().Serialize(node);

        // Assert
        Assert.That(actual.Contains("  {"));
    }

    [Test]
    public void Deserialize_Throws_IfTextIsNull()
    {
        // Act/Assert
        Assert.Throws<ArgumentNullException>(() => new NodeSerializer().Deserialize<Node>(null));
    }

    [Test]
    [TestCase("")]
    [TestCase("         ")]
    public void Deserialize_Throws_IfTextIsWhitespace(string input)
    {
        // Act/Assert
        Assert.Throws<ArgumentException>(() => new NodeSerializer().Deserialize<Node>(input));
    }

    [Test]
    public void Deserialize_ReturnsNonNullValue()
    {
        // Arrange
        var expected = new Sprite() 
        {
            ImageFile = "hi.png",
            IsCentered = false,
            Position = new System.Numerics.Vector2(123, 321),
        };

        var json = new NodeSerializer().Serialize(expected);

        // Act
        var actual = new NodeSerializer().Deserialize<Sprite>(json);
        
        // Assert
        Assert.That(actual, Is.InstanceOf<Sprite>());
        Assert.That(actual.ImageFile, Is.EqualTo(expected.ImageFile));
        Assert.That(actual.IsCentered, Is.EqualTo(expected.IsCentered));
        Assert.That(actual.Position, Is.EqualTo(expected.Position));
    }
}
