# ForgeMapper

ForgeMapper is a powerful and extensible object mapping tool designed to transfer properties between source and target objects. It identifies matching properties based on names and compatible types, supporting simple types, complex object structures, new object creation, and collection synchronization.

---

## Key Features

- **Property Mapping**: Automatically map properties between two objects with matching names and types.
- **Object Creation**: Dynamically create instances of target objects and map properties from a source object.
- **Collection Mapping**: Synchronize properties between elements in two collections.
- **Attribute-Based Mapping**: Use the `ForgeMapperPropertyAttribute` to map properties explicitly between source and destination objects.



---

## Methods

### Map
Maps properties between source and destination objects, including nested properties and attributes.

### CreateObject
Dynamically creates a destination object and maps properties from the source.

### MapCollection
Maps properties between elements of source and destination collections.

---

## Attribute-Based Mapping

### ForgeMapperPropertyAttribute
An attribute that explicitly defines how properties between source and destination should map.

If a source property has a `ForgeMapperPropertyAttribute` matching the destination property name or destination attribute, it's considered a match and can be mapped.

--

## Getting Started

Here are examples of how to use the `ForgeMapper` class in different scenarios.

### Example 1: Property Mapping between Two Objects
```csharp
var forgeMapper = new ForgeMapper();

var source = new SourceClass { Name = "John", Age = 30 };
var destination = new DestinationClass();

forgeMapper.Map(source, destination);

Console.WriteLine($"Mapped Destination - Name: {destination.Name}, Age: {destination.Age}");

### Example 2: Mapping Nested Objects
var forgeMapper = new ForgeMapper();

var source = new SourceClass
{
    Name = "John",
    Age = 30,
    Address = new AddressClass
    {
        Street = "123 Maple St",
        City = "Springfield",
        PostalCode = "12345"
    }
};

var destination = new DestinationClass();

forgeMapper.Map(source, destination);

Console.WriteLine($"Mapped Destination - Name: {destination.Name}, Age: {destination.Age}");
Console.WriteLine($"Mapped Address - Street: {destination.Address.Street}, City: {destination.Address.City}, PostalCode: {destination.Address.PostalCode}");
```

### Example 3: Mapping Properties Between Two Collections
```csharp
var forgeMapper = new ForgeMapper();

var sourceList = new List<SourceClass>
{
    new SourceClass { Name = "Alice", Age = 25 },
    new SourceClass { Name = "Bob", Age = 28 }
};

var destinationList = new List<DestinationClass>();
forgeMapper.MapCollection(sourceList, destinationList);

foreach (var item in destinationList)
{
    Console.WriteLine($"Mapped Collection Item - Name: {item.Name}, Age: {item.Age}");
}
```

### Example 4: Create and Map a New Object Dynamically
```csharp
var forgeMapper = new ForgeMapper();

var source = new SourceClass { Name = "Alice", Age = 25 };

var createdObject = forgeMapper.CreateObject<DestinationClass>(source);
if (createdObject != null)
{
    Console.WriteLine($"Created Object - Name: {createdObject.Name}, Age: {createdObject.Age}");
}
else
{
    Console.WriteLine("Failed to create the destination object.");
}
```

### Example 5: Attribute-Based Mapping
```csharp
var forgeMapper = new ForgeMapper();

var source = new SourceClassWithAttributes
{
    Name = "John",
    Age = 30,
    Location = "Springfield"
};

var destination = new DestinationClassWithAttributes();

forgeMapper.Map(source, destination);

Console.WriteLine($"Mapped Destination - Name: {destination.FullName}, Age: {destination.Age}, City: {destination.City}");

public class ForgeMapperPropertyAttribute : Attribute
{
    public string ForgeMapperProperty { get; }
    public ForgeMapperPropertyAttribute(string forgeMapperProperty)
    {
        this.ForgeMapperProperty = forgeMapperProperty;
    }
}

public class SourceClassWithAttributes
{
    [ForgeMapperProperty("FullName")]
    public string Name { get; set; }

    public int Age { get; set; }

    [ForgeMapperProperty("City")]
    public string Location { get; set; }
}

public class DestinationClassWithAttributes
{
    public string FullName { get; set; }

    public int Age { get; set; }

    public string City { get; set; }
}
```



