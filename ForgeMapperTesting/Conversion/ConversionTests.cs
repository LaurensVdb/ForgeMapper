using ForgeMapperLibrary;
using ForgeMapperLibrary.Attributes;
using ForgeMapperLibrary.Core;

namespace ForgeMapperTesting.Conversion
{
	public class ConversionTests
	{
		public class IntToString : ConversionProvider<int, string>
		{
			public override Func<int, string> Conversion { get; } = x => x.ToString();
		}

		public class StringToInt : ConversionProvider<string, int>
		{
			public override Func<string, int> Conversion { get; } = x => int.Parse(x);
		}

		public class StringToIntMultiply : ConversionProvider<string, int>
		{
			public override Func<string, int> Conversion { get; } = x => int.Parse(x) * 2;
		}


		class SourceA
		{
			[ForgeMapperBasicTypeConversionAttribute(typeof(StringToInt), nameof(StringToInt.Conversion))]
			public string StringA { get; set; }

			[ForgeMapperBasicTypeConversionAttribute(typeof(StringToIntMultiply), nameof(StringToInt.Conversion))]
			public string StringA2 { get; set; }

			[ForgeMapperBasicTypeConversionAttribute(typeof(IntToString), nameof(IntToString.Conversion))]
			public int IntA { get; set; }

		}

		class DestinationB
		{
			public int StringA { get; set; }

			public int StringA2 { get; set; }

			public string IntA { get; set; }


		}

		private readonly ForgeMapper _mapper;
		public ConversionTests()
		{
			_mapper = new ForgeMapper();
		}
		[Fact]
		public void TestConvert()
		{
			SourceA sourceA = new SourceA();
			sourceA.StringA = "5";
			sourceA.StringA2 = "10";
			sourceA.IntA = 10;
			DestinationB destinationB = new DestinationB();

			_mapper.Map(sourceA, destinationB);


			Assert.Equal(5, destinationB.StringA);
			Assert.Equal(20, destinationB.StringA2);
			Assert.Equal("10", destinationB.IntA);

		}
	}
}

