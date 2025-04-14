public class TerrainS : Terrain
{
    public TerrainS(int largeur, int hauteur) : base(largeur, hauteur){
        NomTerrain = "Terrain Sableux";
        Type = TypeTerrain.Sable;
        Fertilite = 0.7;
        Humidite = 0.3;
        Luminosite = 1.5;
    }
    public override void MettreAJourEtat(Meteo meteo){
        Humidite += meteo.Precipitations * 0.5;
        Humidite -= 0.4; // évaporation rapide
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
