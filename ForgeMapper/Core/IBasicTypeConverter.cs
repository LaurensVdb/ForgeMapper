using System.Reflection;

namespace ForgeMapperLibrary.Core
{
	internal interface IBasicTypeConverter
	{

		void Convert(PropertyInfo source, PropertyInfo dest);
	}
}
