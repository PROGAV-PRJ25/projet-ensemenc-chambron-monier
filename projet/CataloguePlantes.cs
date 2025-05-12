public static class CataloguePlantes
{
    public static List<Plante> PlantesDisponibles = new List<Plante>
    {
        // --- Terre ---
        new Plante("Menthe", 1, 0, "Terre", true, true, true, false, true, false, 1, 1, 0, 999, 0.0625, new() { "Printemps", "Automne" }, 3, 1, 10, 25, 0, 5),
        new Plante("Carotte", 2, 0, "Terre", false, true, true, false, false, false, 1, 1, 0, 16, 0.0625, new() { "Printemps", "Automne" }, 3, 0.5, 10, 20, 1, 3),
        new Plante("Tomate", 3, 0, "Terre", false, true, true, false, false, false, 2, 1, 0, 12, 0.083, new() { "Printemps", "Été" }, 5, 0.7, 18, 28, 2, 5),
        new Plante("Lavande", 4, 0, "Terre", true, false, true, true, false, false, 2, 1, 1, 999, 0.05, new() { "Printemps", "Été" }, 2, 0.8, 15, 30, 3, 8),
        new Plante("Poussiéreuse", 5, 0, "Terre", false, false, true, false, true, true, 2, 2, 1, 10, 0.1, new() { "Été" }, 3, 0.9, 20, 30, 5, 10),

        // --- Argile ---
        new Plante("Fougère", 1, 0, "Argile", true, false, true, true, false, false, 1, 1, 0, 999, 0.05, new() { "Printemps" }, 2, 0.4, 10, 20, 0, 4),
        new Plante("Betterave", 2, 0, "Argile", false, true, true, false, false, false, 1, 1, 0, 14, 0.071, new() { "Printemps", "Automne" }, 4, 0.6, 12, 22, 1, 4),
        new Plante("Iris des marais", 3, 0, "Argile", true, false, true, true, false, false, 2, 1, 0, 999, 0.0625, new() { "Printemps" }, 3, 0.6, 10, 25, 2, 6),
        new Plante("Nénuphar", 4, 0, "Argile", true, false, true, true, false, false, 2, 1, 1, 999, 0.05, new() { "Printemps", "Été" }, 5, 0.7, 15, 25, 3, 8),
        new Plante("Frozen", 5, 0, "Argile", false, false, true, true, true, true, 2, 2, 1, 12, 0.083, new() { "Hiver" }, 4, 0.5, 5, 15, 5, 12),

        // --- Sable ---
        new Plante("Figuier nain", 1, 0, "Sable", true, true, true, false, false, false, 1, 1, 0, 999, 0.0625, new() { "Printemps" }, 3, 0.7, 15, 25, 0, 4),
        new Plante("Immortelle", 2, 0, "Sable", true, false, true, false, false, false, 1, 1, 0, 999, 0.05, new() { "Printemps", "Été" }, 2, 0.8, 15, 30, 1, 5),
        new Plante("Cactus fleuri", 3, 0, "Sable", true, false, true, false, false, false, 2, 1, 0, 999, 0.04, new() { "Printemps" }, 1, 0.9, 20, 35, 2, 10),
        new Plante("Melon", 4, 0, "Sable", false, true, true, false, false, false, 2, 1, 1, 12, 0.083, new() { "Été" }, 6, 0.8, 20, 30, 3, 4),
        new Plante("Devosyne", 5, 0, "Sable", false, false, true, true, true, true, 2, 2, 1, 10, 0.1, new() { "Été" }, 3, 0.9, 25, 35, 5, 15)
    };

    public static Plante? GetPlanteParNom(string nom)
    {
        return PlantesDisponibles.FirstOrDefault(p => p.NomPlante.Equals(nom, StringComparison.OrdinalIgnoreCase));
    }
}