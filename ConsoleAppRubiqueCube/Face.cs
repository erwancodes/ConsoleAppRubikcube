namespace ObjectTest;

public class Face
{
    public string couleur { get; set; }
    public string type { get; set; }
    
    public Face(string couleur, string type)
    {
        this.couleur = couleur;
        this.type = type;
    }
}