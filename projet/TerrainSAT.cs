public class TerrainSAT : Terrain
{
    public TerrainSAT(int largeur, int hauteur) : base(largeur, hauteur){
        NomTerrain = "Chez Bea 🌸 (Terrain Magique)";
        Type = TypeTerrain.Terre; // symbolique, ici tout pousse
        Fertilite = 1.5;
        Humidite = 1;
        Luminosite = 1.5;
    }
    public override void MettreAJourEtat(Meteo meteo){
        Humidite += meteo.Precipitations;
        Humidite -= 0.2;
        if (Humidite < 0){
            Humidite = 0;
        }
    }
    public override void AfficherEtat(){
        Console.WriteLine($"=== {NomTerrain} ===");
        Console.WriteLine($"Fertilité : {Fertilite}");
        Console.WriteLine($"Humidité : {Humidite}");
        Console.WriteLine($"Luminosité : {Luminosite}");
    }
}
