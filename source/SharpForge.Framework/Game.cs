namespace SharpForge.Framework;

using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using SharpForge.Core.Nodes;
using SharpForge.Core.Persistence;

public class Game : SharpForge.Core.Game
{
    internal static string NormalizeSceneName(string input)
    {
        if (input.ToLower().EndsWith(".scene"))
        {
            return input;
        }

        return $"{input}.scene";
    }

    internal static void VerifySceneExists(string normalizedName)
    {
        if (!File.Exists(normalizedName))
        {
            throw new ArgumentException($"Scene {normalizedName} doesn't seem to exist!");
        }
    }

    public void LoadAndShowScene(string sceneName)
    {
        var normalizedName = NormalizeSceneName(sceneName);
        VerifySceneExists(normalizedName);

        string sceneContents = File.ReadAllText(normalizedName);
        // TODO: how do we know the root is type Node? What if it's a Sprite, will this return Sprite as the root?
        var sceneTree = new NodeSerializer().Deserialize<Node>(sceneContents);
        

        ///////////////// TODO: don't assume here ...
        var sprite = sceneTree.Contents[0] as Sprite;
        // Remove "Content"
        var texture = LoadTexture2DFromFile(sprite.ImageFile);
        var entity = new Entity();
        var component = new SpriteRenderer(texture);
        // Gotta do this for all images because center is the middle by default.
        component.Origin = Vector2.Zero;
        entity.AddComponent(component);

        var tempScene = new Scene();
        tempScene.ClearColor = Color.Black;
        tempScene.AddEntity(entity);
        
        // This is where the magic happens
        Core.Scene = tempScene;
    }

    // TODO: this doesn't belong here!
    private static Texture2D LoadTexture2DFromFile(string filename)
    {
        using (var stream = File.OpenRead(filename))
        {
            return Texture2D.FromStream(GraphicsDevice, stream);
        }
    }
}
