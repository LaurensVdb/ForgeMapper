using ForgeMapperLibrary;
using ForgeMapperLibrary.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeMapperTesting.ForgeMapperTests
{
	public class ForgeMapperTests
	{
		[Fact]
		public void ServiceRegistrationTest()
		{
			IServiceCollection services = new ServiceCollection();

			services.AddScoped<IForgeMapper, ForgeMapper>();
			var service = services.BuildServiceProvider().GetService<IForgeMapper>();

			Assert.NotNull(service);

			var result = service.MapCollection(new List<string>()
			{
				"Test1",
				"Test2",
				"Test3"
			}, new List<string>());

			Assert.NotNull(result);
			Assert.Equal(new List<string>()
			{
				"Test1",
				"Test2",
				"Test3"
			}, result);

		}
	}
}
