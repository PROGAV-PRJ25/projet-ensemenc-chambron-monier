namespace SimulateurPotager{
    public abstract class Terrain{
        public string NomTerrain;
        public List<TypeTerrain> Type;
        public double Fertilite; // 0.5 lente, 1 normale, 1.5 rapide
        public double Humidite;
        public double Luminosite;
        public int Largeur;
        public int Hauteur;
        public List<Plante> PlantesSurTerrain;
        public Terrain(string nomTerrain, int largeur, int hauteur, List<TypeTerrain> type){
            NomTerrain = nomTerrain;
            Largeur = largeur;
            Hauteur = hauteur;
            Type = type;
            PlantesSurTerrain = new List<Plante>();
        }
        public abstract void MettreAJourEtat(Meteo meteo);
        public void AfficherEtat(){
            Console.WriteLine($"=== {NomTerrain} ===");
            Console.WriteLine($"Fertilité : {Fertilite}");
            Console.WriteLine($"Humidité : {Humidite}");
            Console.WriteLine($"Luminosité : {Luminosite}");
        }
    }
}