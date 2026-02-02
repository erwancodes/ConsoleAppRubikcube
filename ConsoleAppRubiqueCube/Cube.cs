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
    
    public Cube()
    {
        Top = new Face("Blanc", "Top");
        Bottom = new Face("Jaune", "Bottom");
        Left = new Face("Bleu", "Left");
        Right = new Face("Vert", "Right");
        Front = new Face("Rouge", "Front");
        back = new Face("Orange", "Back");
        HauteurTuile = 0;
        LargeurTuile = 0;
    }
    
    public void Display()
    {
        Top.Display(5, 1);
        Left.Display(1, 5);    // Tout à gauche
        Front.Display(5, 5);   // Au centre (sous Top)
        Right.Display(9, 5);   // À droite de Front
        back.Display(13, 5);   // À droite de Right (le dos du cube)
        Bottom.Display(5, 9);
    }
    
}