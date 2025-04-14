namespace SimulateurPotager{    
    public class TerrainT : Terrain
    {
        public TerrainT(int largeur, int hauteur) : base("Terrain Terreux", largeur, hauteur, new List<TypeTerrain>{TypeTerrain.Terre}){
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
    }
}