public class Maladie
{
    public string Nom { get; set; }
    public double ProbabiliteInfection { get; set; }

    public Maladie(string nom, double probabilite)
    {
        Nom = nom;
        ProbabiliteInfection = probabilite;
    }
}