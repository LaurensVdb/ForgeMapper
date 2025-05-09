﻿using ForgeMapperLibrary;

namespace ForgeMapperTesting.ReferenceTypeTests
{
	public class IEnumerableMappingTests
	{
		class A
		{
			public List<L1> List { get; set; }
		}
		class B
		{
			public List<L2> List { get; set; }
		}
		class L1
		{
			public string NameC { get; set; }
			public int AgeC { get; set; }
		}

		class L2
		{
			public string NameC { get; set; }
			public int AgeC { get; set; }
		}

		private readonly ForgeMapper _mapper;
		public IEnumerableMappingTests()
		{
			_mapper = new ForgeMapper();
		}

		[Fact]
		public void TestListInList()
		{
			List<List<int>> listOfListsSource = new List<List<int>>();

			// Add inner lists to the List<List<int>>
			listOfListsSource.Add(new List<int> { 1, 2, 3 });
			listOfListsSource.Add(new List<int> { 4, 5, 6 });
			listOfListsSource.Add(new List<int> { 7, 8, 9 });

			List<List<int>> listDestination = new List<List<int>>();
			_mapper.MapCollection(listOfListsSource, listDestination);

		}

		[Fact]
		public void TestList()
		{
			List<string> stringSource = ["test", "testB"];

			List<string> stringDestination = new List<string>();
			_mapper.MapCollection(stringSource, stringDestination);
			for (int i = 0; i < stringSource.Count; i++)
			{
				Assert.Equal(stringSource[i], stringDestination[i]);
			}
		}

		[Fact]
		public void TestListFromThis()
		{
			List<string> stringSource = ["test", "testB"];

            var stringDestination = stringSource.MapCollection<List<string>>();

            Assert.NotNull(stringDestination);

			for (int i = 0; i < stringSource.Count; i++)
			{
				Assert.Equal(stringSource[i], stringDestination[i]);
			}
		}

		[Fact]
        public void TestListInClass()
        {
            var a = new A();
            a.List = new List<L1>()
            {
                new L1()
                {
                    AgeC = 1,NameC="test"
                },
                   new L1()
                {
                    AgeC = 2,NameC="test2"
                }
            };

			B b = new B();
			_mapper.Map(a, b);

			for (int i = 0; i < a.List.Count; i++)
			{
				Assert.Equal(a.List[0].AgeC, b.List[0].AgeC);
				Assert.Equal(a.List[0].NameC, b.List[0].NameC);
			}
		}

		[Fact]
		public void TestMapArray()
		{
			int[] a = new int[] { 1, 2, 3, 4, 5 };
			int[] b = new int[2];

			b = (int[])_mapper.MapCollection(a, b);
		}
	}
}
