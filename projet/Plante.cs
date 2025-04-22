public class Plante{
    public string Nom;
    public int Rarete;
    public string Cycle;
    public bool Commercialisable;
    public bool Ornementale;
    public bool Médicinale;
    public bool Magique;
    public int Largeur;
    public int Longueur;
    public int Ecart;
    public int Esperance;
    public double VitesseCroissance;
    public string SaisonSemis;
    public double Eau;
    public double Luminosité;
    public int TempMin;
    public int TempMax;
    public string Maladie;
    public double ProbaMaladie;
    public int Prix;
    public int PrixVente;
    public string TypePrefere;
    public Plante (){
        if (Cycle == 'Vivace'){
            Esperance = 1000000;
        }        
    }
}