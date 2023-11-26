using MappingPerformance.Loaders;
using MappingPerformance.Loaders.Generators;
using MappingPerformance.Metrics;
using MappingPerformance.Models;

namespace MappingPerformance;

public class ListTests
{
	[Test]
	public void For1MillionUsers_Read1ThousandUsers()
	{
		var users = UserLoader.Load(BigNumber.Millions(1));
		var metrics = new PerformanceMetrics();

		metrics.Start();
		PerformReadsByRandomId(users, BigNumber.Thousands(1));
		metrics.Stop();

		Assert.Pass(metrics.GetResults());
	}

	[Test]
	public void For1MillionExtendedUsers_Read1ThousandUsers()
	{
		var users = UserLoader.LoadExtended(BigNumber.Millions(1));
		var metrics = new PerformanceMetrics();

		metrics.Start();
		PerformReadsByRandomId(users, BigNumber.Thousands(1));
		metrics.Stop();

		Assert.Pass(metrics.GetResults());
	}

	[Test]
	public void For1MillionUsers_Read100ThousandUsers()
	{
		var users = UserLoader.Load(BigNumber.Millions(1));
		var metrics = new PerformanceMetrics();

		metrics.Start();
		PerformReadsByRandomId(users, BigNumber.Thousands(100));
		metrics.Stop();

		Assert.Pass(metrics.GetResults());
	}

	[Test]
	public void For1MillionExtendedUsers_Read100ThousandUsers()
	{
		var users = UserLoader.LoadExtended(BigNumber.Millions(1));
		var metrics = new PerformanceMetrics();

		metrics.Start();
		PerformReadsByRandomId(users, BigNumber.Thousands(100));
		metrics.Stop();

		Assert.Pass(metrics.GetResults());
	}

	private static void PerformReadsByRandomId<T>(IEnumerable<T> users, int numberOfReads) where T : User
	{
		for (var index = 0; index < numberOfReads; ++index)
		{
			var randomId = Random.Shared.Next(1, UserGenerator.LastUsedIndex + 1);
			_ = users.FirstOrDefault(user => user.Id == randomId);
		}
	}
}
