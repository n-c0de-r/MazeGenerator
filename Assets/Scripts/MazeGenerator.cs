using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Generates a perfect maze using Depths First Search - also called Recursive Backtracker.
/// This specific implementation uses four starting cells in parallel for faster creation.
/// As inspired by the visual demo of Jamis Buck.
/// </summary>
public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    TileMapper tileMapper;

    [SerializeField]
    CameraController cameraController;

    // The maze grid, where 0 means no path, any other (1-15) a connection.
    private int[,] maze;

    // Structs holding information on directions.
    private Direction[] directions;

    // The stack of cells for iterative backtracker.
    private Stack<Cell> cells;

    // Stack for each of the parallelly running backtrackers
    private Stack<Cell>[] stacks;

    // Sizes can't be negative and never exceed 250 in this project,
    // bytes would fit well, but integers are easier on coding further.
    private int width, height;

    /// <summary>
    /// Sets up direction values only when the Object gets activated.
    /// </summary>
    private void Start()
    {
        directions = new Direction[] {
            new Direction(1, 0, -1),    // North
            new Direction(2, 1, 0),     // East
            new Direction(4, 0, 1),     // South
            new Direction(8, -1, 0),    // West
        };

        cells = new Stack<Cell>();

        stacks = new Stack<Cell>[4] {
            new Stack<Cell>(),
            new Stack<Cell>(),
            new Stack<Cell>(),
            new Stack<Cell>()
        };

        GenerateMaze();
    }


    /// <summary>
    /// Generates a new maze.
    /// </summary>
    public void GenerateMaze()
    {
        ResetMaze();
        ClearMaze();
        InitializeStack();

        // Call the iterative maze generation algorithm.
        // Runs in background as a coroutine, to not slowdown the game.
        StartCoroutine(IterativeBacktracker());

        // Call the maze generation algorithm on each starting cell in their respective quadrant
        /*ParallelBacktracker(stacks[i]); <- i: 1-4; TODO: figure out how to do it parallelly*/

        // RecursiveBacktracker(x,y); WARNING: Causes Stack Overflow, do NOT use. Juzst proof of concept.

        // TODO: Think about adding more algorithms to pick here, as this was rather easy.

        tileMapper.PaintMap(maze, width, height);
        cameraController.CalculateCameraSize();
    }

    // Getter and Setter methods.

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
        height = newHeight;
    }

    /// <summary>
    /// Quits the application.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    // Private internal calculating methods.

    /// <summary>
    /// Resets the maze holding array.
    /// </summary>
    private void ResetMaze()
    {
        if (maze != null && (maze.GetLength(0) == width && maze.GetLength(1) == height) ) return;

        maze = new int[width, height];
    }

    /// <summary>
    /// Set the starting cells to all walls / no paths (0)
    /// </summary>
    private void ClearMaze()
    {
        Array.Clear(maze, 0, (width * height));
    }

    /// <summary>
    /// Clears all stacks and initializes first cell.
    /// </summary>
    private void InitializeStack()
    {
        cells.Clear();
        cells.Push(new Cell(Random.Range(0, width >> 1), Random.Range(0, height >> 1)));

        int halfX = width >> 1;    // Half the size, for starting positions of
        int halfY = height >> 1;    // the four starting cells in each quadrant

        // Starting Cells for each quadrant for the parallelly running backtrackers
        Cell[] starters = new Cell[4] {
            new Cell(Random.Range(0, halfX),    Random.Range(0, halfY)),        // Up left 
            new Cell(Random.Range(halfX, width),Random.Range(0, halfY)),        // Up right
            new Cell(Random.Range(0, halfX),    Random.Range(halfY, height)),   // Down left
            new Cell(Random.Range(halfX, width),Random.Range(halfY, height)),   // Down right
        };

        for (int i = 0; i < stacks.Length; i++)
        {
            stacks[i].Clear();
            stacks[i].Push(starters[i]);
        }
    }

    /// <summary>
    /// The actual implementation of the generating algorithm.
    /// Using the Iterative Backtracking approach.
    /// </summary>
    /// <returns>An enumerator.</returns>
    private IEnumerator IterativeBacktracker()
    {
        while (cells.Count > 0) {
            Cell current = cells.Pop();

            ShuffleDirections(directions);

            foreach (Direction dir in directions)
            {
                int newX = current.x + dir.x;
                int newY = current.y + dir.y;

                if (IsValidMove(newX, newY))
                {
                    maze[current.x, current.y] |= dir.value;
                    maze[newX, newY] |= dir.opposite;

                    cells.Push(new Cell(newX, newY));
                }
            }
        }
        yield return null;
    }

    /// <summary>
    /// The actual implementation of the generating algorithm.
    /// Using the Recursive Backtracking algorithm running parallely.
    /// Sadly still not working, can't figure out multithreading for this...
    /// </summary>
    /// <param name="stack">The stack used to store Cells for this iteration.</param>
    private void ParallelBacktracker(Stack<Cell> stack)
    {
        while (stack.Count > 0)
        {
            Cell current = stack.Pop();

            ShuffleDirections(directions);

            foreach (Direction dir in directions)
            {
                int newX = current.x + dir.x;
                int newY = current.y + dir.y;

                if (IsValidMove(newX, newY))
                {
                    maze[current.x, current.y] |= dir.value;
                    maze[newX, newY] |= dir.opposite;

                    stack.Push(new Cell(newX, newY));
                }
            }
        }
    }

    /// <summary>
    /// The actual implementation of the generating algorithm.
    /// Using the Recursive Backtracking algorithm. Causes Stack Overflow!!!
    /// </summary>
    /// <param name="currentX">The current cell to check at position X.</param>
    /// <param name="currentY">The current cell to check at position Y.</param>
    private void RecursiveBacktracker(int currentX, int currentY)
    {
        ShuffleDirections(directions);

        foreach (Direction dir in directions)
        {
            int newX = currentX + dir.x;
            int newY = currentY + dir.y;

            if (IsValidMove(newX, newY))
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
        return x >= 0 && x < width && y >= 0 && y < height && maze[x, y] == 0;
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
