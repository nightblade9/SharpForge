using System;
using Nez;

namespace SharpForge.Backend.MonoGameAndNez.Adapter;

abstract class Populator
{
    private readonly Scene _currentScene;
    
    protected Populator(Scene currentScene)
    {
        ArgumentNullException.ThrowIfNull(currentScene);
        _currentScene = currentScene;
    }

    protected void CreateAndAddEntity(Component component)
    {
        ArgumentNullException.ThrowIfNull(component);
        
        var entity = new Entity();
        entity.AddComponent(component);
        _currentScene.AddEntity(entity);
    }
}
