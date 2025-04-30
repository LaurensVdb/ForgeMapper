namespace ForgeMapperLibrary.Attributes
{
	public class ForgeMapperPropertyAttribute : Attribute
	{
		public string ForgeMapperProperty { get; }
		public ForgeMapperPropertyAttribute(string forgeMapperProperty)
		{
			this.ForgeMapperProperty = forgeMapperProperty;

		}
	}
}
