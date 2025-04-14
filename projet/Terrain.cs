public abstract class Terrain
{
    public string NomTerrain;
    public TypeTerrain Type;
    public double Fertilite;
    public double Humidite;
    public double Luminosite;
    public int Largeur;
    public int Hauteur;
    public List<Plante> PlantesSurTerrain;
    public Terrain(int largeur, int hauteur){
        Largeur = largeur;
        Hauteur = hauteur;
        PlantesSurTerrain = new List<Plante>();
    }
    public abstract void MettreAJourEtat(Meteo meteo);
    public abstract void AfficherEtat();
}