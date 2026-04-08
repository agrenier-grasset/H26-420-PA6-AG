namespace cours10;

public class ClientService
{
    private readonly IClientRepository _repository;
    private readonly EmailPolicyService _emailPolicy;

    public ClientService(IClientRepository repository, EmailPolicyService emailPolicy)
    {
        _repository  = repository;
        _emailPolicy = emailPolicy;
    }

    // ===== Exercice 2 =====

    public void Validate(Client c)
    {
        if (string.IsNullOrWhiteSpace(c.Nom))
            throw new ArgumentException("Le nom ne peut pas être vide.");
        _emailPolicy.Validate(c.Email);
    }

    public string GetClientInfo(Client c) => $"Nom : {c.Nom}, Email : {c.Email}";

    // ===== Exercice 3 =====

    public List<Client> ListClients()      => _repository.GetAll();
    public Client?      FindClient(int id) => _repository.GetById(id);

    public void AddClient(Client c)
    {
        Validate(c);
        _repository.Add(c);
    }

    // ===== Exercice 4 =====

    public void AddClient(string nom, string email) =>
        AddClient(new Client { Nom = nom, Email = email });

    public Client?      GetClientById(int id) => FindClient(id);
    public List<Client> GetAllClients()       => ListClients();
}
