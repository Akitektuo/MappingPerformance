using MappingPerformance.Loaders.Sources;
using System.Text;

namespace MappingPerformance.Loaders.Generators;

internal static class PrimitiveGenerator
{
	internal static int GetNextId(this int lastId) => ++lastId;

	internal static Guid GetExternalId() => Guid.NewGuid();

	internal static string GetString(Range range)
	{
		var randomLength = (int)Random.Shared.NextInt64(range.Start.Value, range.End.Value + 1);

		var stringBuilder = new StringBuilder(randomLength);
		for (int index = 0; index < randomLength; ++index)
		{
			stringBuilder.Append(GetCharacter());
		}
		return stringBuilder.ToString();
	}

	internal static char GetCharacter() => 
		BasicSource.AllCharacters[Random.Shared.Next(BasicSource.AllCharacters.Length)];

	internal static DateTime GetDateTime() => new(Random.Shared.NextInt64(DateTime.MaxValue.Ticks));
}
