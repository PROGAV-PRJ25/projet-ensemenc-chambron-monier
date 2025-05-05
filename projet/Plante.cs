public class Plante{
    public string Nom;
    public int Rarete;
    public string Cycle;
    public bool Commercialisable;
    public bool Ornementale;
    public bool Medicinale;
    public bool Magique;
    public int Largeur;
    public int Longueur;
    public int Ecart;
    public int Esperance;
    public double VitesseCroissance;
    public string SaisonSemis;
    public int Eau;
    public int Luminosite;
    public int TempMin;
    public int TempMax;
    public string Maladie;
    public double ProbaMaladie;
    public double PrixVente;
    public string TypePrefere;
    public Plante (string nom,int rarete, string cycle, bool commercialisable, bool ornementale, bool medicinale, bool magique, int largeur, int longueur, int ecart, int esperance, double vitesseCroissance, string saisonSemis, int eau, int luminosite, int tempMin, int tempMax, string maladie, double probaMaladie, double prixVente, string typePrefere){
        if (Cycle == "Vivace"){
            Esperance = 1000000;
        }
        Nom=nom;
        Rarete=rarete;
        Cycle =cycle;
        Commercialisable=commercialisable;
        Ornementale=ornementale;
        Medicinale=medicinale;
        Magique=magique;
        Largeur=largeur;
        Longueur=longueur;
        Ecart=ecart;
        Esperance=esperance;
        VitesseCroissance=vitesseCroissance;
        SaisonSemis=saisonSemis;
        Eau=eau;
        Luminosite=luminosite;
        TempMin=tempMin;
        TempMax=tempMax;
        Maladie=maladie;
        ProbaMaladie=probaMaladie;
        PrixVente=prixVente;
        TypePrefere=typePrefere;
    }
}