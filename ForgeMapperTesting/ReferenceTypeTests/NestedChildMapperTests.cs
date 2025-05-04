using ForgeMapperLibrary;

namespace ForgeMapperTesting.ReferenceTypeTest
{

	public class NestedChildMapperTests
	{
		class ObjectSource
		{
			public string StringA { get; set; }
			public int IntA { get; set; }

			public ObjectSource Child { get; set; }

		}

		class ObjectBDestination
		{
			public string StringA { get; set; }
			public int IntA { get; set; }
			public ObjectBDestination Child { get; set; }
		}
		private readonly ForgeMapper _mapper;
		public NestedChildMapperTests()
		{
			_mapper = new ForgeMapper();
		}

		[Fact]
		public void TestOneNestedObject()
		{
			ObjectSource source = new ObjectSource()
			{
				StringA = "Hello",
				IntA = 1,
				Child = new ObjectSource()
				{
					StringA = "World",
					IntA = 2,
				}
			};
			ObjectBDestination destination = new ObjectBDestination();
			//destination.Child = new ObjectBDestination();


			_mapper.Map(source, destination);

			Assert.Equal(source.StringA, destination.StringA);
			Assert.Equal(source.IntA, destination.IntA);
			Assert.Equal(source.Child.StringA, destination.Child.StringA);
			Assert.Equal(source.Child.IntA, destination.Child.IntA);
		}
	}
}
