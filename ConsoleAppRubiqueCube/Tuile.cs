public class Tuile
{
    public string Couleur { get; set; }
    public ConsoleColor ConsoleCouleur { get; set; }
    public int HauteurTuile { get; set; }
    public int LargeurTuile { get; set; }

    public Tuile(string couleur, int largeurTuile, int hauteurTuile)
    {
        this.Couleur = couleur;
        this.LargeurTuile = largeurTuile;
        this.HauteurTuile = hauteurTuile;
        
        this.ConsoleCouleur = GetColor(couleur);
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
    
    public void Display(int x, int y)
    {
        Console.BackgroundColor = ConsoleCouleur;
        
        for (int h = 0; h < HauteurTuile; h++)
        {
            for (int w = 0; w < LargeurTuile; w++)
            {
                Console.SetCursorPosition(x + w, y + h);
                Console.Write(" ");
            }
        }
        Console.ResetColor();
    }
}