namespace JusTechRun.Api.Domain;

public class Interaction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
    public string Channel { get; set; } = "system"; // email, call, note, api
    public string Summary { get; set; } = string.Empty;
    public string EnteredBy { get; set; } = "system";
}
