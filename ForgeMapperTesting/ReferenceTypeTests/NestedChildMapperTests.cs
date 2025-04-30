using ForgeMapperLibrary;

namespace ForgeMapperTesting.ReferenceTypeTest
{

	public class NestedChildMapperTests
	{
		class ObjectSource
		{
			public required string StringA { get; set; }
			public int IntA { get; set; }

			public required ObjectSource? Child { get; set; }

		}

		class ObjectBDestination
		{
			public required string StringA { get; set; }
			public int IntA { get; set; }
			public required ObjectBDestination? Child { get; set; }
		}
		private readonly ForgeMapper _mapper;
		public NestedChildMapperTests()
		{
			_mapper = new ForgeMapper();


		}
		[Fact]
		public void TestOneNestedObject()
		{
			var source = new ObjectSource()
			{
				StringA = "Hello",
				IntA = 1,
				Child = new ObjectSource()
				{
					StringA = "World",
					IntA = 2,
					Child = null
				}
			};
			var destination = new ObjectBDestination { Child = null, StringA = "A"};
			//destination.Child = new ObjectBDestination();


			_mapper.Map(source, destination);

			Assert.Equal(source.StringA, destination.StringA);
			Assert.Equal(source.IntA, destination.IntA);
			Assert.NotNull(destination.Child);
			Assert.Equal(source.Child.StringA, destination.Child.StringA);
			Assert.Equal(source.Child.IntA, destination.Child.IntA);
		}
	}
}
