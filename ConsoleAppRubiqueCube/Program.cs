namespace ObjectTest;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Rubik's cube");
        
        Cube cube = new Cube();
        cube.Display();
        
        Console.ReadLine();
    }
}