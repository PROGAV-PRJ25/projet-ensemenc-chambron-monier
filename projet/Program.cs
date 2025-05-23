//------------------------------------------------------------------------------------------------------------------------------------------
// BIENVENUE DANS LE JEU
//------------------------------------------------------------------------------------------------------------------------------------------

Console.Clear();
Console.ForegroundColor = ConsoleColor.White;
var logo = new[] {
    "██████████████████████████████████████████████████████████████████████████████╗",
    "██                                                                          ██║",
    "██                         BIENVENUE DAAAAAANS ...                          ██║",
    "██                                                                          ██║",
    "██  ███████╗███╗   ██╗███████╗███████╗███╗   ███╗███████╗███╗   ██╗ ██████╗ ██║",
    "██  ██╔════╝████╗  ██║██╔════╝██╔════╝████╗ ████║██╔════╝████╗  ██║██╔════╝ ██║",
    "██  █████╗  ██╔██╗ ██║███████ █████╗  ██╔████╔██║█████╗  ██╔██╗ ██║██║      ██║",
    "██  ██╔══╝  ██║╚██╗██║╚════██ ██╔══╝  ██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║      ██║",
    "██  ███████╗██║ ╚████║███████╗███████╗██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╗ ██║",
    "██  ╚══════╝╚═╝  ╚═══╝╚══════╝╚══════╝╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝ ██║",
    "██                                                                          ██║",
    "██           ████████████████████████████████████████████████████╗          ██║",
    "██           ██                                                ██║          ██║",
    "██           ██      Le meilleur jeu de gestion de jardin !    ██║          ██║",
    "██           ██         Viens faire pousser tes plantes        ██║          ██║",
    "██           ██      AVEC JÉRÉMY CHAMBRON & RÉMI MONIER !!     ██║          ██║",
    "██           ██                                                ██║          ██║",
    "██           ████████████████████████████████████████████████████║          ██║",
    "██           ╚═══════════════════════════════════════════════════╝          ██║",
    "██                                                                          ██║",
    "██████████████████████████████████████████████████████████████████████████████║",
    "╚═════════════════════════════════════════════════════════════════════════════╝\n",
};
for (int i = 0; i < logo.Length; i++)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(logo[i]);
}
Console.ResetColor();

//------------------------------------------------------------------------------------------------------------------------------------------
// PASSER AU CHOIX DU PAYS
//------------------------------------------------------------------------------------------------------------------------------------------

string? reponsePays;
do
{
    Console.ResetColor();
    Console.Write("Souhaitez-vous passer au choix du pays dans lequel construire votre jardin ? (oui) : ");
    reponsePays = Console.ReadLine()?.Trim().ToLower();

    if (reponsePays != "oui")
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("➤ Dites oui s’il vous plaît !");
        Console.ResetColor();
    }
}
while (reponsePays != "oui");

//------------------------------------------------------------------------------------------------------------------------------------------
// CHOIX DU PAYS
//------------------------------------------------------------------------------------------------------------------------------------------

string[] paysDispo = { "Egypte", "Bangladesh", "France", "Maroc", "Mexique", "Chine", "ChezBéa" };
string[] typesTerrains = { "sable", "argile", "terre", "sable + argile", "sable + terre", "argile + terre", "argile + sable + terre" };

Console.Clear();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("╔═════════════════════════════════════════════════╗");
Console.WriteLine("║         🌍  CHOIX DU PAYS DE CULTURE  🌍        ║");
Console.WriteLine("╚═════════════════════════════════════════════════╝\n");

Console.ResetColor();
for (int i = 0; i < paysDispo.Length; i++)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($" {i + 1}. ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"{paysDispo[i]}");
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"  →  Terrain : {typesTerrains[i]}");
}
Console.ResetColor();

int choixPays;
do
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("\nVotre choix (1-7) : ");
    Console.ResetColor();
}
while (!int.TryParse(Console.ReadLine(), out choixPays) || choixPays < 1 || choixPays > 7);

