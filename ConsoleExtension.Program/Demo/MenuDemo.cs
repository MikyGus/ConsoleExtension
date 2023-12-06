using ConsoleExtension.Library.Menu;
using ConsoleExtension.Library.Menu.Abstract;
using ConsoleExtension.Library.Menu.Fixed;
using ConsoleExtension.Library.Menu.Models;
using ConsoleExtension.Library.Menu.PerformAction;
using ConsoleExtension.Library.Models;

namespace ConsoleExtension.Program.Demo;
internal static class MenuDemo
{
    private static class Settings
    {
        public static int NumberOfPlayers => 3;
    }

    public static void Run()
    {
    // menuNumberOfPlayers is a subsection of the menu (below).
    // Added as a child to "Players"
    IMenuContainer menuNumberOfPlayers = new MenuContainerBuilder()
            // Adds a Title to the node
            .Title("Number of players")
            // Sets the orientation of this nodes own children
            .Orientation(ContainerChildOrientation.Horizontal) // default is Vertical
            // MenuContainerItem is the end of the tree structure (leaf) 
            .AddChild(new MenuContainerItem<int>(2)) // MenuContainerItem contains a specific value
            .AddChild(new MenuContainerItem<int>(3)) // ... set with generics
            .AddChild(new MenuContainerItem<decimal>(4m)) // The Container can hold children with different datatypes
            // Set an action to be performed when the user press a key
            // The signature is
            //      MenuContainer: Func<ConsoleKeyInfo, IMenuContainer, bool>
            //      ManuContainerItem: Func<ConsoleKeyInfo, IMenuContainerItem<T>, bool>
            // The bool indicates if it should continue down the tree hierarchy to the next selected child
            .SetActionOnKeyPressed(PerformAction.MoveSelectionLeftOrRight)
            // Selects the child MenuContainerItem that matches provided value
            // Both T and value must be equal
            .SelectByValue(Settings.NumberOfPlayers) // Default - Selects the first child in the collection
            // Marks the child MenuContainerItem that matches provided value
            // Both T and value must be equal
            // If no match is found, no item is marked.
            .MarkByValue(Settings.NumberOfPlayers) // Default - No item marked
            // Builds it to a MenuContainer
            .Build();

        IMenuContainer menu = new MenuContainerBuilder()
            .Title("Settings")
            // Moves the containers selection if the user presses UP or DOWN
            .SetActionOnKeyPressed(PerformAction.MoveSelectionUpOrDown)
            // This orientaion is not needed since default is Vertical
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

        // Renders the menu to the screen
        menu.Position = new Vector2(5, 5); // Default is Vector2(0,0)
        menu.Render();


        // Within a loop we check for input and pass on ConsoleKeyInfo to the menu
        // The menu will pass it on to the selected children
        ConsoleKeyInfo keyInput;
        do
        {
            keyInput = Console.ReadKey();
            menu.PerformAction(keyInput);
        } while (keyInput.Key != ConsoleKey.Escape);
    }
}
