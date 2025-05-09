using ForgeMapperLibrary.Core;

namespace ForgeMapperLibrary.Attributes
{
	public class ForgeMapperBasicTypeConversionAttribute : Attribute
	{
		public Type ExpressionConversionType { get; set; }
		public string MethodName { get; set; }
		public ForgeMapperBasicTypeConversionAttribute(Type expressionConversionType, string methodname)
		{
			if (!expressionConversionType.IsGenericType && expressionConversionType.BaseType != null &&
		  expressionConversionType.BaseType.IsGenericType &&
		  expressionConversionType.BaseType.GetGenericTypeDefinition() == typeof(ConversionProvider<,>))
			{
				this.ExpressionConversionType = expressionConversionType;
				this.MethodName = methodname;
			}
			else
			{
				throw new ArgumentException($"Type must inherit from {nameof(ConversionProvider<object, object>)}", nameof(expressionConversionType));
			}

		}

		public Delegate? GetFunction()
		{
			var field = ExpressionConversionType.GetProperty(MethodName);
			//var field = ExpressionConversionType.GetField(MethodName, BindingFlags.Instance | BindingFlags.Public);
			if (field != null)
			{
				var instance = Activator.CreateInstance(ExpressionConversionType);
				return field.GetValue(instance) as Delegate;
			}

			return null;
		}

	}
}
