using MappingPerformance.Loaders;
using MappingPerformance.Loaders.Generators;

namespace MappingPerformance.SelfTests;

public class LoadTests
{
    [Test]
    public void Load1ThousandUsers()
    {
        var users = UserLoader.Load(BigNumber.Thousands(1));

        Assert.That(users, Has.Exactly(BigNumber.Thousands(1)).Items);
    }

	[Test]
	public void Load1ThousandExtendedUsers()
	{
		var users = UserLoader.LoadExtended(BigNumber.Thousands(1));

		Assert.That(users, Has.Exactly(BigNumber.Thousands(1)).Items);
	}

	[Test]
	public void Load1MillionUsers()
	{
		var users = UserLoader.Load(BigNumber.Millions(1));

		Assert.That(users, Has.Exactly(BigNumber.Millions(1)).Items);
	}

	[Test]
	public void Load1MillionExtendedUsers()
	{
		var users = UserLoader.LoadExtended(BigNumber.Millions(1));

		Assert.That(users, Has.Exactly(BigNumber.Millions(1)).Items);
	}

	[Test]
	public void Load25MillionUsers()
	{
		var users = UserLoader.Load(BigNumber.Millions(25));

		Assert.That(users, Has.Exactly(BigNumber.Millions(25)).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 24 GB of RAM to generate this many extended users and will take ~3-4 minutes.
	public void Load25MillionExtendedUsers()
	{
		var users = UserLoader.LoadExtended(BigNumber.Millions(25));

		Assert.That(users, Has.Exactly(BigNumber.Millions(25)).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 16 GB of RAM to generate this many users and will take ~1-2 minutes.
	public void Load50MillionUsers()
	{
		var users = UserLoader.Load(BigNumber.Millions(50));

		Assert.That(users, Has.Exactly(BigNumber.Millions(50)).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 48 GB of RAM to generate this many extended users and will take ~5-7 minutes.
	public void Load50MillionExtendedUsers()
	{
		var users = UserLoader.LoadExtended(BigNumber.Millions(50));

		Assert.That(users, Has.Exactly(BigNumber.Millions(50)).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 32 GB of RAM to generate this many users and will take ~2-3 minutes.
	public void Load100MillionUsers()
	{
		var users = UserLoader.Load(BigNumber.Millions(100));

		Assert.That(users, Has.Exactly(BigNumber.Millions(100)).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 96 GB of RAM to generate this many extended users and will take ~12-15 minutes.
	public void Load100MillionExtendedUsers()
	{
		var users = UserLoader.LoadExtended(BigNumber.Millions(100));

		Assert.That(users, Has.Exactly(BigNumber.Millions(100)).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 128 GB of RAM to generate this many users and will take ~15-17 minutes.
	public void Load500MillionUsers()
	{
		var users = UserLoader.Load(BigNumber.Millions(500));

		Assert.That(users, Has.Exactly(BigNumber.Millions(500)).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 384 GB of RAM to generate this many extended users and will take ~45-50 minutes.
	public void Load500MillionExtendedUsers()
	{
		var users = UserLoader.LoadExtended(BigNumber.Millions(500));

		Assert.That(users, Has.Exactly(BigNumber.Millions(500)).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 256 GB of RAM to generate this many users and will take ~30-35 minutes.
	public void Load1BillionUsers()
	{
		var users = UserLoader.Load(BigNumber.Billions(1));

		Assert.That(users, Has.Exactly(BigNumber.Billions(1)).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 768 GB of RAM to generate this many extended users and will take ~90-100 minutes.
	public void Load1BillionExtendedUsers()
	{
		var users = UserLoader.LoadExtended(BigNumber.Billions(1));

		Assert.That(users, Has.Exactly(BigNumber.Billions(1)).Items);
	}
}