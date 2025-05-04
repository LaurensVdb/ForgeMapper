namespace ForgeMapperLibrary.Core
{
	internal class MapCreateObject
	{
		private readonly ForgeMapper _mapper;

		internal MapCreateObject(ForgeMapper forgeMapper)
		{
			_mapper = forgeMapper;
		}
		internal Destination? CreateObject<Destination>(object source)
		{
			Destination? instanceDestination = CreateInstanceOfType<Destination>();
			if (instanceDestination != null)
			{
				_mapper.Map(source, instanceDestination);
			}
			return instanceDestination;

		}


		private T? CreateInstanceOfType<T>()
		{
			Type typeInstance = typeof(T);
			object? instance = Activator.CreateInstance(typeInstance);

			return (T?)instance;

		}
	}
}
