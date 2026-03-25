using System.Collections;

public class Chaine<T> : IEnumerable<T>
{
    private Noeud? _tete;
    private Noeud? _queue;

    public void Ajouter(T valeur)
    {
        Noeud nouveau = new Noeud(valeur);

        if (_tete is null)
        {
            _tete = nouveau;
            _queue = nouveau;
            return;
        }

        _queue!.Suivant = nouveau;
        _queue = nouveau;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Noeud? courant = _tete;
        while (courant is not null)
        {
            yield return courant.Valeur;
            courant = courant.Suivant;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private sealed class Noeud
    {
        public Noeud(T valeur)
        {
            Valeur = valeur;
        }

        public T Valeur { get; }
        public Noeud? Suivant { get; set; }
    }
}
