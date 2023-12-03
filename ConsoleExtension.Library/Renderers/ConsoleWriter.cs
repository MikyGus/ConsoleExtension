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

    public static void WriteAtPosition(Vector2 position, string text, ConsoleColor fgColor, ConsoleColor bgColor, ConsoleColor markedColor, bool isSelected)
    {
        var tempBackgroundColor = Console.BackgroundColor;
        var tempFontColor = Console.ForegroundColor;

        if (isSelected)
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = markedColor;
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write("[");
            Console.ForegroundColor = fgColor;
            Console.Write(text);
            Console.ForegroundColor = markedColor;
            Console.Write("]");
        }
        else
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgColor;
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write($" {text} ");
        }

        Console.BackgroundColor = tempBackgroundColor;
        Console.ForegroundColor = tempFontColor;
    }
}
