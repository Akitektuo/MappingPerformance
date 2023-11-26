using MappingPerformance.Loaders.Generators;
using MappingPerformance.Loaders;
using MappingPerformance.Metrics;
using MappingPerformance.Models;

namespace MappingPerformance;

public class DoubleDictionaryTests
{
	[Test]
	public void For1ThousandExtendedUsers_Read1User()
	{
		var users = UserLoader.LoadExtended(BigNumber.Thousands(1));
		var usersById = users.ToDictionary(user => user.Id);
		var usersByExternalId = users.ToDictionary(user => user.ExternalId);
		var metrics = new PerformanceMetrics();

		metrics.Start();
		PerformReadsByRandomId(usersById, 1);
		metrics.Stop();

		Assert.Pass(metrics.GetResults());
	}

	[Test]
	public void For1ThousandExtendedUsers_Read10Users()
	{
		var users = UserLoader.LoadExtended(BigNumber.Thousands(1));
		var usersById = users.ToDictionary(user => user.Id);
		var usersByExternalId = users.ToDictionary(user => user.ExternalId);
		var metrics = new PerformanceMetrics();

		metrics.Start();
		PerformReadsByRandomId(usersById, 10);
		metrics.Stop();

		Assert.Pass(metrics.GetResults());
	}

	[Test]
	public void For10ThousandExtendedUsers_Read100Users()
	{
		var users = UserLoader.LoadExtended(BigNumber.Thousands(10));
		var usersById = users.ToDictionary(user => user.Id);
		var usersByExternalId = users.ToDictionary(user => user.ExternalId);
		var metrics = new PerformanceMetrics();

		metrics.Start();
		PerformReadsByRandomId(usersById, 100);
		metrics.Stop();

		Assert.Pass(metrics.GetResults());
	}

	[Test]
	public void For100ThousandExtendedUsers_Read100Users()
	{
		var users = UserLoader.LoadExtended(BigNumber.Thousands(100));
		var usersById = users.ToDictionary(user => user.Id);
		var usersByExternalId = users.ToDictionary(user => user.ExternalId);
		var metrics = new PerformanceMetrics();

		metrics.Start();
		PerformReadsByRandomId(usersById, 100);
		metrics.Stop();

		Assert.Pass(metrics.GetResults());
	}

	[Test]
	public void For100ThousandExtendedUsers_Read1ThousandUsers()
	{
		var users = UserLoader.LoadExtended(BigNumber.Thousands(100));
		var usersById = users.ToDictionary(user => user.Id);
		var usersByExternalId = users.ToDictionary(user => user.ExternalId);
		var metrics = new PerformanceMetrics();

		metrics.Start();
		PerformReadsByRandomId(usersById, BigNumber.Thousands(1));
		metrics.Stop();

		Assert.Pass(metrics.GetResults());
	}

	[Test]
	public void For1MillionUsers_Read1ThousandUsers()
	{
		var users = UserLoader.Load(BigNumber.Millions(1));
		var usersById = users.ToDictionary(user => user.Id);
		var usersByExternalId = users.ToDictionary(user => user.ExternalId);
		var metrics = new PerformanceMetrics();

		metrics.Start();
		PerformReadsByRandomId(usersById, BigNumber.Thousands(1));
		metrics.Stop();

		Assert.Pass(metrics.GetResults());
	}

	[Test]
	public void For1MillionExtendedUsers_Read1ThousandUsers()
	{
		var users = UserLoader.LoadExtended(BigNumber.Millions(1));
		var usersById = users.ToDictionary(user => user.Id);
		var usersByExternalId = users.ToDictionary(user => user.ExternalId);
		var metrics = new PerformanceMetrics();

		metrics.Start();
		PerformReadsByRandomId(usersById, BigNumber.Thousands(1));
		metrics.Stop();

		Assert.Pass(metrics.GetResults());
	}

	[Test]
	public void For1MillionUsers_Read100ThousandUsers()
	{
		var users = UserLoader.Load(BigNumber.Millions(1));
		var usersById = users.ToDictionary(user => user.Id);
		var usersByExternalId = users.ToDictionary(user => user.ExternalId);
		var metrics = new PerformanceMetrics();

		metrics.Start();
		PerformReadsByRandomId(usersById, BigNumber.Thousands(100));
		metrics.Stop();

		Assert.Pass(metrics.GetResults());
	}

	[Test]
	public void For1MillionExtendedUsers_Read100ThousandUsers()
	{
		var users = UserLoader.LoadExtended(BigNumber.Millions(1));
		var usersById = users.ToDictionary(user => user.Id);
		var usersByExternalId = users.ToDictionary(user => user.ExternalId);
		var metrics = new PerformanceMetrics();

		metrics.Start();
		PerformReadsByRandomId(usersById, BigNumber.Thousands(100));
		metrics.Stop();

		Assert.Pass(metrics.GetResults());
	}

	private static void PerformReadsByRandomId<T>(IDictionary<int, T> users, int numberOfReads) where T : User
	{
		for (var index = 0; index < numberOfReads; ++index)
		{
			var randomId = Random.Shared.Next(1, UserGenerator.LastUsedIndex + 1);
			_ = users[randomId];
		}
	}
}
