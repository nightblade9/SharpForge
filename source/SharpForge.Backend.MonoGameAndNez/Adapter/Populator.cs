using Microsoft.Xna.Framework;
using Nez;

namespace SharpForge.Backend.MonoGameAndNez.Adapter;

abstract class Populator
{
    private readonly Scene _currentScene;
    
    public Populator(Scene currentScene)
    {
        _currentScene = currentScene;
    }

    protected void CreateAndAddEntity(Component component, Vector2 position)
    {
        var entity = new Entity();
        entity.AddComponent(component);
        entity.Position = position;
        _currentScene.AddEntity(entity);
    }
}
