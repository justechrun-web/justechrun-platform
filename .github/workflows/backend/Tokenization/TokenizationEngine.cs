using System.Text.RegularExpressions;

namespace JusTechRun.Api.Tokenization;

public class TokenizationEngine
{
    private readonly List<TokenizedAsset> _assets = new();

    public IReadOnlyCollection<TokenizedAsset> GetRegisteredAssets() => _assets;

    public TokenizationResult RegisterAsset(TokenizedAsset asset)
    {
        var result = Validate(asset);
        if (!result.IsValid) return result;

        asset.IsCompliant = true; // later: tie to real rules / jurisdictions
        _assets.Add(asset);

        return result;
    }

    private TokenizationResult Validate(TokenizedAsset asset)
    {
        var result = new TokenizationResult();

        if (string.IsNullOrWhiteSpace(asset.UnderlyingName))
            result.Errors.Add("UnderlyingName is required.");

        if (asset.NotionalValue <= 0)
            result.Errors.Add("NotionalValue must be positive.");

        if (!Regex.IsMatch(asset.Currency, "^[A-Z]{3}$"))
            result.Errors.Add("Currency must be a 3-letter ISO code (e.g. USD).");

        if (string.IsNullOrWhiteSpace(asset.UnderlyingType))
            result.Errors.Add("UnderlyingType is required.");

        // Placeholder jurisdiction check
        if (!asset.Jurisdiction.StartsWith("US-"))
            result.Errors.Add("Currently only US-* jurisdictions are supported in this engine prototype.");

        return result;
    }
}
