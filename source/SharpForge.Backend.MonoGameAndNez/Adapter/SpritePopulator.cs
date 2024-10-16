using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using SharpForge.Core.Nodes;

namespace SharpForge.Backend.MonoGameAndNez.Adapter;

/// <summary>
/// Handles "populating" sprites: load the texture, create the Nez entity, set the position, etc.
/// </summary>
class SpritePopulator : Populator
{    
    private static Texture2D LoadTexture2DFromFile(string filename)
    {
        using (var stream = File.OpenRead(filename))
        {
            return Texture2D.FromStream(Nez.Core.GraphicsDevice, stream);
        }
    }

    public SpritePopulator(Scene currentScene) : base(currentScene)
    {
    }

    public void Populate(Sprite sprite)
    {
        if (string.IsNullOrWhiteSpace(sprite.ImageFile))
        {
            return;
        }

        var texture = LoadTexture2DFromFile(sprite.ImageFile);
        var component = new SpriteRenderer(texture);
        // Render with (0, 0) being the top-left of the image, not the center.
        component.Origin = Vector2.Zero;
        
        CreateAndAddEntity(component, sprite.Position);
    }
}
