using ForgeMapperLibrary.Attributes;
using System.Reflection;

namespace ForgeMapperLibrary.Core
{
	internal class MatchProperties
	{
		internal bool Match(PropertyInfo propertySource, PropertyInfo propertyDestination)
		{
			BaseForgeMapperPropertyAttribute? attributeA = GetAttribute(propertySource);
			BaseForgeMapperPropertyAttribute? attributeB = GetAttribute(propertyDestination);

			string nameA = attributeA?.ForgeMapperProperty ?? propertySource.Name;
			string nameB = attributeB?.ForgeMapperProperty ?? propertyDestination.Name;

			return nameA == nameB;
		}


		private BaseForgeMapperPropertyAttribute? GetAttribute(PropertyInfo property)
		{
			return (BaseForgeMapperPropertyAttribute?)property
				.GetCustomAttributes(typeof(BaseForgeMapperPropertyAttribute), false)
				.FirstOrDefault();
		}
	}
}
