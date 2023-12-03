using ConsoleExtension.Library.Extensions;
using ConsoleExtension.Library.Menu.Abstract;
using ConsoleExtension.Library.Menu.Fixed;
using ConsoleExtension.Library.Models;
using ConsoleExtension.Library.Renderers;

namespace ConsoleExtension.Library.Menu.Models;
public class MenuContainer : IMenuContainer
{
    private readonly List<IMenuContainerChild> _children;
    private int _selectedIndex = 0;

    public MenuContainer()
    {
        _children = new List<IMenuContainerChild>();
        IsSelected = false;
        Position = Vector2.ZERO;
    }
    public IEnumerable<IMenuContainerChild> Children => _children;

    public ContainerChildOrientation OrientationOfChildren { get; set; }
    public Vector2 OffsetBetweenChildren
        => OrientationOfChildren == ContainerChildOrientation.Vertical
            ? Vector2.DOWN * 2 : Vector2.RIGHT * 10;
    public string Title { get; set; }
    public Vector2 Position { get; set; }
    public bool IsSelected { get; set; }
    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            if (value > _children.Count - 1)
                _selectedIndex = _children.Count - 1;
            else if (value < 0)
                _selectedIndex = 0;
            else
                _selectedIndex = value;
        }
    }

    public void SelectByValue<T>(T value)
    {
        var index = 0;
        foreach (var child in Children)
        {
            if (child is IMenuContainerItem<T> c)
                if (c.Value.Equals(value))
                {
                    SelectedIndex = index;
                    return;
                }
            index++;
        }

        throw new ArgumentException($"No MenuContainerChild with {value} could be found!");
    }

    public void AddChild(IMenuContainerChild child) => _children.Add(child);
    public Vector2 AreaNeeded()
    {
        var areaNeeded = Vector2.ZERO;
        switch (OrientationOfChildren)
        {
            case ContainerChildOrientation.Vertical:
                if (_children.Any())
                    areaNeeded = _children.Select(c => c.AreaNeeded().Largest(OffsetBetweenChildren))
                        .Aggregate((a1, a2) => a1.MaxAdd_Vertical(a2));
                break;
            case ContainerChildOrientation.Horizontal:
                if (_children.Any())
                    areaNeeded = _children.Select(c => c.AreaNeeded().Largest(OffsetBetweenChildren))
                        .Aggregate((a1, a2) => a1.AddMax_Horizontal(a2));
                break;
        }
        areaNeeded = areaNeeded.MaxAdd_Vertical(new Vector2(Title.Length, 1));
        areaNeeded += new Vector2(2, 2); // Need space for 'Cursor-indicator'
        return areaNeeded;
    }
    public void Render()
    {
        var position = Position.Duplicate();
        if (IsSelected)
            BorderRenderer.BorderCorner(position, AreaNeeded(), ConsoleColor.Blue, 1);

        position += Vector2.RIGHT_DOWN;
        ConsoleWriter.WriteAtPosition(position, Title, ConsoleColor.Black, ConsoleColor.Gray);

        position += Vector2.DOWN;
        var index = 0;
        _children.ForEach(child =>
        {
            child.IsSelected = _selectedIndex == index;
            child.Position = position;
            child.Render();
            position = NextChildPosition(position, child.AreaNeeded());
            index++;
        });



    }
    public void RenderSelection()
    {

    }

    private Vector2 NextChildPosition(Vector2 position, Vector2 areaNeeded)
    {
        if (OrientationOfChildren == ContainerChildOrientation.Vertical)
            position.Y += areaNeeded.Y - 1 > OffsetBetweenChildren.Y ? areaNeeded.Y - 1 : OffsetBetweenChildren.Y;
        else
            position.X += areaNeeded.X - 1 > OffsetBetweenChildren.X ? areaNeeded.X - 1 : OffsetBetweenChildren.X;
        return position;
    }
}
