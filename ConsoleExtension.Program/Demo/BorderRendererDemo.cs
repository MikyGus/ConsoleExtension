using ConsoleExtension.Library.Models;
using ConsoleExtension.Library.Renderers;

namespace ConsoleExtension.Program.Demo;
internal class BorderRendererDemo
{
    public static void Run()
    {
        // Content inside the rendered border is NOT overwritten
        Vector2 startPosition = new Vector2(1, 1);
        Vector2 gridSize = new Vector2(20, 5);
        BorderRenderer.BorderSolid(startPosition, gridSize, ConsoleColor.Blue);

        // Content inside the rendered border is NOT overwritten
        Vector2 startPositionCorner = new Vector2(1, 6);
        Vector2 gridSizeCorner = new Vector2(10, 5);
        int cornerSize = 2;
        BorderRenderer.BorderCorner(startPositionCorner, gridSizeCorner, ConsoleColor.Red,cornerSize);
    }
}
