namespace ObjectTest;

public class Cube
{
    public Face Top { get; set; }
    public Face Bottom { get; set; }
    public Face Left { get; set; }
    public Face Right { get; set; }
    public Face Front { get; set; }
    public Face back { get; set; }
    
    public Cube()
    {
        Top = new Face("Blanc", "Top");
        Bottom = new Face("Jaune", "Bottom");
        Left = new Face("Bleu", "Left");
        Right = new Face("Vert", "Right");
        Front = new Face("Rouge", "Front");
        back = new Face("Orange", "Back");
    }
    
}