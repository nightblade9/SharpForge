namespace SharpForge.Core.Nodes;

/// <summary>
/// A sprite, an image loaded from a file.
/// </summary>
public class Sprite : Node
{
    /// <summary>
    /// Is this sprite centered? Defaults to false (meaning the top-left corner of th sprite is at (0, 0).)
    /// If it's true, the center of the sprite is at (0, 0) instead.
    /// </summary>
    public bool IsCentered { get; set; } = false;

    /// <summary>
    /// The image file for the image this sprite represents.
    /// </summary>
    public string ImageFile { get; set; } = default!;
}
