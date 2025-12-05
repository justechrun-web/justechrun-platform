namespace JusTechRun.Api.Tokenization;

public class TokenizedAsset
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UnderlyingName { get; set; } = string.Empty; // e.g. "SPV Revenue Stream A"
    public string UnderlyingType { get; set; } = string.Empty; // "RevenueShare", "Note", "Equity"
    public decimal NotionalValue { get; set; }
    public string Currency { get; set; } = "USD";
    public string Jurisdiction { get; set; } = "US-DE";
    public bool IsCompliant { get; set; } = false;
}
