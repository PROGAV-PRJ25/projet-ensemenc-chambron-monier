public class Meteo
{
    public int Temperature; // en °C
    public double Precipitations; // en mm & 1mm de précipitation = 1 litre/m²
    public double Ensoleillement; // 0.5 = faible, 1 = normal, 1.5 = élevé
    public bool Intemperie; // orage, grêle, etc.
    public string Description;
    public Meteo(){
        // Par défaut météo calme
        Temperature = 20;
        Precipitations = 0; // 1mm de précipitation = 1 litre/m²
        Ensoleillement = 1;
        Intemperie = false;
        Description = "Temps clair et calme";
    }
    // Méthode pour générer une météo aléatoire pour un tour de jeu
    public void GenererMeteoAleatoire(Random rnd)
    {
        Temperature = rnd.Next(-5, 35);
        Precipitations = Math.Round(rnd.NextDouble() * 20, 1); // entre 0 et 20 mm
        Ensoleillement = Math.Round(0.5 + rnd.NextDouble() * 1, 1); // entre 0.5 et 1.5

        Intemperie = rnd.Next(0, 100) < 10; // 10% de chance d'intempérie

        if (Intemperie)
        {
            Description = "Orage et fortes intempéries !";
        }
        else
        {
            Description = "Temps calme";
        }
    }
    public void AfficherMeteo()
    {
        Console.WriteLine("===== Météo =====");
        Console.WriteLine($"Température : {Temperature}°C");
        Console.WriteLine($"Précipitations : {Precipitations} mm");
        Console.WriteLine($"Ensoleillement : {Ensoleillement}");
        Console.WriteLine($"Évènement : {Description}");
        Console.WriteLine("=================\n");
    }
}