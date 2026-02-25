abstract class Animal
{
    public string Nom { get; set; }

    public Animal(string nom)
    {
        Nom = nom;
    }

    public abstract void FaireSon();
}
