using ForgeMapperLibrary;

namespace ForgeMapperTesting.BasicTypeTest
{
    public class BasicTypeMapperTests
    {
        class SourceA
        {
            public string StringA { get; set; }
            public int IntA { get; set; }
            public DateTime DateTimeA { get; set; }
            public float DoubleA { get; set; }
            public decimal DecimalA { get; set; }
            public byte ByteA { get; set; }

            public ushort UShortA { get; set; }

            public char CharA { get; set; }

            public long LongA { get; set; }
            public Guid GuidA { get; set; }
            public bool BoolA { get; set; }
            public float FloatA { get; set; }
            //
        }

        class DestinationB
        {
            public string StringA { get; set; }
            public int IntA { get; set; }
            public DateTime DateTimeA { get; set; }
            public float DoubleA { get; set; }
            public decimal DecimalA { get; set; }
            public byte ByteA { get; set; }

            public ushort UShortA { get; set; }

            public char CharA { get; set; }

            public long LongA { get; set; }
            public Guid GuidA { get; set; }
            public bool BoolA { get; set; }
            public float FloatA { get; set; }

        }

        private ForgeMapper _mapper;
        public BasicTypeMapperTests()
        {
            _mapper = new ForgeMapper();
        }
        [Fact]
        public void TestBasicTypes()
        {
            var sourceA = new SourceA();
            sourceA.DateTimeA = DateTime.Today;
            sourceA.StringA = "hello";
            sourceA.IntA = 1;
            sourceA.UShortA = 1;
            sourceA.CharA = 'A';
            sourceA.LongA = 1245721234;
            sourceA.DoubleA = 2.5f;
            sourceA.DecimalA = 2.5m;
            sourceA.ByteA = (byte)sourceA.CharA;

            sourceA.GuidA = Guid.NewGuid();
            sourceA.BoolA = true;
            sourceA.FloatA = 124.123f;

            var sourceB = new DestinationB();

            _mapper.Map(sourceA, sourceB);


            Assert.Equal(sourceA.IntA, sourceB.IntA);
            Assert.Equal(sourceA.StringA, sourceB.StringA);
            Assert.Equal(sourceA.DoubleA, sourceB.DoubleA);
            Assert.Equal(sourceA.DecimalA, sourceB.DecimalA);
            Assert.Equal(sourceA.BoolA, sourceB.BoolA);
            Assert.Equal(sourceA.FloatA, sourceB.FloatA);
            Assert.Equal(sourceA.LongA, sourceB.LongA);
            Assert.Equal(sourceA.DoubleA, sourceB.DoubleA);
            Assert.Equal(sourceA.UShortA, sourceB.UShortA);
            Assert.Equal(sourceA.CharA, sourceB.CharA);
            Assert.Equal(sourceA.GuidA, sourceB.GuidA);
            Assert.Equal(sourceA.ByteA, sourceB.ByteA);
            Assert.Equal(sourceA.DateTimeA, sourceB.DateTimeA);
        }
    }
}
