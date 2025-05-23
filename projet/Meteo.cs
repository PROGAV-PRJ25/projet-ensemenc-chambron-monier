using System;

public class Meteo
{
    public int Semaine { get; private set; }             // Semaine de l'année (1 à 52)
    public float Precipitations { get; private set; }    // en mm
    public float Temperature { get; private set; }       // en °C
    public int Luminosite { get; private set; }         // échelle de 0 (très sombre) à 9 (très lumineux)
    public string saison => ObtenirSaison(Semaine);
    private static Random rng = new Random();

    public Meteo(int semaine)
    {
        Semaine = semaine;
        GenererMeteo();
    }

    private void GenererMeteo()
    {
        string saison = ObtenirSaison(Semaine);

        switch (saison)
        {
            case "Hiver":
                Precipitations = rng.Next(20, 100);
                Temperature = (float)(rng.NextDouble() * 5.0 - 2.0);  // -2 à 3°C
                Luminosite = rng.Next(1, 4);  // 1 à 3
                break;

            case "Printemps":
                Precipitations = rng.Next(30, 80);
                Temperature = (float)(rng.NextDouble() * 10.0 + 5.0); // 5 à 15°C
                Luminosite = rng.Next(3, 7);  // 3 à 6
                break;

            case "Été":
                Precipitations = rng.Next(0, 60);
                Temperature = (float)(rng.NextDouble() * 10.0 + 20.0); // 20 à 30°C
                Luminosite = rng.Next(6, 10);  // 6 à 9
                break;

            case "Automne":
                Precipitations = rng.Next(40, 90);
                Temperature = (float)(rng.NextDouble() * 8.0 + 5.0); // 5 à 13°C
                Luminosite = rng.Next(2, 6);  // 2 à 5
                break;
        }
    }

    private string ObtenirSaison(int semaine)
    {
        if (semaine >= 1 && semaine <= 12) return "Hiver";
        else if (semaine >= 13 && semaine <= 22) return "Printemps";
        else if (semaine >= 23 && semaine <= 35) return "Été";
        else if (semaine >= 36 && semaine <= 48) return "Automne";
        else return "Hiver";  // Semaines 49 à 52
    }

    public override string ToString()
    {
        return $"Semaine {Semaine} - {ObtenirSaison(Semaine)}\n" +
               $"Température : {Temperature:F1}°C\n" +
               $"Précipitations : {Precipitations} mm\n" +
               $"Luminosité : {Luminosite} / 9";
    }
}
