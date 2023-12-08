using ConsoleExtension.Library.Models;

namespace ConsoleExtension.Library.Menu.Abstract;
public interface IMenuContainerChild
{
    string Title { get; set; }
    Vector2 Position { get; set; }
    bool IsSelected { get; set; }
    bool IsSelectionSuppressed { get; set; }
    void Render();
    void RenderSelection(bool showSelection);
    Vector2 AreaNeeded();
    void PerformAction(ConsoleKeyInfo key);
}
