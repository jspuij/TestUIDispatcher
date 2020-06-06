using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BlazorApp186
{

	public delegate Task UIDispatcherDelegate(Func<Task> workItem);

	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
				Host.CreateDefaultBuilder(args)
						.ConfigureWebHostDefaults(webBuilder =>
						{
							webBuilder.UseStartup<Startup>();
						});
	}
}
