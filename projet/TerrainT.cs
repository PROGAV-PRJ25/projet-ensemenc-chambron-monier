public class TerrainT : Terrain
{
    public TerrainT(int largeur, int hauteur) : base(largeur, hauteur){
        NomTerrain = "Terrain Terreux";
        Type = TypeTerrain.Terre;
        Fertilite = 1;
        Humidite = 0.6;
        Luminosite = 1;
    }
    public override void MettreAJourEtat(Meteo meteo){
        Humidite += meteo.Precipitations * 0.7;
        Humidite -= 0.3;
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
