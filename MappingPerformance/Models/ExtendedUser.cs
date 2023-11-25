namespace MappingPerformance.Models;

internal class ExtendedUser : User
{
	public string FirstName { get; set; } = null!;

	public string LastName { get; set; } = null!;

	public DateTime BirthDate { get; set; }

	public string Email { get; set; } = null!;

	public string Password { get; set; } = null!;
}
