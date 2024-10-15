using SharpForge.Core.Nodes;

namespace SharpForge.Core;

public class Game : Backend.Nezz.Game
{
    protected void PopulateNodes(Node sceneTree)
    {
        PopulateNode(sceneTree);
        foreach (var child in sceneTree.Contents)
        {
            PopulateNode(child);
        }
    }

    protected void PopulateNode(Node node)
    {
        var sprite = node as Sprite;
        if (sprite == null || string.IsNullOrWhiteSpace(sprite.ImageFile))
        {
            // Not a sprite. Uglier than checking if "node is Sprite", but makes compiler go brrrr.
            // (Gets rid of a CS8062 warning.)
            return;
        }

        PopulateSprite(sprite.ImageFile);
    }
}
