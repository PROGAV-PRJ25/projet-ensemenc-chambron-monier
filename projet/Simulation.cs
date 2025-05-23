public class Simulation
{
    private bool FinJeu;
    private List<Terrain> Jardin;
    private int SemaineDeJeu;
    public  Inventaire InventaireJoueur;
    public Meteo ?MeteoHebdo;
    public string PaysChoisi;

//------------------------------------------------------------------------------------------------------------------------------------------
// CONSTRUCTEUR POUR AVOIR LE JARDIN, AVEC LES TERRAINS, LEURS TYPES, LEUR DIMENSION
//------------------------------------------------------------------------------------------------------------------------------------------

    public Simulation(int nbTerrains, List<string> typesDeTerrains, int dimension, string saisonDepart, string paysChoisi)
    {
        Jardin = new List<Terrain>();
        SemaineDeJeu = ObtenirSemaineDeDepart(saisonDepart);
        for (int i = 0; i < nbTerrains; i++)
        {
            Jardin.Add(new Terrain(dimension, typesDeTerrains[i]));
        }
        FinJeu = false;
        InventaireJoueur = new Inventaire(dimension, nbTerrains);
        PaysChoisi = paysChoisi;
    }

//------------------------------------------------------------------------------------------------------------------------------------------
// CALLER LA SEMAINE DE JEU PAR RAPPORT AU MOIS CHOISI
//------------------------------------------------------------------------------------------------------------------------------------------ 

    private int ObtenirSemaineDeDepart(string saison)
    {
        switch (saison.ToLower())
        {
            case "hiver": return 1;
            case "printemps": return 13;
            case "été": return 23;
            case "automne": return 36;
            default: return 1;
        }
    }

//------------------------------------------------------------------------------------------------------------------------------------------
// ALERTES MÉTÉO QUAND ELLE EST SPÉCIALE
//------------------------------------------------------------------------------------------------------------------------------------------

    private void AfficherAlerteCanicule()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        string[] alerte = new string[]
        {
            "║      ╔══════════════════════════════════════════════════════════════╗      ║",
            "║      ║   🔥  ALERTE CANICULE  🔥                                    ║      ║",
            "║      ╠══════════════════════════════════════════════════════════════╣      ║",
            "║      ║  Températures très élevées cette semaine ! 🌡️🌡️                ║      ║",
            "║      ║  Vos plantes risquent de souffrir. Pensez à les arroser 💦💦 ║      ║",
            "║      ║  et à installer un pare-soleil si possible. 🌞🌞             ║      ║",
            "║      ╚══════════════════════════════════════════════════════════════╝      ║"
        };
        foreach (var ligne in alerte) Console.WriteLine(ligne);
        Console.ResetColor();
    }

    private void AfficherAlerteGel()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        string[] alerte = new string[]
        {
            "║      ╔══════════════════════════════════════════════════════════════╗      ║",
            "║      ║   ❄️  RISQUE DE GEL  ❄️                                        ║      ║",
            "║      ╠══════════════════════════════════════════════════════════════╣      ║",
            "║      ║  Il fait très froid cette semaine... 🧊🧊                    ║      ║",
            "║      ║  Les plantes sensibles au gel doivent être protégées ! 🪴🪴    ║      ║",
            "║      ╚══════════════════════════════════════════════════════════════╝      ║"
        };
        foreach (var ligne in alerte) Console.WriteLine(ligne);
        Console.ResetColor();
    }

    private void AfficherAlertePluie()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        string[] alerte = new string[]
        {
            "║      ╔══════════════════════════════════════════════════════════════╗      ║",
            "║      ║   🌧️  PLUIE ABONDANTE  🌧️                                      ║      ║",
            "║      ╠══════════════════════════════════════════════════════════════╣      ║",
            "║      ║  Attendez-vous à de fortes précipitations cette semaine !    ║      ║",
            "║      ║  Vos plantes auront largement assez d'eau. 🌊🌊              ║      ║",
            "║      ╚══════════════════════════════════════════════════════════════╝      ║"
        };
        foreach (var ligne in alerte) Console.WriteLine(ligne);
        Console.ResetColor();
    }

    private void AfficherAlerteLumiFaible()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        string[] alerte = new string[]
        {
            "║      ╔══════════════════════════════════════════════════════════════╗      ║",
            "║      ║   🌥️  LUMINOSITÉ FAIBLE  🌥️                                    ║      ║",
            "║      ╠══════════════════════════════════════════════════════════════╣      ║",
            "║      ║  Peu de lumière cette semaine, la croissance ralentit  🐢🐢  ║      ║",
            "║      ║  Évitez de planter des espèces qui demandent bcp de ☀️☀️       ║      ║",
            "║      ╚══════════════════════════════════════════════════════════════╝      ║"
        };
        foreach (var ligne in alerte) Console.WriteLine(ligne);
        Console.ResetColor();
    }

    private void AfficherAlerteSoleil()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        string[] alerte = new string[]
        {
            "║      ╔══════════════════════════════════════════════════════════════╗      ║",
            "║      ║   🌞  FORT ENSOLEILLEMENT  🌞                                ║      ║",
            "║      ╠══════════════════════════════════════════════════════════════╣      ║",
            "║      ║  La lumière est intense cette semaine ! ☀️☀️                   ║      ║",
            "║      ║  Les plantes fragiles au soleil doivent être protégées. 🧴🧴 ║      ║",
            "║      ╚══════════════════════════════════════════════════════════════╝      ║"
        };
        foreach (var ligne in alerte) Console.WriteLine(ligne);
        Console.ResetColor();
    }

    private void AfficherAlerteSecheresse()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        string[] alerte = new string[]
        {
            "║      ╔══════════════════════════════════════════════════════════════╗      ║",
            "║      ║    🌞  SEMAINE SÈCHE  🌞                                     ║      ║",
            "║      ╠══════════════════════════════════════════════════════════════╣      ║",
            "║      ║  Peu d'intempéries cette semaine ! 💦💦                      ║      ║",
            "║      ║  Pensez à arroser manuellement vos plantes ! 🌊🌊            ║      ║",
            "║      ╚══════════════════════════════════════════════════════════════╝      ║"
        };
        foreach (var ligne in alerte) Console.WriteLine(ligne);
        Console.ResetColor();
    }

