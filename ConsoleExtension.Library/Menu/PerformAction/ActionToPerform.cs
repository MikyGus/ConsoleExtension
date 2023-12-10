using ConsoleExtension.Library.Menu.Abstract;
using ConsoleExtension.Library.Menu.Fixed;

namespace ConsoleExtension.Library.Menu.PerformAction;
public static class ActionToPerform
{
    public static bool MoveSelection(ConsoleKeyInfo key, IMenuContainer container)
    {
        switch (key.Key,container.OrientationOfChildren)
        {
            case (ConsoleKey.UpArrow, ContainerChildOrientation.Vertical):
                container.DecrementMoveSelection(true);
                return false;
            case (ConsoleKey.DownArrow, ContainerChildOrientation.Vertical):
                container.IncrementMoveSelection(true);
                return false;
            case (ConsoleKey.UpArrow, ContainerChildOrientation.Horizontal):
                container.Parent?.DecrementMoveSelection(true);
                return false;
            case (ConsoleKey.DownArrow, ContainerChildOrientation.Horizontal):
                container.Parent?.IncrementMoveSelection(true);
                return false;
            case (ConsoleKey.RightArrow, ContainerChildOrientation.Horizontal):
                container.IncrementMoveSelection(false);
                return true;
            case (ConsoleKey.LeftArrow, ContainerChildOrientation.Horizontal):
                container.DecrementMoveSelection(false);
                return true;
        }
        return true;
    }
}
