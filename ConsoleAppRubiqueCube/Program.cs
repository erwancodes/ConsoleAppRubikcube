namespace ObjectTest
{
    class Program
    {
        private static readonly Dictionary<string, (string Name, string Algorithm)> RemarkablePatterns = new()
        {
            ["1"] = ("Damier", "R2 L2 U2 D2 F2 B2"),
            ["2"] = ("Cube dans le Cube dans le Cube", "F D F' D2 L' B' U L D R U L' F' U L U2"),
            ["3"] = ("ZigZag", "R L B F R L B F R L B F"),
            ["4"] = ("4 trous", "F2 B2 U D' L2 R2 U D'"),
            ["5"] = ("6 trous", "U D' B F' R L' U D'")
        };

        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--self-test")
            {
                RunSelfTest();
                return;
            }

            Cube cube = CreateInteractiveCube();
            const int cubeStartX = 1;
            const int cubeStartY = 9;
            string statusMessage = "Utilise les touches directes ou les presets 1 a 5.";

            while (true)
            {
                Console.Clear();
                DrawInstructions(statusMessage);
                cube.Display(cubeStartX, cubeStartY);

                int promptLine = cube.GetDisplayBottom(cubeStartY) + 1;
                Console.SetCursorPosition(0, promptLine);
                Console.Write("Touche : ");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char key = keyInfo.KeyChar;

                if (key == 'q' || key == 'Q')
                {
                    break;
                }

                if (key == 's' || key == 'S')
                {
                    cube = CreateInteractiveCube();
                    statusMessage = "Cube reinitialise.";
                    continue;
                }

                string keyText = key == '\0' ? keyInfo.Key.ToString() : key.ToString();

                if (TryApplyRemarkablePattern(ref cube, keyText, out string patternMessage))
                {
                    statusMessage = patternMessage;
                    continue;
                }

                if (TryApplyDirectMove(cube, key, out string moveMessage))
                {
                    statusMessage = moveMessage;
                }
                else
                {
                    statusMessage = "Touche invalide. Utilise f/F, b/B, r/R, l/L, u/U, d/D, 1-5, S ou Q.";
                }
            }
        }

        static void DrawInstructions(string statusMessage)
        {
            Console.WriteLine("Rubik's Cube Console");
            Console.WriteLine("Touches directes : f b r l u d");
            Console.WriteLine("Majuscule = rotation inverse : F B R L U D");
            Console.WriteLine("Presets : 1 Damier | 2 CubeCubeCube | 3 ZigZag");
            Console.WriteLine("          4 4 trous | 5 6 trous | S reset | Q quitter");
            Console.WriteLine();
            Console.WriteLine(statusMessage);
            Console.WriteLine();
        }

        static bool TryApplyRemarkablePattern(ref Cube cube, string key, out string message)
        {
            if (RemarkablePatterns.TryGetValue(key, out var pattern))
            {
                cube = CreateInteractiveCube();
                cube.ApplyAlgorithm(pattern.Algorithm);
                message = $"{pattern.Name} applique : {pattern.Algorithm}";
                return true;
            }

            message = "";
            return false;
        }

        static bool TryApplyDirectMove(Cube cube, char key, out string message)
        {
            message = "";

            if (!char.IsLetter(key))
            {
                return false;
            }

            char move = char.ToUpperInvariant(key);
            int turns = char.IsUpper(key) ? 3 : 1;

            if (!cube.ApplyMove(move, turns))
            {
                return false;
            }

            string displayedMove = turns == 3 ? $"{move}'" : move.ToString();
            message = $"Mouvement applique : {displayedMove}";
            return true;
        }

        static Cube CreateInteractiveCube()
        {
            return new Cube(4, 2);
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

            TestTokenEquivalence("F'", 'F', 3);
            TestTokenEquivalence("R2", 'R', 2);
            TestAlgorithmRuns("R2 L2 U2 D2 F2 B2");
            TestAlgorithmRuns("F D F' D2 L' B' U L D R U L' F' U L U2");
            TestAlgorithmRuns("R L B F R L B F R L B F");
            TestAlgorithmRuns("F2 B2 U D' L2 R2 U D'");
            TestAlgorithmRuns("U D' B F' R L' U D'");

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

        static void TestTokenEquivalence(string token, char move, int turns)
        {
            Cube tokenCube = CreateLabeledCube();
            Cube manualCube = CreateLabeledCube();

            if (!tokenCube.ApplyToken(token))
            {
                Console.WriteLine($"ECHEC: le token {token} n'est pas reconnu.");
                Environment.Exit(1);
            }

            manualCube.ApplyMove(move, turns);

            if (GetState(tokenCube) != GetState(manualCube))
            {
                Console.WriteLine($"ECHEC: le token {token} ne correspond pas au nombre de rotations attendu.");
                Environment.Exit(1);
            }
        }

        static void TestAlgorithmRuns(string algorithm)
        {
            Cube cube = CreateLabeledCube();

            if (!cube.ApplyAlgorithm(algorithm))
            {
                Console.WriteLine($"ECHEC: l'algorithme suivant n'a pas pu etre execute : {algorithm}");
                Environment.Exit(1);
            }
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
