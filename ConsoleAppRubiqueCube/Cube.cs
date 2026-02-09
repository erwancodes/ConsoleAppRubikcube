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
        int gap = 0; 
        
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
        Front.RotateClockwise(); 
        Tuile[] tempAdj = new Tuile[3];
        for (int i = 0; i < 3; i++)
            tempAdj[i] = Top.Tuiles[2, i];

        for (int i = 0; i < 3; i++)
            Top.Tuiles[2, i] = Left.Tuiles[2 - i, 2];

        for (int i = 0; i < 3; i++)
            Left.Tuiles[i, 2] = Bottom.Tuiles[0, i];

        for (int i = 0; i < 3; i++)
            Bottom.Tuiles[0, i] = Right.Tuiles[2 - i, 0];

        for (int i = 0; i < 3; i++)
            Right.Tuiles[i, 0] = tempAdj[i];
    }

    public void B()
    {
        back.RotateClockwise(); 
        Tuile[] tempAdj = new Tuile[3];
        for (int i = 0; i < 3; i++)
            tempAdj[i] = Top.Tuiles[0, i];

        for (int i = 0; i < 3; i++)
            Top.Tuiles[0, i] = Right.Tuiles[i, 2];

        for (int i = 0; i < 3; i++)
            Right.Tuiles[i, 2] = Bottom.Tuiles[2, 2 - i];

        for (int i = 0; i < 3; i++)
            Bottom.Tuiles[2, i] = Left.Tuiles[i, 0];

        for (int i = 0; i < 3; i++)
            Left.Tuiles[i, 0] = tempAdj[2 - i];
    }

    public void R()
    {
        Right.RotateClockwise(); 
        Tuile[] tempAdj = new Tuile[3];
        for (int i = 0; i < 3; i++)
            tempAdj[i] = Top.Tuiles[i, 2];

        for (int i = 0; i < 3; i++)
            Top.Tuiles[i, 2] = Front.Tuiles[i, 2];

        for (int i = 0; i < 3; i++)
            Front.Tuiles[i, 2] = Bottom.Tuiles[i, 2];

        for (int i = 0; i < 3; i++)
            Bottom.Tuiles[i, 2] = back.Tuiles[2 - i, 0];

        for (int i = 0; i < 3; i++)
            back.Tuiles[i, 0] = tempAdj[2 - i];
    }

    public void L()
    {
        Left.RotateClockwise(); 
        Tuile[] tempAdj = new Tuile[3];
        for (int i = 0; i < 3; i++)
            tempAdj[i] = Top.Tuiles[i, 0];

        for (int i = 0; i < 3; i++)
            Top.Tuiles[i, 0] = back.Tuiles[2 - i, 2];

        for (int i = 0; i < 3; i++)
            back.Tuiles[i, 2] = Bottom.Tuiles[i, 0];

        for (int i = 0; i < 3; i++)
            Bottom.Tuiles[i, 0] = Front.Tuiles[i, 0];

        for (int i = 0; i < 3; i++)
            Front.Tuiles[i, 0] = tempAdj[i];
    }

    public void U()
    {
        Top.RotateClockwise(); 
        Tuile[] tempAdj = new Tuile[3];
        for (int i = 0; i < 3; i++)
            tempAdj[i] = Front.Tuiles[0, i];

        for (int i = 0; i < 3; i++)
            Front.Tuiles[0, i] = Right.Tuiles[0, i];

        for (int i = 0; i < 3; i++)
            Right.Tuiles[0, i] = back.Tuiles[0, i];

        for (int i = 0; i < 3; i++)
            back.Tuiles[0, i] = Left.Tuiles[0, i];

        for (int i = 0; i < 3; i++)
            Left.Tuiles[0, i] = tempAdj[i];
    }

    public void D()
    {
        Bottom.RotateClockwise(); 
        Tuile[] tempAdj = new Tuile[3];
        for (int i = 0; i < 3; i++)
            tempAdj[i] = Front.Tuiles[2, i];

        for (int i = 0; i < 3; i++)
            Front.Tuiles[2, i] = Left.Tuiles[2, i];

        for (int i = 0; i < 3; i++)
            Left.Tuiles[2, i] = back.Tuiles[2, i];

        for (int i = 0; i < 3; i++)
            back.Tuiles[2, i] = Right.Tuiles[2, i];

        for (int i = 0; i < 3; i++)
            Right.Tuiles[2, i] = tempAdj[i];
    }
    
}