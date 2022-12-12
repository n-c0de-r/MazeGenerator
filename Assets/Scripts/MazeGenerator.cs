using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Generates a perfect maze using Depths First Search - also called Recursive Backtracker.
/// This specific implementation uses four starting cells in parallel for faster creation.
/// As inspired by the visual demo of Jamis Buck.
/// </summary>
public class MazeGenerator : MonoBehaviour
{
    // Declaring bounding sizes as specified in the task description. 
    private const int MAX_SIZE = 250;
    private const int MIN_SIZE = 10;

    // The maze grid, where 0 means no path, any other (1-15) a connection.
    private int[,] maze;

    // Structs holding information on directions
    private Direction[] directions;

    // Sizes can't be negative and never exceed 250 in this project,
    // bytes would fit well, but integers are easier on coding further.
    private int width, height;

    /// <summary>
    /// Constructor for a 2 dimensional perfect maze.
    /// </summary>
    /// <param name="sizeX">The given width of the maze.</param>
    /// <param name="sizeY">The given height of the maze.</param>
    public MazeGenerator(byte sizeX, byte sizeY)
    {
        // Clamp, just in case a value from a slider is passed in wrongly.
        width   = Mathf.Clamp(sizeX, MIN_SIZE, MAX_SIZE);
        height  = Mathf.Clamp(sizeY, MIN_SIZE, MAX_SIZE);
        
        maze = new int[sizeX, sizeY];

        directions = new Direction[] {
            new Direction(1, 0, -1),    // North
            new Direction(2, 1, 0),     // East
            new Direction(4, 0, 1),     // South
            new Direction(8, -1, 0),    // West
        };
    }

    /// <summary>
    /// Generates a new maze.
    /// </summary>
    public void GenerateMaze()
    {
        ClearMaze();

        int halfX = width  >> 1;    // Half the size, for starting positions of
        int halfY = height >> 1;    // the four starting cells in each quadrant

        // Call the maze generation algorithm on each starting cell in their respective quadrant
        RecursiveBacktracker(Random.Range(0, halfX),       Random.Range(0, halfY));       // Up left
        RecursiveBacktracker(Random.Range(halfX, width),   Random.Range(0, halfY));       // Up right
        RecursiveBacktracker(Random.Range(0, halfX),       Random.Range(halfY, height));  // Down left
        RecursiveBacktracker(Random.Range(halfX, width),   Random.Range(halfY, height));  // Down right

        // TODO: Think about adding more algorithms to pick here, as this was rather easy.
    }

    // Getter and Setter methods, just in case it's needed later.

    /// <summary>
    /// Accessor method for the maze itself.
    /// </summary>
    /// <returns>A 2 dimensional array of values representing a maze structure.</returns>
    public int[,] GetMaze()
    {
        return maze;
    }

    /// <summary>
    /// Accessor method for the maze's width.
    /// </summary>
    /// <returns>The integer value of the maze's width.</returns>
    public int GetWidth()
    {
        return width;
    }

    /// <summary>
    /// Mutator method for the maze's width.
    /// </summary>
    /// <param name="newWidth">The new width to set the maze to.</param>
    public void SetWidth(int newWidth)
    {
        width = newWidth;
    }

    /// <summary>
    /// Accessor method for the maze's height.
    /// </summary>
    /// <returns>The integer value of the maze's height.</returns>
    public int GetHeight()
    {
        return height;
    }

    /// <summary>
    /// Mutator method for the maze's height.
    /// </summary>
    /// <param name="newHeight">The new height to set the maze to.</param>
    public void SetHeight(int newHeight)
    {
        width = newHeight;
    }

    // Private internal calculating methods.

    /// <summary>
    /// Set the starting cells to all walls / no paths (0)
    /// </summary>
    private void ClearMaze()
    {
        Array.Clear(maze, 0, (width * height) - 1);
    }

    /// <summary>
    /// The actual implementation of the generating algorithm.
    /// Using the Recursive Backtracking algorithm.
    /// </summary>
    /// <param name="currentX"></param>
    /// <param name="currentY"></param>
    private void RecursiveBacktracker(int currentX, int currentY)
    {
        ShuffleDirections(directions);

        foreach (Direction dir in directions)
        {
            int newX = currentX + dir.x;
            int newY = currentY + dir.y;

            if(IsValidMove(newX, newY))
            {
                maze[currentX, currentY] |= dir.value;
                maze[newX, newY] |= dir.opposite;

                RecursiveBacktracker(newX, newY);
            }
        }
    }

    /// <summary>
    /// Check if a move to the given coordinates is valid (within the bounds of the maze and not already visited)
    /// </summary>
    /// <param name="x">The X coordinate of the cell to check.</param>
    /// <param name="y">The Y coordinate of the cell to check.</param>
    /// <returns>True or false if the cell is valid or not.</returns>
    private bool IsValidMove(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height && maze[x, y] != 0;
    }

    /// <summary>
    /// Shuffles the array of directions.
    /// </summary>
    /// <param name="original">The array to shuffle.</param>
    private void ShuffleDirections(Direction[] original)
    {
        int n = original.Length;
        while (n > 1)
        {
            int k = Random.Range(0, n--);
            Direction temp = original[n];
            original[n] = original[k];
            original[k] = temp;
        }
    }
}
