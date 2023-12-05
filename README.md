# Console Extension

## Class diagram overview
```mermaid
classDiagram
class IMenuBuilder{
    <<interface>>
    +Orientation(ContainerChildOrientation orientation) IMenuBuilder;
    +Title(string title) IMenuBuilder;
    +AddChild(IMenuContainerChild item) IMenuBuilder;
    +SelectByIndex(int index) IMenuBuilder;
    +SelectByValue<T>(T value) IMenuBuilder;
    +SetActionOnKeyPressed(Func<ConsoleKeyInfo, IMenuContainer, bool> actionOnKeyPressed) IMenuBuilder;
    +Build() IMenuContainer;
}

class IMenuContainer{
    <<interface>>
    +IEnumerable~IMenuContainerChild~ Children
    +ContainerChildOrientation OrientationOfChildren
    +Vector2 OffsetBetweenChildren
    +int SelectedIndex

    +SelectByValue<T>(T value) void;
    +SetActionOnKeyPressed(Func<ConsoleKeyInfo, IMenuContainer, bool> actionOnKeyPressed) void;
    +GetSelectedChild() IMenuContainerChild;
    +AddChild(IMenuContainerChild child) void;
}
```