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
    void MarkByValue<T>(T value);
    /// <summary>
    /// Sets the action to occur when a key is pressed. 
    /// </summary>
    /// <param name="actionOnKeyPressed"></param>
    void SetActionOnKeyPressed(Func<ConsoleKeyInfo, IMenuContainer, bool> actionOnKeyPressed);
    IMenuContainerChild GetSelectedChild();
    /// <summary>
    /// Move the current selection one (1) increment.
    /// </summary>
    /// <param name="fallthrough">Specifies if the increment should continue to next parent.child</param>
    void IncrementMoveSelection(bool fallthrough);
    /// <summary>
    /// Move the current selection one (1) decrement.
    /// </summary>
    /// <param name="fallthrough">Specifies if the decrement should continue to next parent.child</param>
    void DecrementMoveSelection(bool fallthrough);
    void AddChild(IMenuContainerChild child);
}
