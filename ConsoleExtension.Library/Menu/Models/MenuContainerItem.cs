using ConsoleExtension.Library .Menu.Abstract;
using ConsoleExtension.Library.Models;
using ConsoleExtension.Library.Renderers;

namespace ConsoleExtension.Library.Menu.Models;
public class MenuContainerItem<T> : IMenuContainerItem<T>
{
    private Func<ConsoleKeyInfo, IMenuContainerItem<T>, bool> _actionOnKeyPressed;
    public bool IsMarked { get; set; }
    public T Value { get; set; }
    public string Title { get; set; }
    public Vector2 Position { get; set; }
    public bool IsSelected { get; set; }

    public MenuContainerItem(T value)
    {
        Value = value;
        Title = value.ToString();
    }

    public Vector2 AreaNeeded() => new(Title.Length + 2, 1);
    public void Render() 
        => ConsoleWriter.WriteAtPosition(Position, Title, ConsoleColor.Black, IsMarked ? ConsoleColor.DarkGray : ConsoleColor.Gray, ConsoleColor.Blue, IsSelected);
    public void RenderSelection(bool showSelection) 
        => ConsoleWriter.WriteAtPosition(Position, Title, ConsoleColor.Black, IsMarked ? ConsoleColor.DarkGray : ConsoleColor.Gray, ConsoleColor.Blue, showSelection);

    public void SetActionOnKeyPressed(Func<ConsoleKeyInfo, IMenuContainerItem<T>,bool> actionOnKeyPressed) => _actionOnKeyPressed = actionOnKeyPressed;
    public void PerformAction(ConsoleKeyInfo key) => _actionOnKeyPressed?.Invoke(key,this);
}