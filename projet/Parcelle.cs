public class Parcelle
{
    public Plante? Plante { get; set; }
    public int Luminosite { get; set; } = 0;
    public int Eau { get; set; } = 0;
    public string LigneHaut()
    {
        if (Plante != null)
        {
            return $"{Plante.Initiale}{Plante.EmojiStade}";
        }
        else
        {
            return "  "; // 2 espaces si vide
        }
    }
    public string LigneBas()
    {
        return $"{Luminosite}{Eau}";
    }
}