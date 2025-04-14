public class TerrainST : Terrain
{
    public TerrainST(int largeur, int hauteur) : base(largeur, hauteur){
        NomTerrain = "Terrain Sableux-Terreux";
        Type = TypeTerrain.Terre; // ou un mix symbolique
        Fertilite = 0.9;
        Humidite = 0.5;
        Luminosite = 1.2;
    }
    public override void MettreAJourEtat(Meteo meteo){
        Humidite += meteo.Precipitations * 0.6;
        Humidite -= 0.35;
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
