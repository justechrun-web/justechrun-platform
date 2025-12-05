using JusTechRun.Api.Domain;

namespace JusTechRun.Api.Services;

public interface ICrmService
{
    IReadOnlyCollection<Client> GetClients();
    Client? GetClient(Guid id);ausing JusTechRun.Api.Domain;

namespace JusTechRun.Api.Services;

public class CrmService : ICrmService
{
    private readonly List<Client> _clients = new();

    public CrmService()
    {
        // Seed with one example client (so Swagger isn't empty)
        _clients.Add(new Client
        {
            LegalName = "Tru Private Bank Estate & Trust",
            Email = "contact@example.com",
            EntityType = "Trust",
            IsHighRisk = false
        });
    }

    public IReadOnlyCollection<Client> GetClients() => _clients;

    public Client? GetClient(Guid id) => _clients.SingleOrDefault(c => c.Id == id);

    public void AddClient(Client client)
    {
        if (string.IsNullOrWhiteSpace(client.LegalName))
            throw new ArgumentException("Client legal name is required.");

        _clients.Add(client);
    }

    public void AddInteraction(Guid clientId, Interaction interaction)
    {
        var client = GetClient(clientId);
        if (client is null)
            throw new InvalidOperationException("Client not found.");

        client.Interactions.Add(interaction);
    }
}

    void AddClient(Client client);
    void AddInteraction(Guid clientId, Interaction interaction);
}
