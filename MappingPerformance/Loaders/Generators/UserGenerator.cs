using MappingPerformance.Models;

namespace MappingPerformance.Loaders.Generators;

internal static class UserGenerator
{
	internal static int LastUsedIndex { get; private set; }

	internal static User Get() => new()
	{
		Id = LastUsedIndex = LastUsedIndex.GetNextId(),
		ExternalId = PrimitiveGenerator.GetExternalId(),
		UserName = PrimitiveGenerator.GetString(Settings.UserNameLength)
	};

	internal static ExtendedUser GetExtended() => new()
	{
		Id = LastUsedIndex = LastUsedIndex.GetNextId(),
		ExternalId = PrimitiveGenerator.GetExternalId(),
		UserName = PrimitiveGenerator.GetString(Settings.UserNameLength),
		FirstName = PrimitiveGenerator.GetString(Settings.FirstNameLength),
		LastName = PrimitiveGenerator.GetString(Settings.LastNameLength),
		BirthDate = PrimitiveGenerator.GetDateTime(),
		Email = PrimitiveGenerator.GetString(Settings.EmailLength),
		Password = PrimitiveGenerator.GetString(Settings.PasswordlLength)
	};
}
