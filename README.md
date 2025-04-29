# ForgeMapper

ForgeMapper is a powerful and extensible object mapping tool designed to transfer properties between source and target objects. It identifies matching properties based on names and compatible types, supporting simple types, complex object structures, new object creation, and collection synchronization.

---

## Key Features

- **Property Mapping**: Automatically map properties between two objects with matching names and types.
- **Object Creation**: Dynamically create instances of target objects and map properties from a source object.
- **Collection Mapping**: Synchronize properties between elements in two collections.

ForgeMapper is ideal for data transfer, object transformation, and abstracting mapping logic within various applications.

---

## Getting Started

Here are examples of how to use the `ForgeMapper` class in different scenarios.

### Example 1: Property Mapping between Two Objects
```csharp
var forgeMapper = new ForgeMapper();

var source = new SourceClass { Name = "John", Age = 30 };
var destination = new DestinationClass();

forgeMapper.Map(source, destination);

Console.WriteLine($"Mapped Destination - Name: {destination.Name}, Age: {destination.Age}");
