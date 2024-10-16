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

    protected void CreateAndAddEntity(Component component)
    {
        var entity = new Entity();
        entity.AddComponent(component);
        _currentScene.AddEntity(entity);
    }
}
