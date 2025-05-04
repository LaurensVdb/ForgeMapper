using ForgeMapperLibrary;
using ForgeMapperLibrary.Attributes;

namespace ForgeMapperTesting.AttributeTests
{
    public class ForgeMapperIgnorePropertyAttributeTest
    {
        class A
        {
            [ForgeMapperIgnoreProperty]
            public int IntA { get; set; }
        }

        class B
        {
            [ForgeMapperIgnoreProperty]
            public int IntA { get; set; }
        }

        class C
        {
            public int IntA { get; set; }
        }

        private readonly ForgeMapper _mapper;
        public ForgeMapperIgnorePropertyAttributeTest()
        {
            _mapper = new ForgeMapper();

        }

        [Fact]
        public void TestIgnore()
        {
            var a = new A();
            a.IntA = 1;

            var b = new B();
            b.IntA = 22;

            _mapper.Map(a, b);
            Assert.NotEqual(a.IntA, b.IntA);
        }

        [Fact]
        public void TestIgnoreOnSourceOnly()
        {
            var a = new A();
            a.IntA = 1;

            var b = new C();
            b.IntA = 22;

            _mapper.Map(a, b);
            Assert.NotEqual(a.IntA, b.IntA);
        }
    }
}
