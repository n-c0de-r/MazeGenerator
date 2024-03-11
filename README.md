# Tauros Traps
After lots of back and forth this implements the recursive backtracking algorithm.
For efficiency reasons, it also should use multiple starting cells, and instead of classes uses structs.
Other than that it should hopefully rely on bitwise operations for calculating paths, as these are faster.

### Style
This project generates 2D pixelart mazes.

### Multimedia
Sources mainly from [OpenGameArt.org](https://opengameart.org/), editing via [Audacity](https://www.audacityteam.org/) for audio, and [Avidemux](https://avidemux.sourceforge.net/) & [Shotcut](https://shotcut.org/) for video, [LibreSprite](https://github.com/LibreSprite/LibreSprite) was used to edit & make some assets.

### Bonus (if I can make it; edit: that never happened)
Provides a little game experience within the labyrinth.
With collectible objects and some tiny additional challenge.

## Getting Started

These instructions will help you get the project up and running on your local machine for development and testing purposes.

### Prerequisites

- [Unity](https://unity.com/) (Editor Version 2021.2.12f1)
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)

### Installing

1. Clone or download the repository

```
git clone https://github.com/n-c0de-r/MazeGenerator.git
```

2. Open the project in Unity

3. Attach the `MazeGenerator` script to an empty GameObject in your Unity project

4. Call the `GenerateMaze()` function to generate the maze

```cs
MazeGenerator mazeGenerator = new MazeGenerator(sizeX, sizeY);
mazeGenerator.GenerateMaze();
```

5. Use the `maze` array to display the maze in the Unity scene

```cs
int[,] maze = mazeGenerator.maze;
```
## General Usage

1. Open the project in Unity

2. Run the project and follow the instructions given in the User Interface.

## Built With

- [Unity](https://unity.com/) - Game engine and development platform
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) - Programming language

## Contributing

If you want to contribute to the project, please follow these guidelines:

- Fork the repository
- Create a new branch (`git checkout -b my-feature`)
- Commit your changes (`git commit -am 'Add some feature'`)
- Push the branch (`git push origin my-feature`)
- Create a new Pull Request

## Authors

- [**n-c0de-r**](https://github.com/n-c0de-r)

## License

This project is not licensed under any particular license.

## Acknowledgments

- [Wikipedia](https://en.wikipedia.org/wiki/Maze_generation_algorithm) - Provided link in the assessment task
- [Think Labyrinth by Walter D. Pullen](http://www.astrolog.org/labyrnth/algrithm.htm)
- [Stack Overflow](https://stackoverflow.com/questions/38502/whats-a-good-algorithm-to-generate-a-maze) - For hinting at Jamis Buck
- [Jamis Buck - GitHub](https://github.com/jamis) - This guy is an institution on mazes
- [Jamis Buck - Maze Blog](https://weblog.jamisbuck.org/2011/2/7/maze-generation-algorithm-recap) - His visual representation helped me pick the right idea
- [Youtube - showing some algorithms](https://www.youtube.com/watch?v=sVcB8vUFlmU)
- [Youtube - some more algorithms vizualized](https://www.youtube.com/watch?v=U3meEXvYFsc)

- Everyone on [OpenGameArt.org](https://opengameart.org/)
- Intro sound [Warp 1](https://opengameart.org/content/warp-sound-1) by [Artur](https://opengameart.org/users/arthur)

- [Rock sprite](https://opengameart.org/content/some-tiles) by [vk](https://opengameart.org/users/vk)
- [Brick](https://opengameart.org/content/sandstone-brick-connecting-tileset-16x16), [Steampunk](https://opengameart.org/content/steampunk-brick-new-connecting-tileset-16x16) and [Jungle](https://opengameart.org/content/jungle-dirt-background-connecting-tileset-16x16) sprite by [KnoblePersona](https://opengameart.org/users/knoblepersona)
- [Sky Background](https://opengameart.org/content/sky-background) by [PauR](https://opengameart.org/users/paur)

- Main Font ["Pythia"](https://www.dafont.com/fr/pythia.font) by [Blambot](https://www.dafont.com/fr/blambot.d1)

- [Rock sound](https://opengameart.org/content/breaking-rock) & [boulder Drop](https://opengameart.org/content/moving-boulder) by [themightyglider](https://opengameart.org/users/themightyglider)
- [Ancient Temple](https://opengameart.org/content/ancient-temple) Music by [Alexandr Zhelanov](https://opengameart.org/content/little-epic-journey)

## Screenshots

![MazeGenerator_v0.1](/Screenshots/maze_show.gif)

A maze generated using the `MazeGenerator` script.
