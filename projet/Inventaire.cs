public class Inventaire
{
    public Dictionary<string, int> SemisPossedes = new(); // Semis possédés dans notre inventaire
    public Dictionary<string, int> PlantesRecoltees = new(); // Plantes possédées dans notre inventaire
    public int Argent;
    
    public Inventaire(int dimension, int nbTerrains) // Argent proportionnel au nombre de terrain(s) et à leur dimension
    {
        Argent = dimension * nbTerrains; // Terrain 1x1 = 1 argent - Terrain 2x2 = 2 argent - 2 Terrains 2x2 = 4 argent
    }

    public void AjouterSemis(string nomPlante, int quantite) // Ajouter un semis à notre inventaire quand on achète/récolte
    {
        if (SemisPossedes.ContainsKey(nomPlante))
            SemisPossedes[nomPlante] += quantite;
        else
            SemisPossedes[nomPlante] = quantite;
    }

    public void AjouterPlanteRecoltee(string nomPlante) // Ajouter une plante à notre inventaire quand on récolte
    {
        if (PlantesRecoltees.ContainsKey(nomPlante))
            PlantesRecoltees[nomPlante]++;
        else
            PlantesRecoltees[nomPlante] = 1;
    }

    public bool PossedeSemis(string nomPlante) // Afficher les semis que l'on possède
    {
        return SemisPossedes.ContainsKey(nomPlante) && SemisPossedes[nomPlante] > 0;
    }

    public void RetirerSemis(string nomPlante, int quantite = 1) // Enlever semis de l'inventaire quand on sème/vend
    {
        if (PossedeSemis(nomPlante))
        {
            SemisPossedes[nomPlante] -= quantite;
            if (SemisPossedes[nomPlante] <= 0)
                SemisPossedes.Remove(nomPlante);
        }
    }

    public void AfficherInventaire() // Afficher notre inventaire
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