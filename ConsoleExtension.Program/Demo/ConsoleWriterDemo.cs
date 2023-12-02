using ConsoleExtension.Library.Models;
using ConsoleExtension.Library.Renderers;

namespace ConsoleExtension.Program.Demo;
internal class ConsoleWriterDemo
{
    public static void Run()
    {
        // Writes 'Hello World to the Console a given position.
        // The background and foreground color is reset to the original colors.
        ConsoleWriter.WriteAtPosition(new Vector2(2, 2), "Hello World", ConsoleColor.Blue, ConsoleColor.Yellow);
    }
}
