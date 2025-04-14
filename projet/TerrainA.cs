public class TerrainA : Terrain
{
    public TerrainA(int largeur, int hauteur) : base(largeur, hauteur){
        NomTerrain = "Terrain Argileux";
        Type = TypeTerrain.Argile;
        Fertilite = 1.2;
        Humidite = 0.9;
        Luminosite = 1;
    }
    public override void MettreAJourEtat(Meteo meteo){
        Humidite += meteo.Precipitations * 0.9;
        Humidite -= 0.2; // garde bien l'humidité
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
