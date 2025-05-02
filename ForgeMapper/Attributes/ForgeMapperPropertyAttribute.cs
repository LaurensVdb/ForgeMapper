namespace ForgeMapperLibrary.Attributes
{
    public class ForgeMapperPropertyAttribute : BaseForgeMapperPropertyAttribute
    {

        public ForgeMapperPropertyAttribute(string forgeMapperProperty)
        {
            this.ForgeMapperProperty = forgeMapperProperty;
            this.IsIgnore = false;

        }
    }
}
