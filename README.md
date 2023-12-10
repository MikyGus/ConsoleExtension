# Console Extension
**Extension contains:**
* Menu, designed for displaying a simple menu.
* Print a border around an area.
* Print text with specific color at a specific position.

## Menu
### Example of how to use the menu system
```csharp
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
        // This is used internally to move the selection around. It's set on all container nodes not having suppressed selection.
        //.SetActionOnKeyPressed(ActionToPerform.MoveSelection)

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

    // The container will not be selected, when suppressed
    // But children of this container may still be selected
    .SuppressSelection(true)

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

///// Renders the menu to the screen
// Sets the position of the upper left corner of the menu
// Default is Vector2(0,0)
menu.Position = new Vector2(5, 5);

// Renders the menu
menu.Render();

// Renders the current selections
menu.RenderSelection(true);


// Within a loop we check for input and pass on ConsoleKeyInfo to the menu
// The menu will pass it on to the selected children
ConsoleKeyInfo keyInput;
do
{
    keyInput = Console.ReadKey();
    menu.PerformAction(keyInput);
} while (keyInput.Key != ConsoleKey.Escape);
```

### Class diagram overview
```mermaid
classDiagram
direction RL
class IMenuBuilder{
    <<interface>>
    +Orientation(ContainerChildOrientation orientation) IMenuBuilder
    +Title(string title) IMenuBuilder
    +AddChild(IMenuContainerChild item) IMenuBuilder
    +SelectByIndex(int index) IMenuBuilder
    +SelectByValue<T>(T value) IMenuBuilder
    +SetActionOnKeyPressed(Func<ConsoleKeyInfo, IMenuContainer, bool> actionOnKeyPressed) IMenuBuilder
    +Build() IMenuContainer
}

class IMenuContainer{
    <<interface>>
    +IEnumerable~IMenuContainerChild~ Children
    +ContainerChildOrientation OrientationOfChildren
    +Vector2 OffsetBetweenChildren
    +int SelectedIndex

    +SelectByValue<T>(T value) void
    +SetActionOnKeyPressed(Func<ConsoleKeyInfo, IMenuContainer, bool> actionOnKeyPressed) void
    +GetSelectedChild() IMenuContainerChild
    +AddChild(IMenuContainerChild child) void
}

class IMenuContainerChild{
    <<interface>>
    +string Title
    +Vector2 Position
    +bool IsSelected
    +Render() void;
    +RenderSelection(bool showSelection) void;
    +AreaNeeded() Vector2;
    +PerformAction(ConsoleKeyInfo key) void;
}


class IMenuContainerItem~T~{
    <<interface>>
    +bool IsMarked
    +T Value
    +SetActionOnKeyPressed(Func<ConsoleKeyInfo, IMenuContainerItem<T>, bool> actionOnKeyPressed) void
}

class ContainerChildOrientation{
    <<enumeration>>
    Vertical
    Horizontal
}

class MenuContainer{
    -List~IMenuContainerChild~ _children
    -Func~ConsoleKeyInfo-IMenuContainer-bool~ _actionOnKeyPressed
    -NextChildPosition(Vector2 position, Vector2 areaNeeded) Vector2
}

class MenuContainerItem~T~{
    -Func~ConsoleKeyInfo-IMenuContainer-bool~ _actionOnKeyPressed
}

%%class PerformAction{
%%    MoveSelectionUpOrDown(ConsoleKeyInfo key, IMenuContainer container) bool$
%%    MoveSelectionLeftOrRight(ConsoleKeyInfo key, IMenuContainer container) bool$
%%}

class MenuContainerBuilder{
    -IMenuContainer _container
}

IMenuContainerItem --|> IMenuContainerChild
IMenuContainer --|> IMenuContainerChild
MenuContainerBuilder --|> IMenuBuilder
ContainerChildOrientation --> IMenuBuilder
ContainerChildOrientation --> IMenuContainer
MenuContainer --|> IMenuContainer
MenuContainerItem --|> IMenuContainerItem
```