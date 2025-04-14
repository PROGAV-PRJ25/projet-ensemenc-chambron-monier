public abstract class Plante
{
    public string NomPlante;
    public TypePlante Type;
    public UtilitePlante Utilite;
    public bool MvHerbe;
    public Saison[] SaisonsDeSemis;
    public TypeTerrain TerrainPrefere;
    public double EspaceNecessaire;
    public double VitesseCroissance;
    public double BesoinEau; // en litre/semaine
    public double BesoinLuminosite; // 0.5 faible - 1 normal - 1.5 élevé
    public int TempMin;
    public int TempMax;
    public Dictionary<string, double> Maladies; // nom maladie + proba
    public int EsperanceDeVie; // en semaines
    public int NombreProduits;
    public double Espacement;
    public double CroissanceActuelle;
    public bool EstVivante;
    public Plante(){
        CroissanceActuelle = 0;
        EstVivante = true;
        Maladies = new Dictionary<string, double>();
    }
    public abstract void Pousser(Meteo meteo){}
    public abstract void VerifierConditions(Terrain terrain, Meteo meteo){}
}