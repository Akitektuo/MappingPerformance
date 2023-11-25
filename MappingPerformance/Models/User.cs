namespace MappingPerformance.Models;

internal class User
{
	public int Id { get; set; }

	public Guid ExternalId { get; set; }

	public string UserName { get; set; } = null!;
}
