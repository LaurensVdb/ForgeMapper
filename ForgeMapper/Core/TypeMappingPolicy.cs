using System.Reflection;

namespace ForgeMapperLibrary.Core
{
    public class TypeMappingPolicy
    {
        private readonly HashSet<Type> _supportedDirectMappingTypes;

        public TypeMappingPolicy(HashSet<Type> types)
        {
            // Initialize the supported types
            _supportedDirectMappingTypes = types;


        }

        public bool CanMapDirectly(PropertyInfo sourceProp, PropertyInfo destProp)
        {

            return sourceProp.PropertyType == destProp.PropertyType
                   && (sourceProp.PropertyType.IsValueType || _supportedDirectMappingTypes.Contains(sourceProp.PropertyType));
        }

        public bool IsTypeInPolicy(Type type)
        {

            return _supportedDirectMappingTypes.Contains(type) || type.IsValueType;
        }
    }

}
