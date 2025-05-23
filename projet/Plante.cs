public class Plante
{
    public string NomPlante;
    public int RaretePlante;
    public int StadeCroissance;
    public string TerrainPrefere;
    public bool EstVivace;
    public bool EstComestible;
    public bool EstCommercialisable;
    public bool EstOrnementale;
    public bool EstMedicinale;
    public bool EstMagique;
    public int Largeur;
    public int Longueur;
    public int EcartNecessaire;
    public int EsperanceVie; // en semaines
    public double VitesseCroissance; // unité de croissance par semaine (de 0 à 1)
    public List<string> SaisonSemis;
    public int BesoinEau; // en L/m²/semaine
    public double BesoinLuminosite; // entre 0 et 1 par semaine (0 = pas de soleil - 1 = grand soleil)
    public int TempMin;
    public int TempMax;
    public int PrixAchatSemis;
    public int PrixVenteProduit;
    public string EmojiStade => GetEmojiStade();
    public double CroissanceActuelle = 0.0; // de 0 à 1
    public int SemainesDepuisMaturite = 0; // décompte après 100%

    public Plante(string nomPlante, int raretePlante, int stadeCroissance, string terrainPrefere, bool estVivace, bool estComestible, bool estCommercialisable, bool estOrnementale, bool estMedicinale, bool estMagique, int largeur, int longueur, int ecartNecessaire, int esperanceVie, double vitesseCroissance, List<string> saisonSemis, int besoinEau, double besoinLuminosite, int tempMin, int tempMax, int prixAchatSemis, int prixVenteProduit)
    {
        NomPlante = nomPlante;
        RaretePlante = raretePlante;
        StadeCroissance = stadeCroissance;
        TerrainPrefere = terrainPrefere;
        EstVivace = estVivace;
        EstComestible = estComestible;
        EstCommercialisable = estCommercialisable;
        EstOrnementale = estOrnementale;
        EstMedicinale = estMedicinale;
        EstMagique = estMagique;
        Largeur = largeur;
        Longueur = longueur;
        EcartNecessaire = ecartNecessaire;
        EsperanceVie = esperanceVie;
        VitesseCroissance = vitesseCroissance;
        SaisonSemis = saisonSemis;
        BesoinEau = besoinEau;
        BesoinLuminosite = besoinLuminosite;
        TempMin = tempMin;
        TempMax = tempMax;
        PrixAchatSemis = prixAchatSemis;
        PrixVenteProduit = prixVenteProduit;
    }
    public string Initiale => string.IsNullOrEmpty(NomPlante) ? " " : NomPlante.Substring(0, 1).ToUpper();

    public string GetEmojiStade()
    {
        return StadeCroissance switch
        {
            0 => "🌱",
            1 => "🌿",
            2 => "🌳",
            3 => "💐",
            4 => "☠️ ",
            _ => "❓"
        };
    }

    public string AfficherDetails()
    {
        return $"Nom: {NomPlante}\n" +
               $"Rarete: {RaretePlante}\n" +
               $"Stade de Croissance: {GetEmojiStade()}\n" +
               $"Terrain Préféré: {TerrainPrefere}\n" +
               $"Vivace: {EstVivace}\n" +
               $"Comestible: {EstComestible}\n" +
               $"Commercialisable: {EstCommercialisable}\n" +
               $"Ornementale: {EstOrnementale}\n" +
               $"Medicinale: {EstMedicinale}\n" +
               $"Magique: {EstMagique}\n" +
               $"Dimensions (lxL): {Largeur}x{Longueur}\n" +
               $"Ecart Nécessaire: {EcartNecessaire}\n" +
               $"Espérance de Vie: {EsperanceVie} semaines\n" +
               $"Vitesse de Croissance: {VitesseCroissance * 100}% par semaine\n" +
               $"Saisons de Semis: {string.Join(", ", SaisonSemis)}\n" +
               $"Besoin en Eau: {BesoinEau} L/m²/semaine\n" +
               $"Besoin en Luminosité: {BesoinLuminosite * 100}%\n" +
               $"Température Minimum: {TempMin}°C\n" +
               $"Température Maximum: {TempMax}°C\n" +
               $"Prix d'Achat du Semis: {PrixAchatSemis} crédits\n" +
               $"Prix de Vente du Produit: {PrixVenteProduit} crédits\n";
    }

    public string AfficherDetailsEssentiels()
    {
        return $"Nom: {NomPlante}\n" +
               $"Rarete: {RaretePlante}\n" +
               $"Terrain Préféré: {TerrainPrefere}\n" +
               $"Dimensions (lxL): {Largeur}x{Longueur}\n" +
               $"Ecart Nécessaire: {EcartNecessaire}\n" +
               $"Saisons de Semis: {string.Join(", ", SaisonSemis)}\n" +
               $"Besoin en Eau: {BesoinEau} L/m²/semaine\n" +
               $"Besoin en Luminosité: {BesoinLuminosite * 100}%\n" +
               $"Température Minimum: {TempMin}°C\n" +
               $"Température Maximum: {TempMax}°C\n";
    }
}