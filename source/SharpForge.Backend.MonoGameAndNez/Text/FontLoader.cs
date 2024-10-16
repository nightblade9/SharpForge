using System;
using System.Collections.Generic;
using System.Linq;
using Nez.BitmapFonts;

namespace SharpForge.Backend.MonoGameAndNez.Text;

class FontLoader
{
    public static FontLoader Instance = new FontLoader();
    private Dictionary<(string, int), BitmapFont> _fonts = new();

    private List<(string, int)> _fontsToLoad = new()
    {
        ("Arial", 36),
    };

    private FontLoader()
    {
    }

    public void LoadAllFonts()
    {
        _fonts.Clear();

        foreach (var fontData in _fontsToLoad)
        {
            var bitmapFont = Nez.Core.Content.LoadBitmapFont("Content/Fonts/Arial-36.fnt", true);
            _fonts[fontData] = bitmapFont;
        }
    }

    public BitmapFont GetFont(string fontName, int fontSize)
    {
        var tuple = (fontName, fontSize);
        if (!_fonts.ContainsKey(tuple))
        {
            throw new InvalidOperationException($"SharpForge doesn't support {fontName} at size {fontSize}. Valid fonts are: {String.Join(", ", _fonts.Keys.Select(k => k.Item1 + " size " + k.Item2))}");
        }

        return _fonts[tuple];
    }
}
