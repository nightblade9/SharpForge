using System;
using Microsoft.Xna.Framework;
using Nez;
using SharpForge.Core.Nodes;

namespace SharpForge.Backend.MonoGameAndNez.Adapter;

class LabelPopulator : Populator
{
    public LabelPopulator(Scene currentScene) : base(currentScene)
    {
    }

    public void Populate(Label label)
    {
        if (label.FontSize <= 1)
        {
            throw new ArgumentException(nameof(label.FontSize));
        }

        var component = new TextComponent(Graphics.Instance.BitmapFont, label.Text, label.Position, Color.Red)
            // TODO: z-indexes are tricksy little hobbitses ... render on top of everything else (for now)
            .SetRenderLayer(999);
            
        CreateAndAddEntity(component, label.Position);
    }
}
