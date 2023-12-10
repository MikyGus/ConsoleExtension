using ConsoleExtension.Library.Menu;
using ConsoleExtension.Library.Menu.Fixed;
using ConsoleExtension.Library.Menu.Models;
using ConsoleExtension.Library.Menu.PerformAction;
using ConsoleExtension.Library.Models;
using System.ComponentModel.DataAnnotations;

namespace ConsoleExtension.Program.Trials;
internal static class MenuLayout
{
    public static void Run()
    {
        var numberOfPlayers = new MenuContainerBuilder()
            .Orientation(ContainerChildOrientation.Horizontal)
            .Title("Number of players")
            .AddChild(new MenuContainerItem<int>(1))
            .AddChild(new MenuContainerItem<int>(2))
            .AddChild(new MenuContainerItem<int>(3))
            .AddChild(new MenuContainerItem<int>(4))
            .SelectByValue(3)
            .MarkByValue(4)
            //.SetActionOnKeyPressed(PerformAction.MoveSelectionLeftOrRight)
            .Build();

        var nameOfPlayers = new MenuContainerBuilder()
            .Orientation(ContainerChildOrientation.Horizontal)
            .Title("Playernames")
            .AddChild(new MenuContainerItem<string>("Player 1"))
            .AddChild(new MenuContainerItem<string>("Player 2"))
            .AddChild(new MenuContainerItem<string>("Player 3"))
            .AddChild(new MenuContainerItem<string>("Player 4"))
            .SelectByIndex(2)
            //.SetActionOnKeyPressed(PerformAction.MoveSelectionLeftOrRight)
            .Build();

        var playersMenu = new MenuContainerBuilder()
            .Title("Players")
            .Orientation(ContainerChildOrientation.Vertical)
            .AddChild(numberOfPlayers)
            .AddChild(nameOfPlayers)
            .SuppressSelection(true)
            //.SetActionOnKeyPressed(PerformAction.MoveSelectionUpOrDown)
            .Build();


        var menu = new MenuContainerBuilder()
            .Title("Settings")
            .Orientation(ContainerChildOrientation.Vertical)
            .SuppressSelection(true)
            .AddChild(playersMenu)
            .AddChild(new MenuContainerBuilder()
                .Orientation(ContainerChildOrientation.Horizontal)
                .Title("Grid Size")
                .AddChild(new MenuContainerItem<Vector2>(new Vector2(1,1)))
                .AddChild(new MenuContainerItem<Vector2>(new Vector2(3,3)))
                .AddChild(new MenuContainerItem<Vector2>(new Vector2(5,5)))
                .SelectByValue(new Vector2(5,5))
                .MarkByValue(new Vector2(3,3))
                //.SetActionOnKeyPressed(PerformAction.MoveSelectionUpOrDown)
                .Build())
            .Build();

        menu.Position = new Vector2(0, 0);
        menu.Render();
        menu.RenderSelection(true);

        ConsoleKeyInfo keyInput;
        do
        {
            keyInput = Console.ReadKey();
            menu.PerformAction(keyInput);
        } while (keyInput.Key != ConsoleKey.Escape);

        Console.WriteLine("\n\n\n\n\n\n\n");
    }
}
