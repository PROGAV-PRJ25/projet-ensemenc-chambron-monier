public class Terrain
{
    int Largeur;
    int Hauteur;
    public string TypeTerrain;
    public Parcelle[,] Grille;
    List<Plante> ListePlantes;
    public int QttEau;
    public Terrain(int dimension, string typeTerrain)
    {
        this.Largeur = dimension;
        this.Hauteur = dimension;
        this.TypeTerrain = typeTerrain;
        QttEau = 0;
        Grille = new Parcelle[Largeur, Hauteur];
        for (int i = 0; i < Largeur; i++)
        {
            for (int j = 0; j < Hauteur; j++)
            {
                Grille[i, j] = new Parcelle();
            }
        }
    }
    public void Desherber()
    {
        Console.WriteLine("Vous souhaitez désherber la parcelle (x,y).");
        int x;
        do
        {
            Console.Write("x : ");
        }
        while (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x >= Largeur);
        int y;
        do
        {
            Console.Write("y : ");
        }
        while (!int.TryParse(Console.ReadLine(), out y) || y < 0 || y >= Hauteur);
        Console.WriteLine("-> Désherbage effectué.");
    }

    public void Pailler()
    {
        Console.WriteLine("-> Paillage ajouté.");
    }

    public void Arroser()
    {
        Console.WriteLine("Vous souhaitez arroser la parcelle (x,y).");
        int x;
        do
        {
            Console.Write("x : ");
        }
        while (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x >= Largeur);
        int y;
        do
        {
            Console.Write("y : ");
        }
        while (!int.TryParse(Console.ReadLine(), out y) || y < 0 || y >= Hauteur);
        if (Grille[x,y].Eau >= 9)
        {
            Console.WriteLine("Le terrain est déjà imbibé d'eau ! Vous ne pouvez pas rajouter d'eau !");
        }
        else
        {
            int AjoutEau;
            do
            {
                Console.Write("Combien ajouter de litre(s) d'eau (1-10) : ");
            }
            while (!int.TryParse(Console.ReadLine(), out AjoutEau) || AjoutEau < 0 || AjoutEau > 10);
            Grille[x,y].Eau += AjoutEau;
            if (Grille[x,y].Eau > 9)
            {
                Grille[x,y].Eau = 9;
                Console.WriteLine("Vous avez trop arrosé le terrain, il ne peut pas contenir toute cette eau ! (max 9L/m²)");
            }
            Console.WriteLine("-> Arrosage effectué.");
        }
        Afficher();
    }

    public void Traiter()
    {
        Console.WriteLine("-> Traitement appliqué (90% chance).");
    }

    public void Semer(Inventaire inventaire)
    {
        var semisDisponibles = inventaire.SemisPossedes
            .Where(kv => kv.Value > 0)
            .Select(kv => CataloguePlantes.GetPlanteParNom(kv.Key))
            .Where(p => p != null && p.TerrainPrefere == TypeTerrain)
            .ToList();

        if (semisDisponibles.Count == 0)
        {
            Console.WriteLine("⛔ Aucun semis compatible avec ce terrain !");
            return;
        }

        Console.WriteLine("🌱 Semis disponibles à planter :");
        for (int i = 0; i < semisDisponibles.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {semisDisponibles[i]!.NomPlante}");
        }

        int choix;
        do
        {
            Console.Write("Choisissez une plante à semer : ");
        } while (!int.TryParse(Console.ReadLine(), out choix) || choix <= 0 || choix > semisDisponibles.Count);

        var planteChoisie = semisDisponibles[choix - 1]!;

        int x, y;
        do { Console.Write("x : "); } while (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x >= Largeur);
        do { Console.Write("y : "); } while (!int.TryParse(Console.ReadLine(), out y) || y < 0 || y >= Hauteur);

        if (Grille[x, y].Plante != null)
        {
            Console.WriteLine("⛔ Une plante est déjà présente ici !");
            return;
        }

        Grille[x, y].Plante = planteChoisie;
        inventaire.RetirerSemis(planteChoisie.NomPlante);
        Console.WriteLine($"✅ {planteChoisie.NomPlante} semée en ({x},{y}) !");
    }

    public void Recolter()
    {
        Console.WriteLine("-> Récolte effectuée.");
    }

    public void InstallerSerre()
    {
        Console.WriteLine("-> Serre installée.");
    }

    public void InstallerBarriere()
    {
        Console.WriteLine("-> Barrière installée.");
    }

    public void InstallerPareSoleil()
    {
        Console.WriteLine("-> Pare-soleil installé.");
    }
    public void PlanterPlante(Plante plante, int x, int y)
    {
        if (x >= 0 && x < Largeur && y >= 0 && y < Hauteur)
        {
            Grille[x, y].Plante = plante;
        }
    }
    public void AllerAuMagasin(Inventaire inventaire)
    {
        Console.Clear();
        Console.WriteLine("🏪 BIENVENUE AU MAGASIN 🏪");
        inventaire.AfficherInventaire();
        Console.WriteLine("\nPlantes disponibles à l'achat :");

        var plantes = CataloguePlantes.PlantesDisponibles;
        for (int i = 0; i < plantes.Count; i++)
        {
            var p = plantes[i];
            Console.WriteLine($"{i + 1}. {p.NomPlante} - {p.PrixAchatSemis}⛁");
        }

        Console.Write("Choisissez une plante à acheter (0 pour quitter) : ");
        if (int.TryParse(Console.ReadLine(), out int choix) && choix > 0 && choix <= plantes.Count)
        {
            var plante = plantes[choix - 1];
            if (inventaire.Argent >= plante.PrixAchatSemis)
            {
                inventaire.Argent -= plante.PrixAchatSemis;
                inventaire.AjouterSemis(plante.NomPlante, 1);
                Console.WriteLine($"=> Achat de 1 {plante.NomPlante} réussi !");
            }
            else
            {
                Console.WriteLine("⛔ Pas assez d'argent !");
            }
        }
        else
        {
            Console.WriteLine("Retour...");
        }
    }

public void Afficher()
{
    // Affichage des indices de colonnes
    Console.Write("    "); // Espace pour l’index des lignes
    for (int x = 0; x < Largeur; x++)
        Console.Write($"  {x}  ");
    Console.WriteLine();

    for (int y = 0; y < Hauteur; y++)
    {
        // Ligne bordure du haut
        Console.Write("   +");
        for (int x = 0; x < Largeur; x++)
            Console.Write("----+");
        Console.WriteLine();

        // Ligne plante + stade
        Console.Write($" {y} |");
        for (int x = 0; x < Largeur; x++)
            Console.Write($" {Grille[x, y].LigneHaut(),-2} |");
        Console.WriteLine();

        // Ligne lumière + eau
        Console.Write("   |");
        for (int x = 0; x < Largeur; x++)
            Console.Write($" {Grille[x, y].LigneBas(),-2} |");
        Console.WriteLine();
    }

    // Dernière ligne de bordure en bas
    Console.Write("   +");
    for (int x = 0; x < Largeur; x++)
        Console.Write("----+");
    Console.WriteLine();
    }
}