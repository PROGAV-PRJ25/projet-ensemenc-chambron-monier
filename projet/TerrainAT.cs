public class TerrainAT : Terrain
{
    public TerrainAT(int largeur, int hauteur) : base(largeur, hauteur){
        NomTerrain = "Terrain Argileux-Terreux";
        Type = TypeTerrain.Terre;
        Fertilite = 1.1;
        Humidite = 0.8;
        Luminosite = 1;
    }
    public override void MettreAJourEtat(Meteo meteo){
        Humidite += meteo.Precipitations * 0.8;
        Humidite -= 0.25;
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
