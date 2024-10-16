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
public class SpritePopulator
{    
    private static Texture2D LoadTexture2DFromFile(string filename)
    {
        using (var stream = File.OpenRead(filename))
        {
            return Texture2D.FromStream(Nez.Core.GraphicsDevice, stream);
        }
    }

    private readonly Scene _currentScene;

    public SpritePopulator(Scene currentScene)
    {
        _currentScene = currentScene;
    }

    public void PopulateSprite(Sprite sprite)
    {
        if (string.IsNullOrWhiteSpace(sprite.ImageFile))
        {
            return;
        }

        var texture = LoadTexture2DFromFile(sprite.ImageFile);
        var entity = new Entity();
        var component = new SpriteRenderer(texture);
        // Render with (0, 0) being the top-left of the image, not the center.
        component.Origin = Vector2.Zero;
        
        entity.AddComponent(component);
        entity.Position = sprite.Position;
        _currentScene.AddEntity(entity);
    }
}
