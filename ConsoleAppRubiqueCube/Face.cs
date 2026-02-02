public class Face
{
    public Tuile[,] Tuiles { get; set; }

    public int HauteurTuile { get; set; }
    public int LargeurTuile { get; set; }

    public Face(string couleur, int largeurTuile, int hauteurTuile)
    {
        this.LargeurTuile = largeurTuile;
        this.HauteurTuile = hauteurTuile;
        
        Tuiles = new Tuile[3, 3];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Tuiles[i, j] = new Tuile(couleur, largeurTuile, hauteurTuile);
            }
        }
    }
    
    public void Display(int x, int y)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int posX = x + (j * LargeurTuile);
                int posY = y + (i * HauteurTuile);
                Tuiles[i, j].Display(posX, posY);
            }
        }
    }
}