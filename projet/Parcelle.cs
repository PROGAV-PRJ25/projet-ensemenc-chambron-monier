public class Parcelle
{
    public Plante? Plante { get; set; }
    public int Luminosite { get; set; } = 0;
    public int Eau { get; set; } = 0;
    public bool EstOrigine { get; set; } = true;
    public string LigneHaut()
    {
        if (Plante == null)
            return "    "; // 5 espaces pour alignement

        if (EstOrigine)
            return $"{Plante.Initiale} {Plante.GetEmojiStade()}";

        return $"  {Plante.Initiale} "; // 3 caractères centrés : juste l'initiale
    }
    public string LigneBas()
    {
        if (Plante != null && !EstOrigine)
            return "   ";
        return $"{Luminosite}  {NombreVersEmoji(Eau)}";
    }

    public string NombreVersEmoji(int nombre)
    {
        return nombre switch
        {
            0 => "0️⃣",
            1 => "1️⃣",
            2 => "2️⃣",
            3 => "3️⃣",
            4 => "4️⃣",
            5 => "5️⃣",
            6 => "6️⃣",
            7 => "7️⃣",
            8 => "8️⃣",
            9 => "9️⃣",
            _ => "❓"
        };
    }
    public void AppliquerCroissance(Meteo meteo)
    {
        if (Plante == null || !EstOrigine) return;

        int conditionsRemplies = 0;
        int totalConditions = 4;

        // Condition 1 : Température dans la plage
        if (meteo.Temperature >= Plante.TempMin && meteo.Temperature <= Plante.TempMax)
            conditionsRemplies++;

        // Condition 2 : Luminosité suffisante
        double proportionLumi = Luminosite / 10.0;
        if (proportionLumi >= Plante.BesoinLuminosite)
            conditionsRemplies++;

        // Condition 3 : Eau suffisante
        if (Eau >= Plante.BesoinEau)
            conditionsRemplies++;

        // Condition 4 : Espacement (à implémenter plus tard si pas fait)
        bool espacementCorrect = true; // simplifié pour l’instant
        if (espacementCorrect)
            conditionsRemplies++;

        // Calcul du pourcentage de conditions
        double tauxConditions = conditionsRemplies / (double)totalConditions;

        // Appliquer croissance
        if (tauxConditions == 0)
        {
            Plante.StadeCroissance = 4; // Mort
        }
        else if (tauxConditions < 0.5)
        {
            // Ne pousse pas
        }
        else
        {
            double tauxPousse = tauxConditions >= 1.0 ? 1.0 : 0.5;
            Plante.CroissanceActuelle += Plante.VitesseCroissance * tauxPousse;

            // Mettre à jour le stade visuel
            if (Plante.CroissanceActuelle >= 1.0)
            {
                Plante.CroissanceActuelle = 1.0;
                Plante.StadeCroissance = 3; // 💐
                if (Plante.SemainesDepuisMaturite == 0)
                {
                    Plante.SemainesDepuisMaturite = 0;
                }    
            
            }
            else if (Plante.CroissanceActuelle >= 0.67)
            {
                Plante.StadeCroissance = 2; // 🌳
            }
            else if (Plante.CroissanceActuelle >= 0.34)
            {
                Plante.StadeCroissance = 1; // 🌿
            }
            else
            {
                Plante.StadeCroissance = 0; // 🌱
            }
        }

        // Gérer la mort après 2 semaines de maturité sans récolte
        if (Plante.CroissanceActuelle == 1.0)
        {
            Plante.SemainesDepuisMaturite++;
            if (Plante.SemainesDepuisMaturite > 2)
            {
                Plante.StadeCroissance = 4; // ☠️
            }
        }
    }
    public string Affichage()
    {
        if (Plante == null)
            return " . ";

        if (EstOrigine)
            return $" {Plante.NomPlante[0]} "; // Première lettre de la plante
        else
            return " * "; // Marque que c’est une case dépendante
    }
}