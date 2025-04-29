namespace ForgeMapperLibrary.Core
{
    internal class MapCreateObject
    {
        private ForgeMapper _mapper;

        internal MapCreateObject(ForgeMapper forgeMapper)
        {
            _mapper = forgeMapper;
        }
        internal Destination? CreateObject<Destination>(object source)
        {
            var instanceDestination = CreateInstanceOfType<Destination>();
            if (instanceDestination != null)
            {
                _mapper.Map(source, instanceDestination);
            }
            return (Destination?)instanceDestination;

        }


        private T? CreateInstanceOfType<T>()
        {
            var typeInstance = typeof(T);
            var instance = Activator.CreateInstance(typeInstance);

            return (T?)instance;

        }
    }
}
