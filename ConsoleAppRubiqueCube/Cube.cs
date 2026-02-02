namespace ObjectTest;

public class Cube
{
    public Face Top { get; set; }
    public Face Bottom { get; set; }
    public Face Left { get; set; }
    public Face Right { get; set; }
    public Face Front { get; set; }
    public Face back { get; set; }
    public int HauteurTuile { get; set; }
    public int LargeurTuile { get; set; }
    
    public Cube(int largeurTuile, int hauteurTuile)
    {
        this.LargeurTuile = largeurTuile;
        this.HauteurTuile = hauteurTuile;
        
        Top = new Face("Blanc", largeurTuile, hauteurTuile);
        Bottom = new Face("Jaune", largeurTuile, hauteurTuile);
        Left = new Face("Bleu", largeurTuile, hauteurTuile);
        Right = new Face("Vert", largeurTuile, hauteurTuile);
        Front = new Face("Rouge", largeurTuile, hauteurTuile);
        back = new Face("Orange", largeurTuile, hauteurTuile);
    }
    public void Display()
    {
        int fW = 3 * LargeurTuile; 
        int fH = 3 * HauteurTuile; 
        int gap = 1;
        
        int startX = 1;
        int startY = 1;
        
        Top.Display(startX + fW + gap, startY);
        Left.Display(startX, startY + fH + gap);
        Front.Display(startX + fW + gap, startY + fH + gap);
        Right.Display(startX + 2 * (fW + gap), startY + fH + gap);
        back.Display(startX + 3 * (fW + gap), startY + fH + gap);
        Bottom.Display(startX + fW + gap, startY + 2 * (fH + gap));
    }

    public void F()
    {
        Tuile[] tempAdj = new Tuile[3];
        tempAdj[0] = Top.Tuiles[2, 0];
        tempAdj[1] = Top.Tuiles[2, 1];
        tempAdj[2] = Top.Tuiles[2, 2];
        
        Top.Tuiles[2, 0] = Left.Tuiles[0, 2];
        Top.Tuiles[2, 1] = Left.Tuiles[1, 2];
        Top.Tuiles[2, 2] = Left.Tuiles[2, 2];
        
        Left.Tuiles[0, 2] = Bottom.Tuiles[0, 0];
        Left.Tuiles[1, 2] = Bottom.Tuiles[0, 1];
        Left.Tuiles[2, 2] = Bottom.Tuiles[0, 2];
        
        Bottom.Tuiles[0, 0] = Right.Tuiles[2, 0]; 
        Bottom.Tuiles[0, 1] = Right.Tuiles[1, 0];
        Bottom.Tuiles[0, 2] = Right.Tuiles[0, 0]; 
        
        Right.Tuiles[0, 0] = tempAdj[0];
        Right.Tuiles[1, 0] = tempAdj[1];
        Right.Tuiles[2, 0] = tempAdj[2];
    }
    
}