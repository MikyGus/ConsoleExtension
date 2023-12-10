using ConsoleExtension.Library.Menu.Abstract;
using ConsoleExtension.Library.Menu.Fixed;
using ConsoleExtension.Library.Menu.Models;
using ConsoleExtension.Library.Menu.PerformAction;

namespace ConsoleExtension.Library.Menu;
public class MenuContainerBuilder : IMenuBuilder
{
    private readonly IMenuContainer _container;
    private bool _haveSetActionToPerform = false;

    public MenuContainerBuilder()
    {
        _container = new MenuContainer();
    }

    public IMenuBuilder AddChild(IMenuContainerChild item)
    {
        item.Parent = _container;
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

    public IMenuContainer Build()
    {
        if (_container.IsSelectionSuppressed == false && _haveSetActionToPerform == false)
            _container.SetActionOnKeyPressed(ActionToPerform.MoveSelection);
        return _container;
    }

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
    public IMenuBuilder SuppressSelection(bool suppressSelection)
    {
        _container.IsSelectionSuppressed = suppressSelection;
        return this;
    }

    public IMenuBuilder SetActionOnKeyPressed(Func<ConsoleKeyInfo, IMenuContainer, bool> actionOnKeyPressed)
    {
        _container.SetActionOnKeyPressed(actionOnKeyPressed);
        _haveSetActionToPerform = true;
        return this;
    }

}
