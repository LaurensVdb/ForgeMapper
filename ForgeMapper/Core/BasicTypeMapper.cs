using System.Reflection;

namespace ForgeMapperLibrary.Core
{
	internal class BasicTypeMapper
	{

		internal void Map(object source, object destination, PropertyInfo sourceProp, PropertyInfo destProp)
		{
			var valuePropertyA = sourceProp.GetValue(source, null);
			destProp.SetValue(destination, valuePropertyA);
		}
	}
}
