public class TerrainSAT : Terrain
{
    public TerrainSAT(int largeur, int hauteur) : base("Terrain Sable-Argileux-Terreux", largeur, hauteur, new List<TypeTerrain>{TypeTerrain.Sable, TypeTerrain.Argile, TypeTerrain.Terre}){
        Fertilite = 1.8;
        Humidite = 0.85;
        Luminosite = 1.2;
    }
    public override void MettreAJourEtat(Meteo meteo){
        Humidite += meteo.Precipitations * 0.7;
        Humidite -= 0.1;
        if (Humidite < 0){
            Humidite = 0;
        }
    }
}