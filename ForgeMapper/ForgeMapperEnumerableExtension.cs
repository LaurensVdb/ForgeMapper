using System.Collections;

namespace ForgeMapperLibrary
{
	public static class ForgeMapperEnumerableExtension
	{
		/// <summary>
		/// Maps properties between corresponding elements of two lists.
		/// Standard ForgeMapper class is used
		/// </summary>
		/// <typeparam name="T">The type of elements in the target list.</typeparam>
		/// <param name="source">The source list.</param>
		/// <returns>A new target list of type T.</returns>
		public static T MapCollection<T>(this IEnumerable source) where T : IEnumerable, new()
		{
			// TODO set a forgemapper default on app startup?
			ForgeMapper forgeMapper = new();
			return (T)forgeMapper.MapCollection(source, new T());
		}
	}
}
