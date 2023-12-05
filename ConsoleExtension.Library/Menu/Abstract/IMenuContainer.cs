using ConsoleExtension.Library.Menu.Fixed;
using ConsoleExtension.Library.Models;

namespace ConsoleExtension.Library.Menu.Abstract;
public interface IMenuContainer : IMenuContainerChild
{
    IEnumerable<IMenuContainerChild> Children { get; }
    ContainerChildOrientation OrientationOfChildren { get; set; }
    /// <summary>
    /// Minimum offset between children.
    /// </summary>
    Vector2 OffsetBetweenChildren { get; }
    int SelectedIndex { get; set; }
    void SelectByValue<T>(T value);
    void SetActionOnKeyPressed(Func<ConsoleKeyInfo, IMenuContainer, bool> actionOnKeyPressed);
    IMenuContainerChild GetSelectedChild();
    void AddChild(IMenuContainerChild child);
}
