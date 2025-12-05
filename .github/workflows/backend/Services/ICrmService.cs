using JusTechRun.Api.Domain;

namespace JusTechRun.Api.Services;

public interface ICrmService
{
    IReadOnlyCollection<Client> GetClients();
    Client? GetClient(Guid id);
    void AddClient(Client client);
    void AddInteraction(Guid clientId, Interaction interaction);
}
