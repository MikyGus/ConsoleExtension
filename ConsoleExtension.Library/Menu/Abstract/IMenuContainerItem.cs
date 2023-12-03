namespace ConsoleExtension.Library.Menu.Abstract;
internal interface IMenuContainerItem<T> : IMenuContainerChild
{
    /// <summary>
    /// Indicates if this is set from the settings-configuration
    /// </summary>
    bool IsMarked { get; set; }
    T Value { get; set; }
}