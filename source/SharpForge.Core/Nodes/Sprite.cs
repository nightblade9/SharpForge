namespace SharpForge.Core.Nodes;

public class Sprite : Node
{
    public string ImageFile { get; set; } = default!;

    public Sprite()
    {
        this.NodeType = "Sprite";
    }
}
