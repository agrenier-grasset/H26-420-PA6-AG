using System;

class Chat : Animal
{
    public Chat(string nom) : base(nom) { }

    public override void FaireSon()
    {
        Console.WriteLine($"{Nom} : Miaou !");
    }
}