string paysChoisi = paysDispo[choixPays - 1];
string typeChoisi = typesTerrains[choixPays - 1];

//------------------------------------------------------------------------------------------------------------------------------------------
// CHOIX DU NOMBRE DE TERRAIN
//------------------------------------------------------------------------------------------------------------------------------------------

int nbTerrains;
do
{
    Console.Write("Nombre de terrains (1-5) : ");
}
while (!int.TryParse(Console.ReadLine(), out nbTerrains) || nbTerrains < 1 || nbTerrains > 5);

//------------------------------------------------------------------------------------------------------------------------------------------
// CHOIX DE LA TAILLE DES TERRAINS
//------------------------------------------------------------------------------------------------------------------------------------------

int dimension;
do
{
    Console.Write("Dimension des terrains (1-5) : ");
}
while (!int.TryParse(Console.ReadLine(), out dimension) || dimension < 1 || dimension > 5);

//------------------------------------------------------------------------------------------------------------------------------------------
// CHOIX DU TYPE DE TERRAINS SI PAYS 4-5-6-7
//------------------------------------------------------------------------------------------------------------------------------------------

var typesPossibles = choixPays switch
{
    4 => new List<string> { "Sable", "Argile" },
    5 => new List<string> { "Sable", "Terre" },
    6 => new List<string> { "Argile", "Terre" },
    7 => new List<string> { "Sable", "Argile", "Terre" },
    _ => new List<string>()
};

var typesDeTerrains = new List<string>();

if (choixPays > 3)
{
    Console.WriteLine($"Vous avez choisi : {paysChoisi} comme pays pour votre jardin.");
    Console.WriteLine($"Le sol de ce pays est composé de plusieurs types : {string.Join(", ", typesPossibles)}.");
    Console.WriteLine($"Vous devez choisir le type de sol de vos {nbTerrains} terrains.\n");

    for (int i = 0; i < nbTerrains; i++)
    {
        Console.WriteLine($"\nChoisissez le type de sol pour le Terrain {i + 1} :");
        for (int j = 0; j < typesPossibles.Count; j++)
        {
            Console.WriteLine($"{j + 1}. {typesPossibles[j]}");
        }

        int choix;
        do
        {
            Console.Write("Votre choix : ");
        } while (!int.TryParse(Console.ReadLine(), out choix) || choix < 1 || choix > typesPossibles.Count);

        typesDeTerrains.Add(typesPossibles[choix - 1]);
    }
}
else
{
    // Si 1 seul type possible (Egypte, Bangladesh, France)
    string typeUnique = choixPays switch
    {
        1 => "Sable",
        2 => "Argile",
        3 => "Terre",
        _ => "Sable"
    };

    for (int i = 0; i < nbTerrains; i++)
        typesDeTerrains.Add(typeUnique);
}

//------------------------------------------------------------------------------------------------------------------------------------------
// CHOIX DE LA SAISON POUR COMMENCER LA PARTIE
//------------------------------------------------------------------------------------------------------------------------------------------

Console.Write("Choisissez la saison de départ (hiver, printemps, été, automne) (sinon départ en hiver): ");
string? saison = Console.ReadLine();

//------------------------------------------------------------------------------------------------------------------------------------------
// AFFICHAGE DES CHOIX
//------------------------------------------------------------------------------------------------------------------------------------------

Console.WriteLine($"\nVous avez choisi : {paysChoisi} ! Bienvenue =)");
Console.WriteLine($"Vous avez : {nbTerrains} terrains de {dimension}x{dimension} m² dans votre jardin.\n");
for (int i=0; i<typesDeTerrains.Count; i++)
Console.WriteLine($"{typesDeTerrains[i]}");

Simulation simulation = new Simulation(nbTerrains, typesDeTerrains, dimension, saison!, paysChoisi);

//------------------------------------------------------------------------------------------------------------------------------------------
// LANCEMENT DU JEU
//------------------------------------------------------------------------------------------------------------------------------------------

simulation.Simuler();