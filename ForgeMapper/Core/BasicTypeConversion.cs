using ForgeMapperLibrary.Attributes;
using System.Reflection;

namespace ForgeMapperLibrary.Core
{
	internal class BasicTypeConversion
	{
		private ForgeMapperBasicTypeConversionAttribute? attribute;

		internal bool IsConversion(PropertyInfo sourceProp)
		{
			attribute = (ForgeMapperBasicTypeConversionAttribute?)sourceProp
				.GetCustomAttribute(typeof(ForgeMapperBasicTypeConversionAttribute), false);

			return attribute != null;
		}
		internal object? RunConversion(PropertyInfo sourceProp, object destination)
		{
			var value = sourceProp.GetValue(destination, null);
			if (IsConversion(sourceProp))
			{
				if (attribute != null)
				{
					var invoker = attribute.GetFunction();
					if (invoker != null)
					{
						return invoker.DynamicInvoke(value);
					}

				}


			}
			return value;


		}



	}
}
