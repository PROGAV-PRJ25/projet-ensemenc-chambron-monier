public class Inventaire
{
    public Dictionary<string, int> SemisPossedes = new();
    public Dictionary<string, int> PlantesRecoltees = new();
    public int Argent;
    public Inventaire(int dimension, int nbTerrains)
    {
        Argent = dimension * nbTerrains;
    }
    public void AjouterSemis(string nomPlante, int quantite)
    {
        if (SemisPossedes.ContainsKey(nomPlante))
            SemisPossedes[nomPlante] += quantite;
        else
            SemisPossedes[nomPlante] = quantite;
    }

    public void AjouterPlanteRecoltee(string nomPlante)
    {
        if (PlantesRecoltees.ContainsKey(nomPlante))
            PlantesRecoltees[nomPlante]++;
        else
            PlantesRecoltees[nomPlante] = 1;
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
        // Argent
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("╔════════════════════════════════╗");
        Console.Write("║ 💰 Argent disponible : ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"{Argent.ToString("D4")} ⛁ ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" ║");
        Console.WriteLine("╚════════════════════════════════╝");
        Console.ResetColor();

        // Semis
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("🌱 Semis en stock :");
        Console.ResetColor();

        if (SemisPossedes.Count == 0)
        {
            Console.WriteLine("  (aucun semis)");
        }
        else
        {
            foreach (var semis in SemisPossedes)
            {
                Console.WriteLine($"  - {semis.Key} x{semis.Value}");
            }
        }

        Console.WriteLine();

        // Plantes récoltées
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("🌸 Plantes récoltées :");
        Console.ResetColor();

        if (PlantesRecoltees.Count == 0)
        {
            Console.WriteLine("  (aucune plante récoltée)");
        }
        else
        {
            foreach (var plante in PlantesRecoltees)
            {
                Console.WriteLine($"  - {plante.Key} x{plante.Value}");
            }
        }

        Console.WriteLine();
    }

}