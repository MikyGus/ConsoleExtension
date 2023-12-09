using ConsoleExtension.Library .Menu.Abstract;
using ConsoleExtension.Library.Models;
using ConsoleExtension.Library.Renderers;

namespace ConsoleExtension.Library.Menu.Models;
public class MenuContainerItem<T> : IMenuContainerItem<T>
{
    private Func<ConsoleKeyInfo, IMenuContainerItem<T>, bool> _actionOnKeyPressed;
    public IMenuContainer Parent { get; set; }
    public bool IsMarked { get; set; }
    public T Value { get; set; }
    public string Title { get; set; }
    public Vector2 Position { get; set; }
    public bool IsSelected { get; set; }
    public bool IsSelectionSuppressed { get; set; }

    public MenuContainerItem(T value)
    {
        Value = value;
        Title = value.ToString();
    }

    public Vector2 AreaNeeded() => new(Title.Length + 2, 1);
    public void Render()
    {
        var bgColor = IsMarked ? ConsoleColor.DarkGray : ConsoleColor.Gray;
        ConsoleWriter.WriteAtPosition(Position, Title, ConsoleColor.Black, bgColor, ConsoleColor.Blue, false);
    }

    public void RenderSelection(bool showSelection)
    {
        var showThisSelection = IsSelectionSuppressed ? false : showSelection;
        var bgColor = IsMarked ? ConsoleColor.DarkGray : ConsoleColor.Gray;
        ConsoleWriter.WriteAtPosition(Position, Title, ConsoleColor.Black, bgColor, ConsoleColor.Blue, showThisSelection);
    }

    public void SetActionOnKeyPressed(Func<ConsoleKeyInfo, IMenuContainerItem<T>,bool> actionOnKeyPressed) => _actionOnKeyPressed = actionOnKeyPressed;
    public void PerformAction(ConsoleKeyInfo key) => _actionOnKeyPressed?.Invoke(key,this);
}