using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp186.Data
{
	public class WeatherForecastService
	{
		private static readonly string[] Summaries = new[]
		{
						"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
				};

		private volatile int LockCount;

		public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
		{
			if (Interlocked.CompareExchange(ref LockCount, 1, 0) == 1)
				throw new InvalidOperationException("Multi-thread access");

			try
			{
				await Task.Delay(500);
				var rng = new Random();
				return Enumerable.Range(1, 5).Select(index => new WeatherForecast
				{
					Date = startDate.AddDays(index),
					TemperatureC = rng.Next(-20, 55),
					Summary = Summaries[rng.Next(Summaries.Length)]
				}).ToArray();
			}
			finally
			{
				Interlocked.Decrement(ref LockCount);
			}
		}
	}
}
