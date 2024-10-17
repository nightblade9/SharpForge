using System;
using SharpForge.Core.Nodes;

namespace SharpForge.Core.UnitTests.Nodes;

[TestFixture]
public class NodeTests
{
    [Test]
    [TestCase(0, false)]
    [TestCase(1, true)]
    [TestCase(17, true)]
    public void ShouldSerializeContents_ReturnsTrue_IfThereAreAnyContents(int numContents, bool expected)
    {
        // Arrange
        var node = new Node();
        for (var i = 0; i < numContents; i++)
        {
            node.Contents.Add(new Node());
        }

        // Act/Assert
        Assert.That(node.ShouldSerializeContents(), Is.EqualTo(expected));
    }
}
