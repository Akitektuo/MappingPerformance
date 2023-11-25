using MappingPerformance.Loaders;

namespace MappingPerformance.SelfTests;

public class LoadTests
{
    [Test]
    public void Load1ThousandUsers()
    {
        var users = UserLoader.Load(1000);

        Assert.That(users, Has.Exactly(1000).Items);
    }

	[Test]
	public void Load1ThousandExtendedUsers()
	{
		var users = UserLoader.LoadExtended(1000);

		Assert.That(users, Has.Exactly(1000).Items);
	}

	[Test]
	public void Load1MillionUsers()
	{
		var users = UserLoader.Load(1000000);

		Assert.That(users, Has.Exactly(1000000).Items);
	}

	[Test]
	public void Load1MillionExtendedUsers()
	{
		var users = UserLoader.LoadExtended(1000000);

		Assert.That(users, Has.Exactly(1000000).Items);
	}

	[Test]
	public void Load25MillionUsers()
	{
		var users = UserLoader.Load(25000000);

		Assert.That(users, Has.Exactly(25000000).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 24 GB of RAM to generate this many extended users and will take ~3-4 minutes.
	public void Load25MillionExtendedUsers()
	{
		var users = UserLoader.LoadExtended(25000000);

		Assert.That(users, Has.Exactly(25000000).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 16 GB of RAM to generate this many users and will take ~1-2 minutes.
	public void Load50MillionUsers()
	{
		var users = UserLoader.Load(50000000);

		Assert.That(users, Has.Exactly(50000000).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 48 GB of RAM to generate this many extended users and will take ~5-7 minutes.
	public void Load50MillionExtendedUsers()
	{
		var users = UserLoader.LoadExtended(50000000);

		Assert.That(users, Has.Exactly(50000000).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 32 GB of RAM to generate this many users and will take ~2-3 minutes.
	public void Load100MillionUsers()
	{
		var users = UserLoader.Load(100000000);

		Assert.That(users, Has.Exactly(100000000).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 96 GB of RAM to generate this many extended users and will take ~12-15 minutes.
	public void Load100MillionExtendedUsers()
	{
		var users = UserLoader.LoadExtended(100000000);

		Assert.That(users, Has.Exactly(100000000).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 128 GB of RAM to generate this many users and will take ~15-17 minutes.
	public void Load500MillionUsers()
	{
		var users = UserLoader.Load(500000000);

		Assert.That(users, Has.Exactly(500000000).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 384 GB of RAM to generate this many extended users and will take ~45-50 minutes.
	public void Load500MillionExtendedUsers()
	{
		var users = UserLoader.LoadExtended(500000000);

		Assert.That(users, Has.Exactly(500000000).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 256 GB of RAM to generate this many users and will take ~30-35 minutes.
	public void Load1BillionUsers()
	{
		var users = UserLoader.Load(1000000000);

		Assert.That(users, Has.Exactly(1000000000).Items);
	}

	[Test]
	/// !DISCLAIMER!
	/// The system needs at least 768 GB of RAM to generate this many extended users and will take ~90-100 minutes.
	public void Load1BillionExtendedUsers()
	{
		var users = UserLoader.LoadExtended(1000000000);

		Assert.That(users, Has.Exactly(1000000000).Items);
	}
}