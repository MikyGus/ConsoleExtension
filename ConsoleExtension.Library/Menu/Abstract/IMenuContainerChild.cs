using ConsoleExtension.Library.Models;

namespace ConsoleExtension.Library.Menu.Abstract;
public interface IMenuContainerChild
{
    string Title { get; set; }
    Vector2 Position { get; set; }
    bool IsSelected { get; set; }
    void Render();
    void RenderSelection();
    Vector2 AreaNeeded();
}
