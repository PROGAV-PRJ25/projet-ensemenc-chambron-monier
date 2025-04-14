public class TerrainSA : Terrain
{
    public TerrainSA(int largeur, int hauteur) : base(largeur, hauteur){
        NomTerrain = "Terrain Sableux-Argileux";
        Type = TypeTerrain.Argile;
        Fertilite = 1.0;
        Humidite = 0.7;
        Luminosite = 1.3;
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
