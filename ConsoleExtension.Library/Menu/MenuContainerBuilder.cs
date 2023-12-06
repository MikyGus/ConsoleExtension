using ConsoleExtension.Library.Menu.Abstract;
using ConsoleExtension.Library.Menu.Fixed;
using ConsoleExtension.Library.Menu.Models;

namespace ConsoleExtension.Library.Menu;
public class MenuContainerBuilder : IMenuBuilder
{
    private readonly IMenuContainer _container;

    public MenuContainerBuilder()
    {
        _container = new MenuContainer();
    }

    public IMenuBuilder AddChild(IMenuContainerChild item)
    {
        _container.AddChild(item);
        return this;
    }
    public IMenuBuilder Orientation(ContainerChildOrientation orientation)
    {
        _container.OrientationOfChildren = orientation;
        return this;
    }
    public IMenuBuilder Title(string title)
    {
        _container.Title = title;
        return this;
    }

    public IMenuContainer Build() => _container;
    public IMenuBuilder SelectByIndex(int index)
    {
        _container.SelectedIndex = index;
        return this;
    }
    public IMenuBuilder SelectByValue<T>(T value)
    {
        _container.SelectByValue(value);
        return this;
    }

    public IMenuBuilder MarkByValue<T>(T value)
    {
        _container.MarkByValue(value);
        return this;
    }

    public IMenuBuilder SetActionOnKeyPressed(Func<ConsoleKeyInfo, IMenuContainer, bool> actionOnKeyPressed)
    {
        _container.SetActionOnKeyPressed(actionOnKeyPressed);
        return this;
    }
}
