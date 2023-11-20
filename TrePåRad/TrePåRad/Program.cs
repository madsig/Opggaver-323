namespace TrePåRad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var b = new Board();
            var gameConsole = new GameConsole();

            var running = true;
            while (running)
            {
                GameConsole.Show(b.board);
                Console.Write("Skriv inn hvor du vil sette kryss (indeks 0-8): ");
                string position = Console.ReadLine();
                if (!int.TryParse(position, out var positionInt))
                {
                    Console.WriteLine("Feil med input");
                }
                else b.Mark(positionInt, 1);

                if (b.WinOrEnd(b.board, 1))
                {
                    running = false;
                    continue;
                }

                Thread.Sleep(2000);
                b.MarkRandom(2);

                if (b.WinOrEnd(b.board, 2))
                {
                    running = false;
                }
            }
        }
    }

    internal class GameConsole
    {
        public static void Show(Square[] board)
        {
            //Console.WriteLine("  a b c\r\n \u250c\u2500\u2500\u2500\u2500\u2500\u2510\r\n1\u2502o    \u2502\r\n2\u2502    o\u2502\r\n3\u2502\u00d7 \u00d7  \u2502\r\n \u2514\u2500\u2500\u2500\u2500\u2500\u2518");
            for (var i = 0; i < board.GetLength(0); i++)
            {
                var cell = (board[i].Owner == 0 ? '0' : board[i].Owner == 1 ? 'x' : 'o').ToString();
                Console.Write($"{cell}, ");
                if ((i+1) % 3 == 0) Console.WriteLine();
            }
        }
    }

    internal class Square
    {
        public int Owner { get; private set; } = 0;

        public bool IsEmpty()
        {
            return Owner == 0;
        }

        public bool TakenByPlayer1()
        {
            return Owner == 1;
        }

        public void Capture(int player)
        {
            if (IsEmpty())
            {
                Owner = player;
            }
        }
    }

    internal class Board
    {
        private readonly Random _random = new Random();

        public Square[] board = new Square[9]
        {
            new Square(),
            new Square(),
            new Square(),
            new Square(),
            new Square(),
            new Square(),
            new Square(),
            new Square(),
            new Square(),
        };

        public int Mark(int position, int player)
        {
            if (position is < 0 or > 8)
            {
                Console.WriteLine("Feil indeks");
                return 1;
            }
            if (board[position].IsEmpty())
            {
                board[position].Capture(player);
            }
            else
            {
                if (player == 1) Console.WriteLine("Rute er allerede tatt");
                return 1;
            }

            return 0;
        }

        public void MarkRandom(int player)
        {
            var randIndex =  _random.Next(0, 10);
            while (Mark(randIndex, player) == 1)
            {
                randIndex =  _random.Next(0, 10);
            }
        }

        public bool WinOrEnd(Square[] board, int player)
        {
            var includesZero = false;
            foreach (var square in board)
            {
                if (square.Owner == 0) includesZero = true;
            }
            if (!includesZero)
            {
                GameConsole.Show(board);
                Console.WriteLine("Spillet er uavgjort");
                return true;
            }

            if (Win(board))
            {
                GameConsole.Show(board);
                var winner = player == 1 ? "Du" : "Maskinen";
                Console.WriteLine($"{winner} vant!");
                return true;
            }

            return false;
        }

        //chatGPT 
        private static bool Win(Square[] board)
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i * 3].Owner != 0 && board[i * 3].Owner == board[i * 3 + 1].Owner && board[i * 3 + 1].Owner == board[i * 3 + 2].Owner)
                {
                    return true;
                }
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (board[i].Owner != 0 && board[i].Owner == board[i + 3].Owner && board[i + 3].Owner == board[i + 6].Owner)
                {
                    return true;
                }
            }

            // Check diagonals
            if (board[0].Owner != 0 && board[0].Owner == board[4].Owner && board[4].Owner == board[8].Owner)
            {
                return true;
            }

            if (board[2].Owner != 0 && board[2].Owner == board[4].Owner && board[4].Owner == board[6].Owner)
            {
                return true;
            }

            return false;
        }
    }
}