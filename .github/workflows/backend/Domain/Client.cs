namespace JusTechRun.Api.Domain;

public class Client
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string LegalName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string EntityType { get; set; } = string.Empty; // e.g. "SPV", "Trust", "Ministry", "OperatingCo"
    public bool IsHighRisk { get; set; }
    public List<Interaction> Interactions { get; set; } = new();
}
