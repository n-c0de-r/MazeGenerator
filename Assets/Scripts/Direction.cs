/// <summary>
/// Struct holding values relevant for carving directions in a maze.
/// </summary>
public struct Direction
{
    public int value;
    public int x;
    public int y;
    public int opposite;

    /// <summary>
    /// Consturctor of a Direction struct.
    /// </summary>
    /// <param name="newValue">New value to set. Bit representation of a direction.</param>
    /// <param name="newX">New X coordinate to set. Represents the direction to go to next.</param>
    /// <param name="newY">New Y coordinate to set. Represents the direction to go to next.</param>
    public Direction(int newValue, int newX, int newY)
    {
        this.value = newValue;
        this.x = newX;
        this.y = newY;
        this.opposite = (value << 2) % 15; // Automatically calculates the opposite.
    }
}
