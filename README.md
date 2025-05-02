# ForgeMapper

ForgeMapper is a powerful and extensible object mapping tool designed to transfer properties between source and target objects. As a free alternative to AutoMapper, it automatically identifies matching properties based on names and compatible types, supporting simple types, complex object structures, new object creation, and collection synchronization. ForgeMapper provides developers with an accessible and flexible solution for seamless data mapping without commercial restrictions.

[![.NET](https://github.com/LaurensVdb/ForgeMapper/actions/workflows/dotnet.yml/badge.svg?branch=master)](https://github.com/LaurensVdb/ForgeMapper/actions/workflows/dotnet.yml)
---

## Key Features

- **Property Mapping**: Automatically map properties between two objects with matching names and types.
- **Object Creation**: Dynamically create instances of target objects and map properties from a source object.
- **Collection Mapping**: Synchronize properties between elements in two collections.
- **Attribute-Based property mapping**: Use the `ForgeMapperPropertyAttribute` to map properties explicitly between source and destination objects.
- **Attribute-Based property ignoring**: Use the `ForgeMapperIgnoreProperty` to ignore properties explicitly between source and destination objects.

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

### ForgeMapperIgnoreProperty
An attribute that explicitly ignores a propertie between source and destination.

--

## Getting Started

Here are examples of how to use the `ForgeMapper` in different scenarios.

### Example 1: Property Mapping between Two Objects
```csharp
using ForgeMapperLibrary;
public class Program
{
    class Source
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Destination
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    private static void Main(string[] args)
    {
        ForgeMapper forgeMapper = new ForgeMapper();
        var source = new Source();
        source.Age = 22;
        source.Name = "Peter";

        var destination = new Destination();

        forgeMapper.Map(source, destination);

        Console.WriteLine($"destination name:{destination.Name} and age:{destination.Age}");
        //output: destination name:Peter and age:22
    }
}
```

### Example 2: Mapping Nested Objects
```csharp
using ForgeMapperLibrary;
public class Program
{
    class PersonSource
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public AddressSource Address { get; set; }
    }

    class AddressSource
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
    class PersonDestination
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public AddressDestination Address { get; set; }
    }

    class AddressDestination
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
    private static void Main(string[] args)
    {
        ForgeMapper forgeMapper = new ForgeMapper();
        var source = new PersonSource();
        source.Age = 22;
        source.Name = "Peter";
        source.Address = new AddressSource()
        {
            PostalCode = "2555",
            Street = "street",
            City = "Paris"
        };
        var destination = new PersonDestination();

        forgeMapper.Map(source, destination);

        Console.WriteLine($"destination address:{destination.Address.City} - {destination.Address.PostalCode} - {destination.Address.Street} ");
        //output:destination address:Paris - 2555 - street
    }
}
```

### Example 3: Mapping Properties Between Two Collections
```csharp
using ForgeMapperLibrary;
public class Program
{
    class PersonSource
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }


    class PersonDestination
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }


    private static void Main(string[] args)
    {
        ForgeMapper forgeMapper = new ForgeMapper();

        List<PersonSource> sources = new List<PersonSource>()
        {
             new PersonSource()
             {
                Age = 22,
                Name = "Peter"
             },
              new PersonSource()
             {
                Age = 30,
                Name = "Luke"
             }


        };

        List<PersonDestination> destinations = new List<PersonDestination>();

        forgeMapper.MapCollection(sources, destinations);

        foreach (PersonDestination destination in destinations)
        {
            Console.WriteLine($"{destination.Name} {destination.Age}");
        }
        //output:Peter 22
        //       Luke 30
    }
}
```

### Example 4: Create and Map a New Object Dynamically
```csharp
using ForgeMapperLibrary;
internal class Program
{
    class Source
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Destination
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    private static void Main(string[] args)
    {
        ForgeMapper forgeMapper = new ForgeMapper();
        var source = new Source();
        source.Age = 22;
        source.Name = "Peter";

        var destination = forgeMapper.CreateObject<Destination>(source);

        Console.WriteLine($"destination name:{destination.Name} and age:{destination.Age}");
        //output:destination name:Peter and age:22
    }
}
```

### Example 5: Attribute-Based property mapping
```csharp
using ForgeMapperLibrary;
using ForgeMapperLibrary.Attributes;
internal class Program
{
    class Source
    {
        [ForgeMapperProperty("Name")]
        public string NameSource { get; set; }
        public int Age { get; set; }
    }
    class Destination
    {
        [ForgeMapperProperty("Name")]
        public string NameDestination { get; set; }
        public int Age { get; set; }
    }
    private static void Main(string[] args)
    {
        ForgeMapper forgeMapper = new ForgeMapper();
        var source = new Source();
        source.Age = 22;
        source.NameSource = "Peter";

        var destination = new Destination();

        forgeMapper.Map(source, destination);

        Console.WriteLine($"destination name:{destination.NameDestination} and age:{destination.Age}");
        //output:destination name:Peter and age:22
    }
}
```

### Example 6: Attribute-Based property ignoring
```csharp
using ForgeMapperLibrary;
using ForgeMapperLibrary.Attributes;
internal class Program
{
    class Source
    {
        [ForgeMapperIgnoreProperty]
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Destination
    {
        [ForgeMapperIgnoreProperty]
        public string Name { get; set; }
        public int Age { get; set; }
    }
    private static void Main(string[] args)
    {
        ForgeMapper forgeMapper = new ForgeMapper();
        var source = new Source();
        source.Age = 22;
        source.Name = "Peter";

        var destination = new Destination();

        forgeMapper.Map(source, destination);

        Console.WriteLine($"destination name:{destination.Name} and age:{destination.Age}");
        //output:destination name: and age:22
    }
}
```


