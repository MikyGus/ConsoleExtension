using ConsoleExtension.Library.Menu.Fixed;

namespace ConsoleExtension.Library.Menu.Abstract;

public interface IMenuBuilder
{
    /// <summary>
    /// Specifies the direction the children is to be displayed.
    /// </summary>
    /// <param name="orientation"></param>
    /// <returns></returns>
    IMenuBuilder Orientation(ContainerChildOrientation orientation);
    IMenuBuilder Title(string title);
    IMenuBuilder AddChild(IMenuContainerChild item);
    /// <summary>
    /// Selects child of container at specified index. 
    /// May only be specified AFTER the children have been added.
    /// The index-value will be altered to upper or lower bound if specified index is out of bounds.
    /// </summary>
    /// <param name="index">Child at this index to be selected</param>
    /// <returns>IMenuBuilder</returns>
    IMenuBuilder SelectByIndex(int index);
    /// <summary>
    /// Selects child of container by the containers value. 
    /// Only selects IMenuChildItems! 
    /// May only be specified AFTER the children have been added.
    /// The Equals() method is used for equality.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when specified value is not found among the containers children.</exception>
    /// <typeparam name="T">MenuChildItems type of value</typeparam>
    /// <param name="value">Value of MenuChildItem to select</param>
    /// <returns>IMenuBuilder</returns>
    IMenuBuilder SelectByValue<T>(T value);
    IMenuBuilder MarkByValue<T>(T value);
    IMenuBuilder SetActionOnKeyPressed(Func<ConsoleKeyInfo, IMenuContainer, bool> actionOnKeyPressed);
    IMenuContainer Build();
}

