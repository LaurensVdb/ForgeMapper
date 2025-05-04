namespace ForgeMapperLibrary.Attributes
{
	public class ForgeMapperIgnorePropertyAttribute : BaseForgeMapperPropertyAttribute
	{
		public ForgeMapperIgnorePropertyAttribute()
		{
			this.IsIgnore = true;
		}
	}
}
