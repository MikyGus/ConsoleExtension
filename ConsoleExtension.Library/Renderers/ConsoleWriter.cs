using ConsoleExtension.Library.Models;

namespace ConsoleExtension.Library.Renderers;
public static class ConsoleWriter
{
    public static void WriteAtPosition(Vector2 position, string text, ConsoleColor fgColor, ConsoleColor bgColor)
    {
        var tempBackgroundColor = Console.BackgroundColor;
        var tempFontColor = Console.ForegroundColor;
        Console.BackgroundColor = bgColor;
        Console.ForegroundColor = fgColor;

        Console.SetCursorPosition(position.X, position.Y);
        Console.Write(text);

        Console.BackgroundColor = tempBackgroundColor;
        Console.ForegroundColor = tempFontColor;
    }
}
