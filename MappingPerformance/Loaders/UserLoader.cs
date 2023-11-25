using MappingPerformance.Loaders.Generators;
using MappingPerformance.Models;

namespace MappingPerformance.Loaders;

internal static class UserLoader
{
	internal static IEnumerable<User> Load(int size) => LoadData(size, UserGenerator.Get);

	internal static IEnumerable<ExtendedUser> LoadExtended(int size) => LoadData(size, UserGenerator.GetExtended);

	private static IEnumerable<T> LoadData<T>(int size, Func<T> feeder)
	{
		var data = new HashSet<T>();
		while (data.Count < size)
		{
			data.Add(feeder());
		}
		return data;
	}
}
