namespace TrePåRad
{
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

        public bool WinOrEnd(int player)
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

            if (Win())
            {
                GameConsole.Show(board);
                var winner = player == 1 ? "Du" : "Maskinen";
                Console.WriteLine($"{winner} vant!");
                return true;
            }

            return false;
        }


        //chatGPT - :(
        private bool Win()
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
