namespace ObjectTest;

public class Face
{
    public string[,] Couleurs { get; set; }
    public string type { get; set; }
    
    public Face(string couleur, string type)
    {
        Couleurs = new string[3, 3];
        
        Couleurs[0, 0] = "Rouge";  // Coin haut-gauche
        Couleurs[1, 1] = "Rouge";  // Centre
        Couleurs[2, 2] = "Rouge";  // Coin bas-droite
        this.type = type;
    }

    public void Display(int x, int y)
    {
        
    }
}