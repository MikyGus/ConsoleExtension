namespace ConsoleExtension.Library.Menu.Abstract;
public interface IMenuContainerItem<T> : IMenuContainerChild
{
    /// <summary>
    /// Indicates if this is set from the settings-configuration
    /// </summary>
    bool IsMarked { get; set; }
    T Value { get; set; }
    void SetActionOnKeyPressed(Func<ConsoleKeyInfo, IMenuContainerItem<T>, bool> actionOnKeyPressed);
}