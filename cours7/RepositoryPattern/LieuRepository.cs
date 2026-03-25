namespace cours7.RepositoryPattern;

public class LieuRepository : RepositoryBase<Lieu>
{
    public LieuRepository(string connectionString) : base(connectionString)
    {
    }

    public override IEnumerable<Lieu> GetAll()
    {
        return WithConnection(conn =>
        {
            //code à faire pour récupérer tous les lieux de la base de données
            return new List<Lieu>();
        });
    }

    public override Lieu? GetById(int id)
    {
        return WithConnection(conn =>
        {
            //code à faire pour récupérer un lieu par son id de la base de données
            return new Lieu();
        });
    }

    public override int Add(Lieu entity)
    {
        return WithConnection(conn =>
        {
            //code à faire pour ajouter un lieu à la base de données et retourner son id
            return 0;
        });
    }

    public override bool Update(Lieu entity)
    {
        return WithConnection(conn =>
        {
            //code à faire pour mettre à jour un lieu dans la base de données
            return false;
        });
    }

    public override bool Delete(int id)
    {
        return WithConnection(conn =>
        {
            //code à faire pour supprimer un lieu de la base de données par son id
            return false;
        });
    }
}
