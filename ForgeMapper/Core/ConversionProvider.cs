namespace ForgeMapperLibrary.Core
{
	public abstract class ConversionProvider<A, B>
	{
		public abstract Func<A, B> Conversion { get; }
	}
}
