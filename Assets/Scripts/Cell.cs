using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents Cells in a maze
/// </summary>
public struct Cell
{
    public int x;
    public int y;

    /// <summary>
    /// Consturctor of a Cell struct.
    /// </summary>
    /// <param name="newX">New X coordinate to set. Represents the cell to visit next.</param>
    /// <param name="newY">New Y coordinate to set. Represents the cell to visit next.</param>
    public Cell(int newX, int newY)
    {
        this.x = newX;
        this.y = newY;
    }
}
