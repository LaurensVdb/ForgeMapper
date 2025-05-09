using System.Reflection;

namespace ForgeMapperLibrary.Core
{
	internal class BasicTypeMapper
	{
		private readonly BasicTypeConversion basicTypeConversion;
		public BasicTypeMapper()
		{
			basicTypeConversion = new BasicTypeConversion();
		}

		internal void Map(object source, object destination, PropertyInfo sourceProp, PropertyInfo destProp)
		{
			var value = basicTypeConversion.RunConversion(sourceProp, source);
			destProp.SetValue(destination, value);
		}
	}
}
