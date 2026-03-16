namespace ObjectTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--self-test")
            {
                RunSelfTest();
                return;
            }

            Cube cube = new Cube(4, 2);
            const int cubeStartX = 1;
            const int cubeStartY = 5;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Rubik's Cube Console");
                Console.WriteLine("Coups disponibles : F B R L U D");
                Console.WriteLine("Tape Q pour quitter.");
                Console.WriteLine();

                cube.Display(cubeStartX, cubeStartY);

                int promptLine = cube.GetDisplayBottom(cubeStartY) + 1;
                Console.SetCursorPosition(0, promptLine);
                Console.Write("Votre coup : ");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char move = char.ToUpperInvariant(keyInfo.KeyChar);

                if (move == 'Q')
                {
                    break;
                }

                if (!cube.ApplyMove(move))
                {
                    Console.SetCursorPosition(0, promptLine + 2);
                    Console.Write("Commande invalide. Appuie sur une touche pour continuer...");
                    Console.ReadKey(true);
                }
            }
        }

        static void RunSelfTest()
        {
            char[] moves = ['F', 'B', 'R', 'L', 'U', 'D'];

            foreach (char move in moves)
            {
                Cube cube = CreateLabeledCube();
                string initialState = GetState(cube);

                for (int i = 0; i < 4; i++)
                {
                    cube.ApplyMove(move);
                }

                if (GetState(cube) != initialState)
                {
                    Console.WriteLine($"ECHEC: la rotation {move} n'est pas revenue a l'etat initial apres 4 tours.");
                    Environment.Exit(1);
                }
            }

            Cube leftCube = CreateLabeledCube();
            string top00 = leftCube.Top.Tuiles[0, 0].Couleur;
            string top10 = leftCube.Top.Tuiles[1, 0].Couleur;
            string top20 = leftCube.Top.Tuiles[2, 0].Couleur;
            string front00 = leftCube.Front.Tuiles[0, 0].Couleur;
            string front10 = leftCube.Front.Tuiles[1, 0].Couleur;
            string front20 = leftCube.Front.Tuiles[2, 0].Couleur;
            string bottom00 = leftCube.Bottom.Tuiles[0, 0].Couleur;
            string bottom10 = leftCube.Bottom.Tuiles[1, 0].Couleur;
            string bottom20 = leftCube.Bottom.Tuiles[2, 0].Couleur;
            string back02 = leftCube.back.Tuiles[0, 2].Couleur;
            string back12 = leftCube.back.Tuiles[1, 2].Couleur;
            string back22 = leftCube.back.Tuiles[2, 2].Couleur;

            leftCube.L();

            bool leftMoveIsCorrect =
                leftCube.Front.Tuiles[0, 0].Couleur == top00 &&
                leftCube.Front.Tuiles[1, 0].Couleur == top10 &&
                leftCube.Front.Tuiles[2, 0].Couleur == top20 &&
                leftCube.Bottom.Tuiles[0, 0].Couleur == front00 &&
                leftCube.Bottom.Tuiles[1, 0].Couleur == front10 &&
                leftCube.Bottom.Tuiles[2, 0].Couleur == front20 &&
                leftCube.back.Tuiles[0, 2].Couleur == bottom20 &&
                leftCube.back.Tuiles[1, 2].Couleur == bottom10 &&
                leftCube.back.Tuiles[2, 2].Couleur == bottom00 &&
                leftCube.Top.Tuiles[0, 0].Couleur == back22 &&
                leftCube.Top.Tuiles[1, 0].Couleur == back12 &&
                leftCube.Top.Tuiles[2, 0].Couleur == back02;

            if (!leftMoveIsCorrect)
            {
                Console.WriteLine("ECHEC: la rotation L ne suit pas le cycle attendu.");
                Environment.Exit(1);
            }

            Console.WriteLine("OK");
        }

        static Cube CreateLabeledCube()
        {
            Cube cube = new Cube(1, 1);

            LabelFace(cube.Top, "T");
            LabelFace(cube.Bottom, "B");
            LabelFace(cube.Left, "L");
            LabelFace(cube.Right, "R");
            LabelFace(cube.Front, "F");
            LabelFace(cube.back, "K");

            return cube;
        }

        static void LabelFace(Face face, string prefix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    face.Tuiles[i, j].Couleur = $"{prefix}{i}{j}";
                }
            }
        }

        static string GetState(Cube cube)
        {
            return GetFaceState(cube.Top) +
                   GetFaceState(cube.Bottom) +
                   GetFaceState(cube.Left) +
                   GetFaceState(cube.Right) +
                   GetFaceState(cube.Front) +
                   GetFaceState(cube.back);
        }

        static string GetFaceState(Face face)
        {
            string state = "";

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state += face.Tuiles[i, j].Couleur + "|";
                }
            }

            return state;
        }
    }
}
