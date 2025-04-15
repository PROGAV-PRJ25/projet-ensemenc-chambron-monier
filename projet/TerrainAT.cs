public class TerrainAT : Terrain
{
    public TerrainAT(int largeur, int hauteur) : base("Terrain Argile-Terreux", largeur, hauteur, new List<TypeTerrain>{TypeTerrain.Argile, TypeTerrain.Terre}){
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
}