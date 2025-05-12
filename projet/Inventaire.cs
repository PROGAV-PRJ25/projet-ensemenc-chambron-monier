public class Inventaire
{
    public Dictionary<string, int> SemisPossedes = new();
    public double Argent = 10;

    public void AjouterSemis(string nomPlante, int quantite)
    {
        if (SemisPossedes.ContainsKey(nomPlante))
            SemisPossedes[nomPlante] += quantite;
        else
            SemisPossedes[nomPlante] = quantite;
    }

    public bool PossedeSemis(string nomPlante)
    {
        return SemisPossedes.ContainsKey(nomPlante) && SemisPossedes[nomPlante] > 0;
    }

    public void RetirerSemis(string nomPlante, int quantite = 1)
    {
        if (PossedeSemis(nomPlante))
        {
            SemisPossedes[nomPlante] -= quantite;
            if (SemisPossedes[nomPlante] <= 0)
                SemisPossedes.Remove(nomPlante);
        }
    }

    public void AfficherInventaire()
    {
        Console.WriteLine($"Argent : {Argent} ⛁");
        Console.WriteLine("Semis en stock :");
        if (SemisPossedes.Count == 0)
        {
            Console.WriteLine("  (aucun semis)");
            return;
        }
        foreach (var semis in SemisPossedes)
        {
            Console.WriteLine($"  - {semis.Key} x{semis.Value}");
        }
    }
}