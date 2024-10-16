using System;
using Microsoft.Xna.Framework;
using Nez;
using SharpForge.Backend.MonoGameAndNez.Text;
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

        var font = FontLoader.Instance.GetFont("Arial", label.FontSize);
        var component = new TextComponent(font, label.Text, label.Position, Color.White);
            
        CreateAndAddEntity(component);
    }
}
