public class Simulation
{
    private string Pays;
    private bool FinJeu;
    private List<Terrain> Jardin;
    private int SemaineDeJeu;
    public  Inventaire InventaireJoueur;
    public Simulation(int nbTerrains, List<string> typesDeTerrains, int dimension)
    {
        Jardin = new List<Terrain>();
        SemaineDeJeu = 1;
        for (int i=0; i<nbTerrains; i++)
        {
            Jardin.Add(new Terrain(dimension, typesDeTerrains[i]));
        }
        FinJeu = false;
        InventaireJoueur = new Inventaire();
    }
    public void Simuler()
    {
        while (!FinJeu)
        {
            Console.Clear();
            Console.WriteLine($"Semaine {SemaineDeJeu} - Que souhaitez-vous faire ?\n");
            for (int i = 0; i < Jardin.Count; i++)
            {
                Console.WriteLine($"=== Terrain {i + 1} ({Jardin[i].TypeTerrain}) ===\n");
                Jardin[i].Afficher();
                int actionsRestantes = 5;
                while (actionsRestantes > 0)
                {
                    Console.WriteLine($"\nActions restantes : {actionsRestantes}");
                    Console.WriteLine("Actions disponibles :");
                    Console.WriteLine("1. Désherber");
                    Console.WriteLine("2. Pailler");
                    Console.WriteLine("3. Arroser");
                    Console.WriteLine("4. Traiter");
                    Console.WriteLine("5. Semer");
                    Console.WriteLine("6. Récolter");
                    Console.WriteLine("7. Installer serre");
                    Console.WriteLine("8. Installer barrière");
                    Console.WriteLine("9. Installer pare-soleil");
                    Console.WriteLine("10. Aller au magasin");
                    Console.WriteLine("11. Voir l'inventaire");
                    Console.WriteLine("12. Finir le tour du terrain");
                    Console.Write("Choix : ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            //Jardin[i].Desherber();
                            actionsRestantes--;
                            break;
                        case "2":
                            //Jardin[i].Pailler();
                            actionsRestantes--;
                            break;
                        case "3":
                            Jardin[i].Arroser();
                            actionsRestantes--;
                            break;
                        case "4":
                            //Jardin[i].Traiter();
                            actionsRestantes--;
                            break;
                        case "5":
                            Jardin[i].Semer(InventaireJoueur);
                            actionsRestantes--;
                            break;
                        case "6":
                            //Jardin[i].Recolter();
                            actionsRestantes--;
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
                            break;
                        case "11":
                            InventaireJoueur.AfficherInventaire();
                            break;
                        case "12":
                            actionsRestantes = 0;
                            break;
                        default:
                            Console.WriteLine("Choix invalide.");
                            break;
                    }
                }
            }
            Console.Write("\nPasser à la semaine suivante ? (o/n) : ");
            if (Console.ReadLine()?.ToLower() == "n")
            {
                FinJeu = true;
            }
            else
            {
                SemaineDeJeu++;
            }
        }
        Console.WriteLine("Merci d’avoir joué 🌻");
    }
}