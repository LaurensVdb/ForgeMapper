using System.Collections;

namespace ForgeMapperLibrary.Interfaces
{
	public interface IForgeMapper
	{
		Destination? CreateObject<Destination>(object source);
		void Map(object source, object destination);
		IEnumerable MapCollection(IEnumerable source, IEnumerable destination);
	}
}