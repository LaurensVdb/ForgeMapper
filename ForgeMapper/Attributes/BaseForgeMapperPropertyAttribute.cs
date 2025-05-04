namespace ForgeMapperLibrary.Attributes
{
	public abstract class BaseForgeMapperPropertyAttribute : Attribute
	{
		private string _forgeMapperProperty = "";
		public string ForgeMapperProperty
		{
			get
			{
				// If 'IsIgnore' is set to true, return a randomly generated string.
				// This ensures that property name comparisons always fail and will be ignored
				if (IsIgnore)
				{
					return Guid.NewGuid().ToString();
				}
				return _forgeMapperProperty;

			}
			set
			{
				_forgeMapperProperty = value;
			}
		}
		public bool IsIgnore { get; set; }
	}
}
