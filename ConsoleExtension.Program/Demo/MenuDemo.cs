using ConsoleExtension.Library.Menu;
using ConsoleExtension.Library.Menu.Abstract;
using ConsoleExtension.Library.Menu.Fixed;
using ConsoleExtension.Library.Menu.Models;

namespace ConsoleExtension.Program.Demo;
internal static class MenuDemo
{
    public static void Run()
    {
        IMenuContainer menuNumberOfPlayers = new MenuContainerBuilder()
            .Title("Number of players")
            .Orientation(ContainerChildOrientation.Horizontal)
            .AddChild(new MenuContainerItem<int>(2))
            .AddChild(new MenuContainerItem<int>(3))
            .AddChild(new MenuContainerItem<int>(4))
            .Build();

        IMenuContainer menu = new MenuContainerBuilder()
            .Title("Settings")
            .Orientation(ContainerChildOrientation.Vertical)
            .AddChild(new MenuContainerBuilder()
                .Title("Players")
                .Orientation(ContainerChildOrientation.Horizontal)
                .AddChild(menuNumberOfPlayers)
                .Build())
            .AddChild(new MenuContainerBuilder()
                .Title("Play Area")
                .Orientation(ContainerChildOrientation.Horizontal)
                .Build())
            .Build();

        menu.Render();
    }
}
