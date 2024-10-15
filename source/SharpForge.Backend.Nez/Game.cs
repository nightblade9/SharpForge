namespace SharpForge.Backend.Nezz; // resolve namespace conflict with "Nez.*" e.g. Nez.Core

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using System.IO;

public class Game : Core
{    
    private static Texture2D LoadTexture2DFromFile(string filename)
    {
        using (var stream = File.OpenRead(filename))
        {
            return Texture2D.FromStream(GraphicsDevice, stream);
        }
    }

    private Scene _currentScene;

    public Game()
    {
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();

        // TODO: Add your initialization logic here
        _currentScene = new Scene();
        // Set background colour
        _currentScene.ClearColor = Color.Black;
        
        // Assign/activate the current scene
        Core.Scene = _currentScene;
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }
        
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }

    protected void PopulateSprite(string imageFile)
    {
        var texture = LoadTexture2DFromFile(imageFile);
        var entity = new Entity();
        var component = new SpriteRenderer(texture);
        // Render with (0, 0) being the top-left of the image, not the center.
        component.Origin = Vector2.Zero;
        
        entity.AddComponent(component);
        _currentScene.AddEntity(entity);
    }
}