public abstract class Terrain
{
    public string NomTerrain;
    public TypeTerrain Type;
    public double Fertilite;
    public double Humidite;
    public double Luminosite;
    public List<Plante> PlantesSurTerrain;
    public Terrain(){
        PlantesSurTerrain = new List<Plante>();
    }
    public abstract void MettreAJourEtat(Meteo meteo);
    public abstract void AfficherEtat();
}