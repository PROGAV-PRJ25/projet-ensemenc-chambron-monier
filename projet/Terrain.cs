public class Terrain{
    public string Type;
    public List<string> PlantesDispo = new List<string>();
    public Terrain (string type, List<string> plantesDispo){
        Type=type;
        if(Type == 'Terre'){
            PlantesDispo.Add('Menthe');
            PlantesDispo.Add('Carotte');
            PlantesDispo.Add('Tomate');
            PlantesDispo.Add('Lavande');
            PlantesDispo.Add('Poussiéreuse');
        }
        else if(Type == 'Argile'){
            PlantesDispo.Add('Fougère');
            PlantesDispo.Add('Betterave');
            PlantesDispo.Add('Iris des marais');
            PlantesDispo.Add('Nénuphar');
            PlantesDispo.Add('Frozen');
        }
        else{
            PlantesDispo.Add('Figuier nain');
            PlantesDispo.Add('Immortelle');
            PlantesDispo.Add('Cactus fleuri');
            PlantesDispo.Add('Melon');
            PlantesDispo.Add('Devosyne');
        }
    }
}