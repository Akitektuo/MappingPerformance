using System.Text;

namespace MappingPerformance.Metrics;

internal class MetricsFormatter
{
	private readonly StringBuilder results = new();

	public void AddMetricsResult(string result, string subject) => 
		results.Append($"\t{subject}\n{result}\n\n");

	public void PrintTestResults() => Assert.Pass(results.ToString());
}
