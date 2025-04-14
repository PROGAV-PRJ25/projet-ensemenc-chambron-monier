namespace SimulateurPotager{    
    public class TerrainST : Terrain
    {
        public TerrainST(int largeur, int hauteur) : base("Terrain Sable-Terreux", largeur, hauteur, new List<TypeTerrain>{TypeTerrain.Sable, TypeTerrain.Terre}){
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
    }
}