using System.Reflection;

namespace ForgeMapperLibrary.Core
{
	public class TypeMappingPolicy
	{
		private readonly HashSet<Type> _supportedDirectMappingTypes;
		private readonly BasicTypeConversion basicTypeConversion;
		public TypeMappingPolicy(HashSet<Type> types)
		{
			// Initialize the supported types
			_supportedDirectMappingTypes = types;
			basicTypeConversion = new BasicTypeConversion();


		}

		public bool CanMapDirectly(PropertyInfo sourceProp, PropertyInfo destProp)
		{

			return (sourceProp.PropertyType == destProp.PropertyType || basicTypeConversion.IsConversion(sourceProp))
				   && (sourceProp.PropertyType.IsValueType || _supportedDirectMappingTypes.Contains(sourceProp.PropertyType));
		}

		public bool IsTypeInPolicy(Type type)
		{

			return _supportedDirectMappingTypes.Contains(type) || type.IsValueType;
		}
	}

}
