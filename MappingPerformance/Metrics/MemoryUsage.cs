using System.Diagnostics;

namespace MappingPerformance.Metrics;

internal static class MemoryUsage
{
	private readonly static Process process = Process.GetCurrentProcess();
	private const int MegaBytesInBytes = 1048576;
	private readonly static List<Action<long>> listeners = new();
	private static bool started = false;

	internal static long LatestRead { get; private set; } = 0;

	internal static async void Start()
	{
		if (started)
		{
			return;
		}
		started = true;

		await ReadUsageEachSecond();
	}

	internal static Action Subscribe(Action<long> consumer)
	{
		listeners.Add(consumer);

		return () => listeners.Remove(consumer);
	}

	private static async Task ReadUsageEachSecond()
	{
		while (true)
		{
			process.Refresh();
			var processMemory = process.PagedMemorySize64 / MegaBytesInBytes;

			LatestRead = processMemory;
			listeners.ForEach(consumer => consumer(processMemory));

			await Task.Delay(TimeSpan.FromSeconds(1));
		}
	}
}
