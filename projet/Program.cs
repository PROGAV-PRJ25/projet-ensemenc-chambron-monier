//------------------------------------------------------------------------------------------------------------------------------------------
// LOGO + BIENVENUE
//------------------------------------------------------------------------------------------------------------------------------------------

Console.ResetColor();
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Bienvenue dans : \n");
Console.ForegroundColor = ConsoleColor.Green;
string[] logo = new string[]
{
    " ███████╗███╗   ██╗███████╗███████╗███╗   ███╗███████╗███╗   ██╗ ██████╗",
    " ██╔════╝████╗  ██║██╔════╝██╔════╝████╗ ████║██╔════╝████╗  ██║██╔════╝ ",
    " █████╗  ██╔██╗ ██║███████ █████╗  ██╔████╔██║█████╗  ██╔██╗ ██║██║      ",
    " ██╔══╝  ██║╚██╗██║╚════██ ██╔══╝  ██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║      ",
    " ███████╗██║ ╚████║███████╗███████╗██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╗ ",
    " ╚══════╝╚═╝  ╚═══╝╚══════╝╚══════╝╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝ \n",
};
for (int i = 0; i < logo.Length; i++)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(logo[i]);
}
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Le jeu de gestion de jardin !\n");

//------------------------------------------------------------------------------------------------------------------------------------------
// CHOIX DU PAYS
//------------------------------------------------------------------------------------------------------------------------------------------

string[] paysDispo = { "Egypte", "Bangladesh", "France", "Maroc", "Mexique", "Chine", "ChezBéa" };
string[] typesTerrains = { "sable", "argile", "terre", "sable + argile", "sable + terre", "argile + terre", "argile + sable + terre" };
Console.WriteLine("Choisissez un pays parmi :");

for (int i = 0; i < paysDispo.Length; i++)
{
    Console.WriteLine($"{i + 1}. {paysDispo[i]} ({typesTerrains[i]})");
}
int choixPays;
do
{
    Console.Write("\nVotre choix (1-7) : ");
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
    Console.Write("Dimension des terrains (1-10) : ");
}
while (!int.TryParse(Console.ReadLine(), out dimension) || dimension < 1 || dimension > 10);

//------------------------------------------------------------------------------------------------------------------------------------------
// CHOIX DU TYPE DE TERRAINS SI PAYS 4-5-6-7
//------------------------------------------------------------------------------------------------------------------------------------------

List<string> typesPossibles = new List<string>();
if (choixPays == 4) typesPossibles.AddRange(new string[] { "Sable", "Argile" });
if (choixPays == 5) typesPossibles.AddRange(new string[] { "Sable", "Terre" });
if (choixPays == 6) typesPossibles.AddRange(new string[] { "Argile", "Terre" });
if (choixPays == 7) typesPossibles.AddRange(new string[] { "Sable", "Argile", "Terre" });

List<string> typesDeTerrains = new List<string>();

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
// AFFICHAGE DES CHOIX
//------------------------------------------------------------------------------------------------------------------------------------------

Console.WriteLine($"\nVous avez choisi : {paysChoisi} ! Bienvenue =)");
Console.WriteLine($"Vous avez : {nbTerrains} terrains de {dimension}x{dimension} m² dans votre jardin.\n");
for (int i=0; i<typesDeTerrains.Count; i++)
Console.WriteLine($"{typesDeTerrains[i]}");

Simulation simulation = new Simulation(nbTerrains, typesDeTerrains, dimension);

//------------------------------------------------------------------------------------------------------------------------------------------
// LANCEMENT DU JEU
//------------------------------------------------------------------------------------------------------------------------------------------

simulation.Simuler();