using System;

class Chien : Animal
{
    public Chien(string nom) : base(nom) { }

    public override void FaireSon()
    {
        Console.WriteLine($"{Nom} : Wouf !");
    }
}
