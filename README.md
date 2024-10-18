# SharpForge

:warning: **SharpForge is an architectural proof-of-concept, and is no longer under development.** :warning:

The vision: a multi-platform 2D game engine for desktop games. Free and open source (FOSS). Built in C# and .NET 8, for C# developers, on the shoulders of giants. Create a great game editor and game engine, that's accessible to C# developers end-to-end -- it's free and open-source, and you can fork and edit every line of code yourself.  And it should be intuitive, run fast, be well-designed and architected, and work across desktop (Windows, Linux, and Mac) for 2D games.

Turns out that vision is here. Check out the amazing [FlatRedBall](https://flatredball.com) engine. It delivers on this promise quite well.

With one caveat: integration. With FRB, you separately run an IDE (Visual Studio), tile editor (Tiled), and game maker (FRB Editor). The experience is not integrated as seamlessly as something like Godot.

Why is SharpForge nothing more than a concept? Because **FRB is as good as it gets, leveraging existing FOSS.** For a really slick integrated user experience, like [https://godotengine.org], you need to **build everything yourself.** Build a small IDE, with a small level-editor, animation editor, everything. And that's just not something one person can do; so I retired SharpForge.

If a team can rally around this vision and commit to it, maybe this can be a viable option in the future.

# Contributing

If you find something you want to change, feel free to open a PR. If it's a better change, please open an issue first to discuss it, so we can figure out the best solutiion together!

The following projects make up SharpForge, each with its own unique (hopefully singular) responsibilities. Please keep this in mind when you make your changes, making them to the correct layer.

- **Core:** Pure data that represents our game, e.g. `Node` and `Sprite` classes with `ImageFile` and `Rotation` properties.
- **Framework:** The core "game engine" that runs the game, based on data. Handles functionality like AABB collision detection, UI handling, screen scaling, etc. Provides interfaces, and relies on those for functionality.
- **Backend.Nez:** An implementation of the interfaces for Framework. This could be as low-level as rendering a sprite on screen, or as high-level as collision detection and resolution.
- **Editor:** The visual editor, which outputs the set of game data and assets required to play the game.

In particular, **the framework project should contain the majority of code,** including rendering order-of-operations, AABB, etc. As much as possible, favour inserting code there, instead of in the backend library. (Should we need to swap the backend library out, it shouldn't require much in terms of complex code to re-implement.)

It's not layers; rather, the core game engine is the `Framework` project, which exposes interfaces. It's up to the backend to implement them. The editor simply pulls everything together.

# Credits

Special thanks to these tools and frameworks, without which, SharpForge would remain a dream forever. In alphabetical order:

- [Godot](https://github.com/godot-engine/godot): For inspiring me on what a great game-creating tool can look like.
- [MonoGame](https://github.com/MonoGame/MonoGame): The mountain which supports the entire C# gamedev experience. 
- [Nez](https://github.com/prime31/Nez): A fantastic layer on top of MonoGame that provides additional functionality out-of-the-box 