namespace SimulateurPotager{
    public enum TypePlante{
        Annuelle,
        Vivace
    }
    public enum UtilitePlante{
        Comestible,
        Commercialisable,
        Ornementale,
        Medicinale,
        Magique
    }
    public enum Saison{
        Printemps,
        Ete,
        Automne,
        Hiver
    }
    public enum TypeTerrain{
        Sable,
        Terre,
        Argile
    }
    public enum Pays{
        Egypte, // sable
        Bangladesh, // argile
        France, // terre
        Maroc, // sable + argile
        Mexique, // sable + terre
        Chine, // argile + terre
        ChezBea // TOUT
    }
}