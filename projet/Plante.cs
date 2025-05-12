public class Plante
{
    public string NomPlante;
    int RaretePlante;
    public int StadeCroissance; 
    public string TerrainPrefere;
    bool EstVivace;
    bool EstComestible;
    bool EstCommercialisable;
    bool EstOrnementale;
    bool EstMedicinale;
    bool EstMagique;
    int Largeur;
    int Longueur;
    int EcartNecessaire;
    int EsperanceVie; // en semaines
    double VitesseCroissance; // unité de croissance par semaine (de 0 à 1)
    List<string> SaisonSemis;
    int BesoinEau; // en L/m²/semaine
    public double  BesoinLuminosite; // entre 0 et 1 par semaine (0 = pas de soleil - 1 = grand soleil)
    int TempMin;
    int TempMax;
    public int PrixAchatSemis;
    int PrixVenteProduit;
    public string EmojiStade => GetEmojiStade();
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
            3 => "☠️"
        };
    }
}