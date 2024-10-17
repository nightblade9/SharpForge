using System;
using System.Collections.Generic;
using System.Linq;
using Nez.BitmapFonts;

namespace SharpForge.Backend.MonoGameAndNez.Text;

class FontLoader
{
    public static readonly FontLoader Instance = new FontLoader();
    private readonly Dictionary<(string, int), BitmapFont> _fonts = new();

    private readonly List<(string, int)> _supportedFonts = new()
    {
        ("Arial", 36),
    };

    private FontLoader()
    {
    }

    public void LoadAllFonts()
    {
        _fonts.Clear();

        foreach (var fontData in _supportedFonts)
        {
            var bitmapFont = Nez.Core.Content.LoadBitmapFont("Content/Fonts/Arial-36.fnt", true);
            _fonts[fontData] = bitmapFont;
        }
    }

    public BitmapFont GetFont(string fontName, int fontSize)
    {
        var tuple = (fontName, fontSize);
        BitmapFont font = null;
        
        bool wasKeyPresent = _fonts.TryGetValue(tuple, out font);
        if (!wasKeyPresent)
        {
            var listOfSupportedFonts = String.Join(", ", _fonts.Keys.Select(k => $"{k.Item1} {k.Item2}pt"));
            throw new InvalidOperationException($"SharpForge doesn't support {fontName} at size {fontSize}. Valid fonts are: {listOfSupportedFonts}");
        }

        return font;
    }
}
