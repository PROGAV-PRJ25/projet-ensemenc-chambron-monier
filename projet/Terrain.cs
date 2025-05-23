public class Terrain
{
    int Largeur;
    int Hauteur;
    public string TypeTerrain;
    public Parcelle[,] Grille;
    //List<Plante> ?ListePlantes; // SERT PLUS A RIEN MAIS JE LAISSE AU CAS OU
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

    public void AppliquerMeteo(Meteo meteo)
    {
        for (int x = 0; x < Largeur; x++)
        {
            for (int y = 0; y < Hauteur; y++)
            {
                Grille[x, y].Luminosite = (int)meteo.Luminosite;

                // Simulation simple : 1 mm de pluie = 0.1 L d'eau, à ajuster selon ton équilibre
                Grille[x, y].Eau = 0;
                int ajoutEau = (int)(meteo.Precipitations * 0.1f);
                Grille[x, y].Eau += ajoutEau;

                // Limiter à 9 L max par m²
                if (Grille[x, y].Eau > 9)
                    Grille[x, y].Eau = 9;
            }
        }
    }

    private (int x, int y)? TrouverOrigine(int x, int y)
    {
        for (int dx = -1; dx <= 0; dx++)
        {
            for (int dy = -1; dy <= 0; dy++)
            {
                int nx = x + dx;
                int ny = y + dy;
                if (nx >= 0 && ny >= 0 && nx < Largeur && ny < Hauteur)
                {
                    var caseTest = Grille[nx, ny];
                    if (caseTest.Plante == Grille[x, y].Plante && caseTest.EstOrigine)
                    {
                        return (nx, ny);
                    }
                }
            }
        }
        return null;
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
        // Si ce n’est pas l’origine, on cherche l’origine
        if (Grille[x, y].Plante != null && !Grille[x, y].EstOrigine)
        {
            var origine = TrouverOrigine(x, y);
            if (origine != null)
            {
                x = origine.Value.x;
                y = origine.Value.y;
            }
        }

        // Supprimer la plante sur toutes les cases occupées
        if (Grille[x, y].Plante != null)
        {
            int taille = Grille[x, y].Plante!.Largeur;
            for (int dx = 0; dx < taille; dx++)
            {
                for (int dy = 0; dy < taille; dy++)
                {
                    Grille[x + dx, y + dy].Plante = null;
                    Grille[x + dx, y + dy].EstOrigine = true;
                }
            }
        }
        Console.Clear();
        Console.WriteLine("-> Désherbage effectué.");
    }

    public void Pailler()
    {
        Console.WriteLine("Vous souhaitez pailler la parcelle (x,y).");
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
        if (Grille[x, y].Plante != null && !Grille[x, y].EstOrigine)
        {
            var origine = TrouverOrigine(x, y);
            if (origine != null)
            {
                x = origine.Value.x;
                y = origine.Value.y;
            }
        }
        if (Grille[x, y].Plante != null)
        {
            Grille[x, y].Plante.CroissanceActuelle += Grille[x, y].Plante.VitesseCroissance;
            Console.Clear();
            Console.WriteLine("-> Paillage ajouté.");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("-> Il n'y a pas de plante sur cette parcelle, pourquoi pailler ici ?");
        }
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
        if (Grille[x, y].Plante != null && !Grille[x, y].EstOrigine)
        {
            var origine = TrouverOrigine(x, y);
            if (origine != null)
            {
                x = origine.Value.x;
                y = origine.Value.y;
            }
        }
        if (Grille[x, y].Eau >= 9)
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
            Grille[x, y].Eau += AjoutEau;
            if (Grille[x, y].Eau > 9)
            {
                Grille[x, y].Eau = 9;
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

        // Vérifier que toutes les cases nécessaires sont libres
        bool plante2x2 = planteChoisie.Largeur == 2;
        if (plante2x2)
        {
            if (x + 1 >= Largeur || y + 1 >= Hauteur ||
                Grille[x, y].Plante != null ||
                Grille[x + 1, y].Plante != null ||
                Grille[x, y + 1].Plante != null ||
                Grille[x + 1, y + 1].Plante != null)
            {
                Console.WriteLine("⛔ Pas assez de place pour planter cette plante 2x2 ici !");
                return;
            }
        }
        else
        {
            if (Grille[x, y].Plante != null)
            {
                Console.WriteLine("⛔ Une plante est déjà présente ici !");
                return;
            }
        }

        // Planter
        inventaire.RetirerSemis(planteChoisie.NomPlante);

        // Même instance dans toutes les cases
        if (plante2x2)
        {
            Grille[x, y].Plante = planteChoisie;
            Grille[x, y].EstOrigine = true;

            Grille[x + 1, y].Plante = planteChoisie;
            Grille[x + 1, y].EstOrigine = false;

            Grille[x, y + 1].Plante = planteChoisie;
            Grille[x, y + 1].EstOrigine = false;

            Grille[x + 1, y + 1].Plante = planteChoisie;
            Grille[x + 1, y + 1].EstOrigine = false;
        }
        else
        {
            Grille[x, y].Plante = planteChoisie;
            Grille[x, y].EstOrigine = true;
        }

        Console.Clear();
        Console.WriteLine($"✅ {planteChoisie.NomPlante} semée en ({x},{y}) !");
    }

    public void Recolter(Inventaire inventaire)
    {
        Console.WriteLine("Vous souhaitez récolter une parcelle.");
        
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
        if (Grille[x, y].Plante != null && !Grille[x, y].EstOrigine)
        {
            var origine = TrouverOrigine(x, y);
            if (origine != null)
            {
                x = origine.Value.x;
                y = origine.Value.y;
            }
        }

        Parcelle parcelle = Grille[x, y];

        // Cas 1 : parcelle vide
        if (parcelle.Plante == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("❌ Il n'y a rien à récolter ici.");
            Console.ResetColor();
            return;
        }

        Plante plante = parcelle.Plante;

        // Cas 2 : pas encore mature
        if (plante.CroissanceActuelle < 1.0 || plante.StadeCroissance != 3)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("⚠️  Cette plante n'est pas encore prête à être récoltée !");
            Console.ResetColor();
            return;
        }

        // Cas 3 : plante morte
        if (plante.StadeCroissance == 4)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.WriteLine("☠️  Cette plante est morte et ne peut pas être récoltée.");
            Console.ResetColor();
            return;
        }

        string nom = plante.NomPlante;
        inventaire.AjouterPlanteRecoltee(nom);

        if (plante.EstVivace)
        {
            plante.CroissanceActuelle = 0.0;
            plante.StadeCroissance = 0;
            plante.SemainesDepuisMaturite = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine($"🌿 Vous avez récolté {nom}. Elle repoussera (vivace).");
        }
        else
        {
            Random rnd = new();
            int nbSemis = rnd.Next(1, 4);
            inventaire.AjouterSemis(nom, nbSemis);
            // Supprimer toutes les cases de la plante 2x2
            int taille = plante.Largeur;
            for (int dx = 0; dx < taille; dx++)
            {
                for (int dy = 0; dy < taille; dy++)
                {
                    Grille[x + dx, y + dy].Plante = null;
                    Grille[x + dx, y + dy].EstOrigine = true;
                }
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"🌼 Vous avez récolté {nom}. Elle a été retirée (annuelle).");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"🎁 Vous récupérez {nbSemis} semis de {nom} !");
        }
        Console.ResetColor();
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
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("█████████████████████████████████████████████████████");
        Console.WriteLine("█░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█");
        Console.WriteLine("█░░                                               ░░█");
        Console.WriteLine("█░░         🏪  BIENVENUE AU MAGASIN  🏪          ░░█");
        Console.WriteLine("█░░                                               ░░█");
        Console.WriteLine("█░░      🪴 Achetez, vendez, explorez ! 🪴          ░░█");
        Console.WriteLine("█░░                                               ░░█");
        Console.WriteLine("█░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█");
        Console.WriteLine("█████████████████████████████████████████████████████");
        Console.ResetColor();

        inventaire.AfficherInventaire();

        while (true)
        {
            Console.WriteLine("\n1. Acheter des semis");
            Console.WriteLine("2. Vendre des semis");
            Console.WriteLine("3. Vendre des plantes récoltées");
            Console.WriteLine("0. Quitter le magasin");
            Console.Write("Que voulez-vous faire ? ");
            string choixAction = Console.ReadLine();

            if (choixAction == "1")
            {
                AcheterSemis(inventaire);
            }
            else if (choixAction == "2")
            {
                VendreSemis(inventaire);
            }
            else if (choixAction == "3")
            {
                VendrePlantes(inventaire);
            }
            else if (choixAction == "0")
            {
                Console.WriteLine("⏎ Retour au jeu...");
                break;
            }
            else
            {
                Console.WriteLine("⛔ Choix invalide.");
            }
        }
    }

    private void AcheterSemis(Inventaire inventaire)
    {
        var plantes = CataloguePlantes.PlantesDisponibles;

        Console.WriteLine("\n🌱 Plantes disponibles à l'achat :");

        for (int i = 0; i < plantes.Count; i++)
        {
            var p = plantes[i];
            Console.ForegroundColor = GetCouleurPourTerrain(p.TerrainPrefere);
            Console.WriteLine($"{i + 1}. {p.NomPlante} - {p.PrixAchatSemis}⛁ ({p.TerrainPrefere})");
        }
        Console.ResetColor();

        while (true)
        {
            Console.Write("\nChoisissez une plante à acheter (0 pour revenir) : ");
            if (int.TryParse(Console.ReadLine(), out int choix) && choix > 0 && choix <= plantes.Count)
            {
                var plante = plantes[choix - 1];

                while (true)
                {
                    Console.Write($"Combien de {plante.NomPlante} voulez-vous acheter ? (0 pour annuler) : ");
                    if (int.TryParse(Console.ReadLine(), out int quantite))
                    {
                        if (quantite == 0)
                        {
                            Console.WriteLine("⏎ Achat annulé.");
                            break;
                        }

                        int totalPrix = plante.PrixAchatSemis * quantite;

                        if (inventaire.Argent >= totalPrix)
                        {
                            inventaire.Argent -= totalPrix;
                            inventaire.AjouterSemis(plante.NomPlante, quantite);
                            Console.WriteLine($"=> Achat de {quantite} {plante.NomPlante} réussi !");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("⛔ Argent insuffisant.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("⛔ Entrée invalide.");
                    }
                }
            }
            else if (choix == 0)
            {
                inventaire.AfficherInventaire();
                break;
            }
            else
            {
                Console.WriteLine("⛔ Choix invalide.");
            }
        }
    }

    private void VendreSemis(Inventaire inventaire)
    {
        if (inventaire.SemisPossedes.Count == 0)
        {
            Console.WriteLine("❌ Vous n'avez aucun semis à vendre.");
            return;
        }

        Console.WriteLine("\n🧺 Vos semis disponibles :");
        var nomsSemis = inventaire.SemisPossedes.Keys.ToList();

        for (int i = 0; i < nomsSemis.Count; i++)
        {
            string nom = nomsSemis[i];
            int quantite = inventaire.SemisPossedes[nom];
            var plante = CataloguePlantes.PlantesDisponibles.Find(p => p.NomPlante == nom);

            if (plante != null)
            {
                Console.ForegroundColor = GetCouleurPourTerrain(plante.TerrainPrefere);
                Console.WriteLine($"{i + 1}. {nom} - {quantite} en stock (valeur unitaire : {plante.PrixAchatSemis}⛁)");
            }
        }
        Console.ResetColor();

        while (true)
        {
            Console.Write("\nChoisissez une plante à vendre (0 pour revenir) : ");
            if (int.TryParse(Console.ReadLine(), out int choix) && choix > 0 && choix <= nomsSemis.Count)
            {
                string nomPlante = nomsSemis[choix - 1];
                var plante = CataloguePlantes.PlantesDisponibles.Find(p => p.NomPlante == nomPlante);
                int stock = inventaire.SemisPossedes[nomPlante];

                while (true)
                {
                    Console.Write($"Combien de {nomPlante} voulez-vous vendre ? (max {stock}, 0 pour annuler) : ");
                    if (int.TryParse(Console.ReadLine(), out int quantite))
                    {
                        if (quantite == 0)
                        {
                            Console.WriteLine("⏎ Vente annulée.");
                            break;
                        }

                        if (quantite <= stock)
                        {
                            int gain = plante.PrixAchatSemis * quantite;
                            inventaire.RetirerSemis(nomPlante, quantite);
                            inventaire.Argent += gain;
                            Console.WriteLine($"=> Vente de {quantite} {nomPlante} réussie ! +{gain}⛁");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("⛔ Vous n'avez pas autant de semis.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("⛔ Entrée invalide.");
                    }
                }
            }
            else if (choix == 0)
            {
                inventaire.AfficherInventaire();
                break;
            }
            else
            {
                Console.WriteLine("⛔ Choix invalide.");
            }
        }
    }

    private void VendrePlantes(Inventaire inventaire)
    {
        if (inventaire.PlantesRecoltees.Count == 0)
        {
            Console.WriteLine("❌ Vous n'avez aucune plante récoltée à vendre.");
            return;
        }

        Console.WriteLine("\n💐 Vos plantes récoltées disponibles :");
        var nomsPlantes = inventaire.PlantesRecoltees.Keys.ToList();

        for (int i = 0; i < nomsPlantes.Count; i++)
        {
            string nom = nomsPlantes[i];
            int quantite = inventaire.PlantesRecoltees[nom];
            var plante = CataloguePlantes.GetPlanteParNom(nom);

            if (plante != null)
            {
                int prixVente = plante.PrixVenteProduit; // 🔄 Utilisation du vrai prix de vente
                Console.ForegroundColor = GetCouleurPourTerrain(plante.TerrainPrefere);
                Console.WriteLine($"{i + 1}. {nom} - {quantite} en stock (valeur unitaire : {prixVente}⛁)");
            }
        }
        Console.ResetColor();

        while (true)
        {
            Console.Write("\nChoisissez une plante à vendre (0 pour revenir) : ");
            if (int.TryParse(Console.ReadLine(), out int choix) && choix > 0 && choix <= nomsPlantes.Count)
            {
                string nomPlante = nomsPlantes[choix - 1];
                var plante = CataloguePlantes.GetPlanteParNom(nomPlante);
                int stock = inventaire.PlantesRecoltees[nomPlante];
                int prixVente = plante.PrixVenteProduit;

                while (true)
                {
                    Console.Write($"Combien de {nomPlante} voulez-vous vendre ? (max {stock}, 0 pour annuler) : ");
                    if (int.TryParse(Console.ReadLine(), out int quantite))
                    {
                        if (quantite == 0)
                        {
                            Console.WriteLine("⏎ Vente annulée.");
                            break;
                        }

                        if (quantite <= stock)
                        {
                            int gain = prixVente * quantite;
                            inventaire.PlantesRecoltees[nomPlante] -= quantite;
                            if (inventaire.PlantesRecoltees[nomPlante] == 0)
                                inventaire.PlantesRecoltees.Remove(nomPlante);
                            inventaire.Argent += gain;
                            Console.WriteLine($"=> Vente de {quantite} {nomPlante} réussie ! +{gain}⛁");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("⛔ Vous n'avez pas autant de plantes.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("⛔ Entrée invalide.");
                    }
                }
            }
            else if (choix == 0)
            {
                inventaire.AfficherInventaire();
                break;
            }
            else
            {
                Console.WriteLine("⛔ Choix invalide.");
            }
        }
    }

    public static ConsoleColor GetCouleurPourTerrain(string typeTerrain)
    {
        return typeTerrain.ToLower() switch
        {
            "sable" => ConsoleColor.Yellow,
            "terre" => ConsoleColor.DarkGreen,
            "argile" => ConsoleColor.DarkGray,
            _ => ConsoleColor.White
        };
    }

    public void Afficher()
    {
        // Couleur des bordures selon le type de terrain
        ConsoleColor couleurBordure = TypeTerrain.ToLower() switch
        {
            "sable" => ConsoleColor.Yellow,
            "terre" => ConsoleColor.DarkGreen,
            "argile" => ConsoleColor.DarkGray,
            _ => ConsoleColor.White
        };

        // Affichage des indices de colonnes
        Console.Write("    ");
        for (int x = 0; x < Largeur; x++)
            Console.Write($"   {x}    ");
        Console.WriteLine();

        // Ligne du haut du tableau
        Console.Write("   ");
        Console.ForegroundColor = couleurBordure;
        Console.Write("╔");
        for (int x = 0; x < Largeur - 1; x++)
            Console.Write("══════╦");
        Console.Write("══════╗");
        Console.ResetColor();
        Console.WriteLine();

        for (int y = 0; y < Hauteur; y++)
        {
            // Ligne plante + stade
            Console.Write($" {y} ");
            Console.ForegroundColor = couleurBordure;
            Console.Write("║");
            Console.ResetColor();
            for (int x = 0; x < Largeur; x++)
            {
                Console.Write($" {Grille[x, y].LigneHaut(),-2} ");
                Console.ForegroundColor = couleurBordure;
                Console.Write("║");
                Console.ResetColor();
            }
            Console.WriteLine();

            // Ligne luminosité + eau
            Console.Write("   ");
            Console.ForegroundColor = couleurBordure;
            Console.Write("║");
            Console.ResetColor();
            for (int x = 0; x < Largeur; x++)
            {
                Parcelle p = Grille[x, y];
                if (p.Plante != null && !p.EstOrigine)
                {
                    Console.Write("    "); // rien à afficher
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($" {p.Luminosite}");
                    Console.ResetColor();

                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"{p.NombreVersEmoji(p.Eau)}");
                    Console.ResetColor();
                }
                Console.ForegroundColor = couleurBordure;
                Console.Write("  ║");
                Console.ResetColor();
            }
            Console.WriteLine();

            // Si ce n'est pas la dernière ligne, on met un séparateur
            if (y < Hauteur - 1)
            {
                Console.Write("   ");
                Console.ForegroundColor = couleurBordure;
                Console.Write("╠");
                for (int x = 0; x < Largeur - 1; x++)
                    Console.Write("══════╬");
                Console.Write("══════╣");
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        // Ligne du bas du tableau
        Console.Write("   ");
        Console.ForegroundColor = couleurBordure;
        Console.Write("╚");
        for (int x = 0; x < Largeur - 1; x++)
            Console.Write("══════╩");
        Console.Write("══════╝");
        Console.ResetColor();
        Console.WriteLine();
    }
}