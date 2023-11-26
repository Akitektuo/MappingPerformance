namespace MappingPerformance.Loaders.Generators;

internal static class BigNumber
{
	internal static int Thousands(int thousand) => thousand * 1000;

	internal static int Millions(int million) => million * 1000000;

	internal static int Billions(int billion) => billion * 1000000000;
}
