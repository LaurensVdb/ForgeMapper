using ForgeMapperLibrary.Core;
using System.Collections;
using System.Reflection;

namespace ForgeMapperLibrary
{
	public class ForgeMapper
	{
		private readonly MatchProperties _propertyMatcher;
		private readonly MapReferenceType _mapReferenceType;
		private readonly BasicTypeMapper _simpleTypeMapper;
		private readonly MapCreateObject _mapCreateObject;
		internal TypeMappingPolicy TypeMappingPolicy { get; set; }

		public ForgeMapper()
		{
			_mapReferenceType = new MapReferenceType(this);
			_simpleTypeMapper = new BasicTypeMapper();
			_propertyMatcher = new MatchProperties();
			_mapCreateObject = new MapCreateObject(this);
			TypeMappingPolicy = new TypeMappingPolicy(new HashSet<Type>()
			{
				typeof(string),
				typeof(DateTime),
				typeof(Guid),
			});
		}
		/// <summary>
		/// Maps the properties of the source object <paramref name="source"/> to the target object <paramref name="destination"/>.
		/// </summary>
		/// <param name="source">
		/// The source object whose properties will be read and transferred.
		/// </param>
		/// <param name="destination">
		/// The target object to which the properties from <paramref name="source"/> will be mapped.
		/// </param>
		/// <remarks>
		/// Both objects must have properties with matching names and compatible types for the mapping to succeed.
		/// </remarks>
		/// 
		public void Map(object source, object destination)
		{
			PropertyInfo[] propertiesA = source.GetType().GetProperties();
			PropertyInfo[] propertiesB = destination.GetType().GetProperties();

			foreach (PropertyInfo propertySource in propertiesA)
			{
				foreach (PropertyInfo propertyDestination in propertiesB)
				{
					if (!_propertyMatcher.Match(propertySource, propertyDestination))
						continue;

					MapProperties(source, destination, propertySource, propertyDestination);
				}
			}
		}

		/// <summary>
		/// Creates an instance of the specified type <typeparamref name="Destination"/> and maps the properties
		/// from the input object <paramref name="source"/> to the newly created instance.
		/// </summary>
		/// <typeparam name="Destination">
		/// The type of the object to create. Must have a parameterless constructor.
		/// </typeparam>
		/// <param name="source">
		/// The source object whose properties will be mapped to the created instance.
		/// </param>
		/// <returns>
		/// A new instance of type <typeparamref name="Destination"/> with properties mapped from <paramref name="source"/>.
		/// Returns <see langword="null"/> if the instance of <typeparamref name="Destination"/> cannot be created.
		/// </returns>
		public Destination? CreateObject<Destination>(object source)
		{
			return _mapCreateObject.CreateObject<Destination>(source);

		}

		/// <summary>
		/// Maps properties between corresponding elements of two lists.
		/// </summary>
		/// <typeparam name="Source">The type of elements in the source list.</typeparam>
		/// <typeparam name="Destination">The type of elements in the target list.</typeparam>
		/// <param name="source">The source list.</param>
		/// <param name="destination">The target list.</param>
		public IEnumerable MapCollection(IEnumerable source, IEnumerable destination)
		{
			return _mapReferenceType.MapCollection(source, destination);
		}


		private void MapProperties(object source, object destination, PropertyInfo sourceProp, PropertyInfo destProp)
		{

			if (TypeMappingPolicy.CanMapDirectly(sourceProp, destProp))
			{
				_simpleTypeMapper.Map(source, destination, sourceProp, destProp);
			}
			else
			{
				_mapReferenceType.Map(source, destination, sourceProp, destProp);
			}
		}
	}
}

