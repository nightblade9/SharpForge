using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using SharpForge.Backend.MonoGameAndNez.Adapter;
using SharpForge.Core.Nodes;
using SharpForge.Framework;
using System;

namespace SharpForge.Backend.MonoGameAndNez;

public class Game : Nez.Core, IGame
{
    /// <summary>
    /// Which scene this game displays on run.
    /// </summary>
    public string StartingSceneFile { get; set; }

    // The parsed version of StartingSceneFile.
    public Node SceneTree { get; set; }

    private Scene _currentScene;
    private SpritePopulator _spritePopulator;

    public Game()
    {
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        if (SceneTree == null)
        {
            throw new InvalidOperationException("Please set a starting scene before running your game!");
        }
        
        // TODO: Add your initialization logic here
        base.Initialize();

        _currentScene = new Scene();
        _currentScene.ClearColor = Color.Black;

        // Assign/activate the current scene
        Nez.Core.Scene = _currentScene;
        _spritePopulator = new SpritePopulator(_currentScene);
        
        PopulateNodes(this.SceneTree);
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

    private void PopulateNodes(Node sceneTree)
    {
        PopulateNode(sceneTree);
        foreach (var child in sceneTree.Contents)
        {
            PopulateNode(child);
        }
    }

    private void PopulateNode(Node node)
    {
        var sprite = node as Sprite;
        if (sprite != null)
        {
            _spritePopulator.PopulateSprite(sprite);
            return;
        }
    }
}
