namespace ObjectTest // Vérifie que c'est bien le namespace de ton projet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RubikCube");
            
            Console.WriteLine("Affichage du Cube taille 4x2 :");
            Cube monCube = new Cube(4, 2);
            monCube.Display();
            
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("Appuie sur Entrée pour tester une autre taille...");
            Console.ReadLine();
            Console.Clear(); 
            
            Console.WriteLine("Affichage du Cube taille 6x3 :");
            Cube grosCube = new Cube(6, 3);
            grosCube.Display();

            Console.Read();
        }
    }
}