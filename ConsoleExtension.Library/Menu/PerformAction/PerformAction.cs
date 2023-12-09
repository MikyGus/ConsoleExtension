using ConsoleExtension.Library.Menu.Abstract;

namespace ConsoleExtension.Library.Menu.PerformAction;
public static class PerformAction
{
    public static bool MoveSelectionUpOrDown(ConsoleKeyInfo key, IMenuContainer container)
    {
        if (key.Key == ConsoleKey.UpArrow)
        {
            container.DecrementMoveSelection();
            return false;
        }
        else if (key.Key == ConsoleKey.DownArrow)
        {
            container.IncrementMoveSelection();
            return false;
        }
        return true;
    }

    public static bool MoveSelectionLeftOrRight(ConsoleKeyInfo key, IMenuContainer container)
    {
        if (key.Key == ConsoleKey.LeftArrow)
        {
            container.GetSelectedChild().RenderSelection(false);
            container.SelectedIndex--;
            container.GetSelectedChild().RenderSelection(true);
            return false;
        }
        else if (key.Key == ConsoleKey.RightArrow)
        {
            container.GetSelectedChild().RenderSelection(false);
            container.SelectedIndex++;
            container.GetSelectedChild().RenderSelection(true);
            return false;
        }
        return true;
    }
}
