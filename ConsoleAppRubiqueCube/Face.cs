namespace ObjectTest;

public class Face
{
    public string[,] Couleurs { get; set; }
    public string type { get; set; }
    public int HauteurTuile { get; set; }
    public int LargeurTuile { get; set; }
    
    public Face(string couleur, string type)
    {
        Couleurs = new string[3, 3];
        
        Couleurs[0, 0] = "Rouge";  
        this.type = type;
        this.HauteurTuile = 0;
        this.LargeurTuile = 0;
    }

    public void Display(int x, int y)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.SetCursorPosition(x + j, y + i);
                Console.BackgroundColor = GetColor(Couleurs[i, j]);
                Console.Write(" ");
            }
        }
        Console.ResetColor();
    }

    public ConsoleColor GetColor(string codeCouleur)
    {
        switch (codeCouleur.ToUpper())
        {
            case "R": return ConsoleColor.Red;
            case "G": return ConsoleColor.Green;
            case "B": return ConsoleColor.Blue;
            case "Y": return ConsoleColor.Yellow;
            case "W": return ConsoleColor.White;
            case "O": return ConsoleColor.DarkYellow;
            default: return ConsoleColor.Gray;
        }
    }
}