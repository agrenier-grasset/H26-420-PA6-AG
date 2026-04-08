namespace cours10;

public interface IClientRepository
{
    List<Client> GetAll();
    Client? GetById(int id);
    void Add(Client c);
}
