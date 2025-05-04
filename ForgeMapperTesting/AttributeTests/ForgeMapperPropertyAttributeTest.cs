using ForgeMapperLibrary;
using ForgeMapperLibrary.Attributes;

namespace ForgeMapperTesting.AttributeTests
{
	public class ForgeMapperPropertyAttributeTest
	{


		class A
		{
			[ForgeMapperPropertyAttribute("test")]
			public int IntA { get; set; }
		}

		class B
		{
			[ForgeMapperPropertyAttribute("test")]
			public int IntB { get; set; }
		}


		class C
		{
			public int IntC { get; set; }
		}

		class D
		{
			public int test { get; set; }
		}


		private readonly ForgeMapper _mapper;
		public ForgeMapperPropertyAttributeTest()
		{
			_mapper = new ForgeMapper();
		}
		[Fact]
		public void AttributeOnBoth()
		{
			A a = new A();
			a.IntA = 1;

			B b = new B();
			b.IntB = 22;

			_mapper.Map(a, b);
			Assert.Equal(a.IntA, b.IntB);

		}


		[Fact]
		public void TestAttributeHasSameNameAsDestination()
		{
			A a = new A();
			a.IntA = 1;

			C c = new C();
			c.IntC = 22;

			_mapper.Map(a, c);
			Assert.NotEqual(a.IntA, c.IntC);

		}

		[Fact]
		public void TestAttributeOnlyOnSource()
		{
			A a = new A();
			a.IntA = 1;

			D d = new D();
			d.test = 22;

			_mapper.Map(a, d);
			Assert.Equal(a.IntA, d.test);

		}
	}
}
