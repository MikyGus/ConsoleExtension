using ConsoleExtension.Library.Models;

namespace ConsoleExtension.Library.Renderers;
public static class BorderRenderer
{
    /// <summary>
    /// Draws the corners of a border at the size of 'gridsize' starting at position 'startPosition'. 
    /// 'cornersize' indicates how many characters should be used to draw lines from the corners.
    /// Uses ╔ ═ ╗ ╚ ╝ ║ to build a border.
    /// Exception is thrown if gridSize (X or Y) is less than 2.
    /// Exception is thrown if startPosition (X or Y) is less than 0.
    /// Exception is thrown if cornerSize is less than 0.
    /// 
    /// </summary>
    /// <param name="startPosition"></param>
    /// <param name="gridSize"></param>
    /// <param name="borderColor"></param>
    /// <param name="cornerSize"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void BorderCorner(Vector2 startPosition, Vector2 gridSize, ConsoleColor borderColor, int cornerSize)
    {
        if (startPosition.X < 0 || startPosition.Y < 0)
            throw new ArgumentOutOfRangeException(nameof(startPosition));
        if (gridSize.X < 2 || gridSize.Y < 2)
            throw new ArgumentOutOfRangeException(nameof(gridSize));
        if (cornerSize < 0)
            throw new ArgumentOutOfRangeException(nameof(cornerSize));

        var leftTop = "╔";
        var rightTop = "╗";
        var horizontalBlankSize = gridSize.X - 2 - 2 * cornerSize;
        string rowMiddle = horizontalBlankSize > 0
            ? new string('═', cornerSize) + new string(' ', gridSize.X - 2 - 2 * cornerSize) + new string('═', cornerSize)
            : new string('═', gridSize.X - 2);
        var leftBottom = "╚";
        var rightBottom = "╝";
        var leftRightEdge = "║";

        var topRow = leftTop + rowMiddle + rightTop;
        var bottomRow = leftBottom + rowMiddle + rightBottom;

        var previousColor = Console.ForegroundColor;
        Console.ForegroundColor = borderColor;

        for (var y = startPosition.Y; y < startPosition.Y + gridSize.Y; y++)
        {
            if (y == startPosition.Y)
            {
                Console.SetCursorPosition(startPosition.X, y);
                Console.WriteLine(topRow);
            }
            else if (y == startPosition.Y + gridSize.Y - 1)
            {
                Console.SetCursorPosition(startPosition.X, y);
                Console.Write(bottomRow);
            }
            else if (y < startPosition.Y + cornerSize || y > startPosition.Y + gridSize.Y - 1 - cornerSize)
            {
                Console.SetCursorPosition(startPosition.X, y);
                Console.Write(leftRightEdge);
                Console.SetCursorPosition(startPosition.X + gridSize.X - 1, y);
                Console.Write(leftRightEdge);
            }
        }
        Console.ForegroundColor = previousColor;
    }

    /// <summary>
    /// Draws a solid border at the size of 'gridSize' starting at 'startPosition' with the color of 'borderColor'.
    /// Uses ╔ ═ ╗ ╚ ╝ ║ to build a border.
    /// Exception is thrown if gridSize (X or Y) is less than 3.
    /// Exception is thrown if startPosition (X or Y) is less than 0.
    /// </summary>
    /// <param name="startPosition"></param>
    /// <param name="gridSize"></param>
    /// <param name="borderColor"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void BorderSolid(Vector2 startPosition, Vector2 gridSize, ConsoleColor borderColor)
    {
        if (startPosition.X < 0 || startPosition.Y < 0)
            throw new ArgumentOutOfRangeException(nameof(startPosition));
        if (gridSize.X < 3 || gridSize.Y < 3)
            throw new ArgumentOutOfRangeException(nameof(gridSize));

        var leftTop = "╔";
        var rightTop = "╗";
        var rowMiddle = new string('═', gridSize.X - 2);
        var leftBottom = "╚";
        var rightBottom = "╝";
        var leftRightEdge = "║";

        var topRow = leftTop + rowMiddle + rightTop;
        var bottomRow = leftBottom + rowMiddle + rightBottom;

        var previousColor = Console.ForegroundColor;
        Console.ForegroundColor = borderColor;

        for (var y = startPosition.Y; y < startPosition.Y + gridSize.Y; y++)
        {
            if (y == startPosition.Y)
            {
                Console.SetCursorPosition(startPosition.X, y);
                Console.Write(topRow);
            }
            else if (y == startPosition.Y + gridSize.Y - 1)
            {
                Console.SetCursorPosition(startPosition.X, y);
                Console.Write(bottomRow);
            }
            else
            {
                Console.SetCursorPosition(startPosition.X, y);
                Console.Write(leftRightEdge);
                Console.SetCursorPosition(startPosition.X + gridSize.X - 1, y);
                Console.Write(leftRightEdge);
            }
        }
        Console.ForegroundColor = previousColor;
    }
}
