namespace JusTechRun.Api.Tokenization;

public class TokenizationResult
{
    public bool IsValid => !Errors.Any();
    public List<string> Errors { get; } = new();
}
