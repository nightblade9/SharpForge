# SharpForge

A multi-platform 2D game engine for desktop games. Free and open source (FOSS). Built in C# and .NET 8, for C# developers, on the shoulders of giants.

# Contributing

If you find something you want to change, feel free to open a PR. If it's a better change, please open an issue first to discuss it, so we can figure out the best solutiion together!

The following projects make up SharpForge, each with its own unique (hopefully singular) responsibilities. Please keep this in mind when you make your changes, making them to the correct layer.

- **Editor:** The visual editor. It's a SharpForge game, which outputs the set of game data and assets required to play the game.
- **Framework:** The core "game engine" that runs the game, based on data. Handles functionality like AABB collision detection, UI handling, screen scaling, etc. Should contain the majority of logic required, although may call into the backend project for simple rendering.
- **Core:** An abstraction layer between the framework/editor and whatever "back-end" implementation we use.
- **Backend.Nez:** An implementation of the core, in Nez. Should contain minimal logic, to facilitate swapping out if necessary in the future. Wraps around and hopefully isolates the back-end code to a single (swappable) location.

In particular, **the framework project should contain the majority of code,** including rendering order-of-operations, AABB, etc. As much as possible, favour inserting code there, instead of in the backend library. (Should we swap the backend library out, it shouldn't require much in terms of complex code to re-implement.)

# Credits

Special thanks to these tools and frameworks, without which, SharpForge would remain a dream forever. In alphabetical order:

- [Godot](https://github.com/godot-engine/godot): For inspiring me on what a great game-creating tool can look like.
- [MonoGame](https://github.com/MonoGame/MonoGame): The mountain which supports the entire C# gamedev experience. 
- [Nez](https://github.com/prime31/Nez): A fantastic layer on top of MonoGame that provides additional functionality out-of-the-box 