//------------------------------------------------------------------------------------------------------------------------------------------
// BULLETIN MÉTÉO AU DÉBUT DE CHAQUE SEMAINE + RAPPEL RAPIDE DE LA MÉTÉO
//------------------------------------------------------------------------------------------------------------------------------------------
 
    private void AfficherBulletinMeteo()
    {
        Console.Clear();
        MeteoHebdo = new Meteo(SemaineDeJeu);

        // Haut du cadre
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine($"║               🌤️  {PaysChoisi,10} : BULLETIN MÉTÉO DE LA SEMAINE 🌤️               ║");
        Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════╣");

        // Info semaine + saison
        Console.Write("║  Semaine : ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"{SemaineDeJeu.ToString("D3")}");
        Console.ResetColor();
        Console.WriteLine("                                                             ║");

        Console.Write("║  Saison  : ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"{MeteoHebdo.saison,-10}");
        Console.ResetColor();
        Console.Write("                                                      ║\n");

        // Info météo
        Console.Write($"║  Température     : ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"{MeteoHebdo.Temperature,5:0.0}°C");
        Console.ResetColor();
        Console.Write("                                                 ║\n");

        Console.Write($"║  Précipitations  : ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"{MeteoHebdo.Precipitations.ToString("000")} mm");
        Console.ResetColor();
        Console.Write("                                                  ║\n");

        Console.Write($"║  Luminosité      : ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"{MeteoHebdo.Luminosite}/9");
        Console.ResetColor();
        Console.Write("                                                     ║\n");

        Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════╣");

        // Alertes intégrées
        bool alerte = false;
        if (MeteoHebdo.Precipitations > 60)
        {
            AfficherAlertePluie();
            alerte = true;
        }
        else if (MeteoHebdo.Precipitations < 10)
        {
            AfficherAlerteSecheresse();
            alerte = true;
        }

        if (MeteoHebdo.Luminosite >= 7)
        {
            AfficherAlerteSoleil();
            alerte = true;
        }
        else if (MeteoHebdo.Luminosite <= 2)
        {
            AfficherAlerteLumiFaible();
            alerte = true;
        }

        if (MeteoHebdo.Temperature < 5)
        {
            AfficherAlerteGel();
            alerte = true;
        }
        else if (MeteoHebdo.Temperature > 28)
        {
            AfficherAlerteCanicule();
            alerte = true;
        }

        // Fin du cadre si aucune alerte
        if (!alerte)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"║    ✅ Pas d’alerte météo cette semaine. Tout va bien dans le jardin !      ║");
        }

        Console.ResetColor();
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════╝\n");
    }

    private void RappelMeteo()
    {
        Console.Clear();
        MeteoHebdo = new Meteo(SemaineDeJeu);

        // Haut du cadre
        Console.ResetColor();
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║ Rappel de la météo de la semaine :                                         ║");
        Console.Write($"║  Température     : ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"{MeteoHebdo.Temperature,5:0.0}°C");
        Console.ResetColor();
        Console.Write("                                                 ║\n");

        Console.Write($"║  Précipitations  : ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"{MeteoHebdo.Precipitations.ToString("000")} mm");
        Console.ResetColor();
        Console.Write("                                                  ║\n");

        Console.Write($"║  Luminosité      : ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"{MeteoHebdo.Luminosite}/9");
        Console.ResetColor();
        Console.Write("                                                     ║\n");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════╝\n");
    }

//------------------------------------------------------------------------------------------------------------------------------------------
// AFFICHER LES DÉTAILS ET CARACTÉRISTIQUES DES PLANTES (DÉTAILLÉ OU RAPIDE)
//------------------------------------------------------------------------------------------------------------------------------------------

    public static void VoirDetailsPlantes()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("╔══════════════════════════════════════════════════════╗");
        Console.WriteLine("║               📘 Catalogue des Plantes               ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════╝");
        Console.ResetColor();

        var catalogue = CataloguePlantes.PlantesDisponibles;

        for (int i = 0; i < catalogue.Count; i++)
        {
            var plante = catalogue[i];
            Console.ForegroundColor = GetCouleurPourTerrain(plante.TerrainPrefere);
            Console.WriteLine($"  {i + 1}. {plante.NomPlante}");
        }

        Console.ResetColor();
        Console.WriteLine("\nTapez le numéro d'une plante pour voir ses détails, ou '0' pour quitter :");
        string? choix = Console.ReadLine();

        if (choix?.ToLower() == "0")
        {
            Console.Clear();
            return;
        }

        if (int.TryParse(choix, out int index) && index >= 1 && index <= catalogue.Count)
        {
            Console.Clear();
            var plante = catalogue[index - 1];
            Console.ForegroundColor = GetCouleurPourTerrain(plante.TerrainPrefere);
            Console.WriteLine($"🌿 Détails de la plante : {plante.NomPlante}");
            Console.ResetColor();
            Console.WriteLine(plante.AfficherDetails());
            Console.WriteLine("\nAppuyez sur une touche pour revenir au catalogue...");
            Console.ReadKey();
            Console.Clear();
            VoirDetailsPlantes(); // Pour relancer le menu après affichage
        }
        else
        {
            Console.WriteLine("Entrée invalide.");
        }
    }

    public static void VoirDetailsPlantesEssentiels()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("╔══════════════════════════════════════════════════════╗");
        Console.WriteLine("║               📘 Catalogue des Plantes               ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════╝");
        Console.ResetColor();

        var catalogue = CataloguePlantes.PlantesDisponibles;

        for (int i = 0; i < catalogue.Count; i++)
        {
            var plante = catalogue[i];
            Console.ForegroundColor = GetCouleurPourTerrain(plante.TerrainPrefere);
            Console.WriteLine($"  {i + 1}. {plante.NomPlante}");
        }

        Console.ResetColor();
        Console.WriteLine("\nTapez le numéro d'une plante pour voir ses détails, ou '0' pour quitter :");
        string? choix = Console.ReadLine();

        if (choix?.ToLower() == "0")
        {
            Console.Clear();
            return;
        }

        if (int.TryParse(choix, out int index) && index >= 1 && index <= catalogue.Count)
        {
            Console.Clear();
            var plante = catalogue[index - 1];
            Console.ForegroundColor = GetCouleurPourTerrain(plante.TerrainPrefere);
            Console.WriteLine($"🌿 Détails de la plante : {plante.NomPlante}");
            Console.ResetColor();
            Console.WriteLine(plante.AfficherDetailsEssentiels());
            Console.WriteLine("\nAppuyez sur une touche pour revenir au catalogue...");
            Console.ReadKey();
            Console.Clear();
            VoirDetailsPlantesEssentiels(); // relance la vue essentielle
        }
        else
        {
            Console.WriteLine("Entrée invalide.");
        }
    }

//------------------------------------------------------------------------------------------------------------------------------------------
// AFFICHER LES PLANTES EN COULEUR SELON LEUR TYPE DE TERRAIN
//------------------------------------------------------------------------------------------------------------------------------------------

    private static ConsoleColor GetCouleurPourTerrain(string typeTerrain)
    {
        return typeTerrain.ToLower() switch
        {
            "sable" => ConsoleColor.Yellow,
            "terre" => ConsoleColor.DarkGreen,
            "argile" => ConsoleColor.DarkGray,
            _ => ConsoleColor.White
        };
    }

//------------------------------------------------------------------------------------------------------------------------------------------
// COMMENCER LA SIMULATION SEMAINE PAR SEMAINE
//------------------------------------------------------------------------------------------------------------------------------------------

    public void Simuler()
    {
        while (!FinJeu)
        {
            Console.Clear();
            MeteoHebdo = new Meteo(SemaineDeJeu); // Créer la météo de la semaine
            AfficherBulletinMeteo(); // Afficher le bulletin météo de la semaine

            string? reponseJardin;
            do
            {
                Console.ResetColor();
                Console.Write("Souhaitez-vous aller au jardin ? (oui) : ");
                reponseJardin = Console.ReadLine()?.Trim().ToLower();

                if (reponseJardin != "oui")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("➤ Dites oui s’il vous plaît, on peut pas jouer sinon !");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ResetColor();
                }
            }
            while (reponseJardin != "oui");

            // Appliquer la météo à tous les terrains
            foreach (var terrain in Jardin)
            {
                terrain.AppliquerMeteo(MeteoHebdo);
            }
            for (int i = 0; i < Jardin.Count; i++)
            {
                Console.Clear();
                Console.WriteLine($"=== Terrain {i + 1} ({Jardin[i].TypeTerrain}) ===\n");
                RappelMeteo(); // Rappel rapide de la météo
                Jardin[i].Afficher(); // Afficher le terrain
                int actionsRestantes = 5;
                while (actionsRestantes > 0) // Montrer les actions disponibles
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine($"║ Actions restantes : {actionsRestantes,-2}                               Actions disponibles : ║");
                    Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════╣");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ResetColor();

                    Console.WriteLine("║  1. Désherber                       ║  2. Pailler                          ║");
                    Console.WriteLine("║  3. Arroser                         ║  4. #Traiter                         ║");
                    Console.WriteLine("║  5. Semer                           ║  6. Récolter                         ║");
                    Console.WriteLine("║  7. #Installer serre                ║  8. #Installer barrière              ║");
                    Console.WriteLine("║  9. #Installer pare-soleil          ║ 10. Aller au magasin                 ║");
                    Console.WriteLine("║ 11. Voir l'inventaire               ║ 12. Voir détails plantes             ║");
                    Console.WriteLine("║ 13. Voir détails essentiels plantes ║ 0. Finir le tour de jeu              ║");
                    Console.WriteLine("║ # = méthode pas encore développée                                          ║");
                    Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════╝");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("➤ Choix : ");
                    Console.ResetColor();
                    string? input = Console.ReadLine();
                    switch (input) // Appeler la méthode correcte selon l'action souhaitée
                    {
                        case "0":
                            actionsRestantes = 0;
                            break;
                        case "1":
                            Jardin[i].Desherber();
                            actionsRestantes--;
                            Jardin[i].Afficher();
                            break;
                        case "2":
                            Jardin[i].Pailler();
                            actionsRestantes--;
                            Jardin[i].Afficher();
                            break;
                        case "3":
                            Jardin[i].Arroser();
                            actionsRestantes--;
                            Jardin[i].Afficher();
                            break;
                        case "4":
                            //Jardin[i].Traiter();
                            actionsRestantes--;
                            break;
                        case "5":
                            Jardin[i].Semer(InventaireJoueur);
                            actionsRestantes--;
                            RappelMeteo();
                            Jardin[i].Afficher();
                            break;
                        case "6":
                            Jardin[i].Recolter(InventaireJoueur);
                            actionsRestantes--;
                            Jardin[i].Afficher();
                            break;
                        case "7":
                            //Jardin[i].InstallerSerre();
                            actionsRestantes--;
                            break;
                        case "8":
                            //Jardin[i].InstallerBarriere();
                            actionsRestantes--;
                            break;
                        case "9":
                            //Jardin[i].InstallerPareSoleil();
                            actionsRestantes--;
                            break;
                        case "10":
                            Jardin[i].AllerAuMagasin(InventaireJoueur);
                            actionsRestantes--;
                            Console.Clear();
                            RappelMeteo();
                            Jardin[i].Afficher();
                            break;
                        case "11":
                            InventaireJoueur.AfficherInventaire();
                            break;
                        case "12":
                            VoirDetailsPlantes();
                            break;
                        case "13":
                            VoirDetailsPlantesEssentiels();
                            break;
                        default:
                            Console.WriteLine("Choix invalide.");
                            break;
                    }
                }
                Console.WriteLine("Fin de semaine ... Vous êtes vous bien occupé(e) de votre jardin ?");
                Console.WriteLine("Les plantes poussent ! Ou pas ...");
                foreach (var parcelle in Jardin[i].Grille)
                {
                    if (parcelle.Plante != null)
                    {
                        parcelle.AppliquerCroissance(MeteoHebdo); // Faire pousser les plantes selon les conditions
                    }
                }
            }
            Console.Write("\nPasser à la semaine suivante ? (o/n) : ");
            if (Console.ReadLine()?.ToLower() == "n")
            {
                FinJeu = true; // Arrêter le jeu
            }
            else
            {
                SemaineDeJeu++; // Passer à la semaine suivante
            }
        }
        Console.WriteLine("Merci d’avoir joué 🌻");
    }
}