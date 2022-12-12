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

    // The maze grid, where 0 means no path, any other (1-15) a connection
    private int[,] maze;

    // Sizes can't be negative and never exceed 250 in this project,
    // bytes would fit well, but integers are easier on coding further.
    private int width;
    private int height;

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
        int halfX = sizeX >> 1;  // Half the size, for starting positions of
        int halfY = sizeY >> 1;  // the four starting cells in each quadrant
        maze = new int[sizeX, sizeY];
        ClearMaze();

        // Call the maze generation algorithm on each starting cell in their respective quadrant
        GenerateMaze(Random.Range(0, halfX),     Random.Range(0, halfY));       // Up left
        GenerateMaze(Random.Range(halfX, width), Random.Range(0, halfY));       // Up right
        GenerateMaze(Random.Range(0, halfX),     Random.Range(halfY, height));  // Down left
        GenerateMaze(Random.Range(halfX, width), Random.Range(halfY, height));  // Down right
    }

    /// <summary>
    /// The actual implementation of the generating algorithm.
    /// </summary>
    public void GenerateMaze(int currentX, int currentY)
    {
        // TODO: Implement the actual algorithm.
    }

    /// <summary>
    /// Set the starting cells to all walls / no paths (0)
    /// </summary>
    private void ClearMaze()
    {
        Array.Clear(maze, 0, (width * height) - 1);
    }

    // Getter and Setter methods, just in case it's needed later.

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
}
