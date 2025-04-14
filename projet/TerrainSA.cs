namespace SimulateurPotager{   
    public class TerrainSA : Terrain
    {
        public TerrainSA(int largeur, int hauteur) : base("Terrain Sable-Argileux", largeur, hauteur, new List<TypeTerrain>{TypeTerrain.Sable, TypeTerrain.Argile}){
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
    }
}