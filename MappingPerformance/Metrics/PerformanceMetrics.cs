using System.Diagnostics;

namespace MappingPerformance.Metrics;

internal class PerformanceMetrics
{
	private readonly Stopwatch stopwatch = new();
	private Action? memoryUsageUnsubscriber;
	private readonly List<long> memoryReadings = new();

	public PerformanceMetrics()
	{
		MemoryUsage.Start();
	}

	internal void Start()
	{
		if (stopwatch.IsRunning)
		{
			throw new InvalidOperationException("This instance of the service is already running, use restart instead.");
		}
		stopwatch.Restart();
		memoryReadings.Clear();
		memoryUsageUnsubscriber = MemoryUsage.Subscribe(memoryReadings.Add);
	}

	internal void Stop()
	{
		stopwatch.Stop();
		memoryUsageUnsubscriber?.Invoke();
	}

	internal void Restart()
	{
		Stop();
		Start();
	}

	internal string GetResults()
	{
		if (stopwatch.IsRunning)
		{
			throw new InconclusiveException("The metrics should be stopped before getting the results.");
		}

		var (averageMemory, maximumMemory) = GetMemoryAverageAndMaximumValues();
		return $"Execution time: {stopwatch.Elapsed}\nAverage memory: {FormatMemoryUsage(averageMemory)}\nPeeked memory: {FormatMemoryUsage(maximumMemory)}";
	}

	private (long, long) GetMemoryAverageAndMaximumValues()
	{
		var totalSum = 0L;
		var maximum = 0L;
		memoryReadings.ForEach(reading => 
		{
			totalSum += reading;
			if (reading > maximum)
			{
				maximum = reading;
			}
		});

		var average = memoryReadings.Count == 0 ? 0 : totalSum / memoryReadings.Count;
		return (average, maximum);
	}

	private static string FormatMemoryUsage(long memory)
	{
        if (memory == 0)
        {
			return $"{MemoryUsage.LatestRead:N0} MB";
		}
        return $"{memory:N0} MB";
	}
}
