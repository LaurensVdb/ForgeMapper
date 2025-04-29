using ForgeMapperLibrary.Attributes;
using System.Reflection;

namespace ForgeMapperLibrary.Core
{
    internal class MatchProperties
    {
        internal bool Match(PropertyInfo propertySource, PropertyInfo propertyDestination)
        {
            var attributeA = GetAttribute(propertySource);
            var attributeB = GetAttribute(propertyDestination);

            var nameA = attributeA?.ForgeMapperProperty ?? propertySource.Name;
            var nameB = attributeB?.ForgeMapperProperty ?? propertyDestination.Name;

            return nameA == nameB;
        }


        private ForgeMapperPropertyAttribute? GetAttribute(PropertyInfo property)
        {
            return (ForgeMapperPropertyAttribute?)property
                .GetCustomAttributes(typeof(ForgeMapperPropertyAttribute), false)
                .FirstOrDefault();
        }
    }
}
