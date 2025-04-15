Console.WriteLine("=== Bienvenue dans le simulateur de potager ! ===\n");

// Choix du pays
Console.WriteLine("Dans quel pays souhaitez-vous créer votre jardin ?");
Console.WriteLine("1. Egypte (sol : sable)");
Console.WriteLine("2. Bangladesh (sol : argile)");
Console.WriteLine("3. France (sol : terre)");
Console.WriteLine("4. Maroc (sol : sable + argile)");
Console.WriteLine("5. Mexique (sol : sable + terre)");
Console.WriteLine("6. Chine (sol : argile + terre)");
Console.WriteLine("7. ChezBea (sol : sable + argile + terre — TOUT pousse)");

int choixPays = DemanderNombreEntre(1, 7);

// Choix dimensions
Console.WriteLine("\nEntrez la largeur de votre terrain (en mètres) : ");
int largeur = DemanderNombreEntre(1, 100);

Console.WriteLine("Entrez la hauteur de votre terrain (en mètres) : ");
int hauteur = DemanderNombreEntre(1, 100);

// Créer le terrain en fonction du pays choisi
Terrain terrain = null;

switch (choixPays)
{
    case 1:
        terrain = new TerrainS(largeur, hauteur);
        break;
    case 2:
        terrain = new TerrainA(largeur, hauteur);
        break;
    case 3:
        terrain = new TerrainT(largeur, hauteur);
        break;
    case 4:
        terrain = new TerrainSA(largeur, hauteur);
        break;
    case 5:
        terrain = new TerrainST(largeur, hauteur);
        break;
    case 6:
        terrain = new TerrainAT(largeur, hauteur);
        break;
    case 7:
        terrain = new TerrainSAT(largeur, hauteur);
        break;
}

Console.WriteLine($"\nVotre terrain {terrain.NomTerrain} de {largeur}m x {hauteur}m est prêt !");
Console.WriteLine("Vous pouvez maintenant planter et gérer votre potager.\n");

// Exemple : afficher les caractéristiques du terrain
terrain.AfficherEtat();

// Ici, tu pourras continuer à ajouter un menu pour :
// - Planter
// - Passer à la semaine suivante
// - Afficher l’état du potager
// - etc.

Console.WriteLine("\n=== Début de la simulation ===");

// Méthode utilitaire pour demander un nombre entier entre min et max
static int DemanderNombreEntre(int min, int max)
{
    int nombre;
    while (true)
    {
        Console.Write("> ");
        string saisie = Console.ReadLine();
        if (int.TryParse(saisie, out nombre) && nombre >= min && nombre <= max)
        {
            return nombre;
        }
        Console.WriteLine($"Merci de saisir un nombre entre {min} et {max}.");
    }
}