using System.Collections;
using System.Reflection;

namespace ForgeMapperLibrary.Core
{
	internal class MapReferenceType
	{
		private readonly ForgeMapper _mapper;

		internal MapReferenceType(ForgeMapper mapper)
		{
			_mapper = mapper;
		}
		internal void Map(object source, object destination, PropertyInfo sourceProp, PropertyInfo destProp)
		{

			object? nestedSource = sourceProp.GetValue(source, null);
			object? nestedDestination = destProp.GetValue(destination, null);
			if (nestedDestination == null)
			{
				nestedDestination = Activator.CreateInstance(destProp.PropertyType);
				destProp.SetValue(destination, nestedDestination);
			}

			if (nestedSource != null && nestedDestination != null)
			{
				if (typeof(IEnumerable).IsAssignableFrom(sourceProp.PropertyType))
				{
					nestedDestination = MapCollection((IEnumerable)nestedSource, (IEnumerable)nestedDestination);
				}
				else
				{
					_mapper.Map(nestedSource, nestedDestination);
				}
			}

		}

		internal IEnumerable MapCollection(IEnumerable source, IEnumerable destination)
		{
			IList sourceList = (IList)source;

			// Handle arrays and generic collections
			if (destination.GetType().IsArray)
			{
				return MapArray(sourceList, destination);
			}
			else
			{
				return MapIEnumerable(sourceList, destination);
			}
		}

		private IEnumerable MapArray(IList sourceList, IEnumerable destination)
		{
			Type? destinationElementType = destination.GetType().GetElementType();

			if (destinationElementType == null)
			{
				//will never happen because of IsArray in Map collection. Cannot test
				throw new NullReferenceException("Element type of destination is null");
			}

			destination = Array.CreateInstance(destinationElementType, sourceList.Count);
			Array.Copy((Array)sourceList, (Array)destination, sourceList.Count);
			return destination;
		}

		private IList MapIEnumerable(IList sourceList, IEnumerable destination)
		{
			// Populate destination list to match source list count
			IList destinationList = (IList)destination;
			Type destinationElementType = destination.GetType().GetGenericArguments().First();

			// Clear the destination list to map from a clean slate
			destinationList.Clear();

			for (int i = 0; i < sourceList.Count; i++)
			{
				object? sourceElement = sourceList[i];

				if (_mapper.TypeMappingPolicy.IsTypeInPolicy(destinationElementType))
				{
					// Direct mapping for supported value types or strings
					destinationList.Add(sourceElement);
				}
				else
				{
					object? newElement = Activator.CreateInstance(destinationElementType);
					// Mapping for reference types
					if (newElement != null && sourceElement != null)
					{
						if (typeof(IEnumerable).IsAssignableFrom(destinationElementType))
						{
							newElement = MapCollection((IEnumerable)sourceElement, (IEnumerable)newElement);
						}
						else
						{
							_mapper.Map(sourceElement, newElement);
						}

						destinationList.Add(newElement);
					}
				}
			}

			return destinationList;
		}
	}
}
