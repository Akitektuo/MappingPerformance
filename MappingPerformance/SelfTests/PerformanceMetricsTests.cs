using MappingPerformance.Loaders;
using MappingPerformance.Loaders.Generators;
using MappingPerformance.Metrics;

namespace MappingPerformance.SelfTests;

public class PerformanceMetricsTests
{
	[Test]
	public void SingleSession_Loading1MillionUsers()
	{
		var metrics = new PerformanceMetrics();
		metrics.Start();

		UserLoader.Load(BigNumber.Millions(1));

		metrics.Stop();
		Assert.Pass(metrics.GetResults());
	}

	[Test]
	public void SingleSession_Loading1MillionExtendedUsers()
	{
		var metrics = new PerformanceMetrics();
		metrics.Start();

		UserLoader.LoadExtended(BigNumber.Millions(1));

		metrics.Stop();
		Assert.Pass(metrics.GetResults());
	}

	[Test]
	public void SingleSession_Loading25MillionUsers()
	{
		var metrics = new PerformanceMetrics();
		metrics.Start();

		UserLoader.Load(BigNumber.Millions(25));

		metrics.Stop();
		Assert.Pass(metrics.GetResults());
	}

	[Test]
	public void SingleSession_Loading25MillionExtendedUsers()
	{
		var metrics = new PerformanceMetrics();
		metrics.Start();

		UserLoader.LoadExtended(BigNumber.Millions(25));

		metrics.Stop();
		Assert.Pass(metrics.GetResults());
	}


	[Test]
	public void DoubleSession_Loading1MillionUsers()
	{
		var metrics = new PerformanceMetrics();
		var resultBuilder = new MetricsFormatter();
		metrics.Start();

		UserLoader.Load(BigNumber.Millions(1));

		metrics.Stop();
		resultBuilder.AddMetricsResult(metrics.GetResults(), "Load of 1 Million Users");

		metrics.Start();

		UserLoader.LoadExtended(BigNumber.Millions(1));

		metrics.Stop();
		resultBuilder.AddMetricsResult(metrics.GetResults(), "Load of 1 Million Extended Users");
		resultBuilder.PrintTestResults();
	}
}
