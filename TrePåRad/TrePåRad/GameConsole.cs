namespace TrePåRad
{
    internal class GameConsole
    {
        public static void Show(Square[] board)
        {
            //Console.WriteLine("  a b c\r\n \u250c\u2500\u2500\u2500\u2500\u2500\u2510\r\n1\u2502o    \u2502\r\n2\u2502    o\u2502\r\n3\u2502\u00d7 \u00d7  \u2502\r\n \u2514\u2500\u2500\u2500\u2500\u2500\u2518");
            for (var i = 0; i < board.GetLength(0); i++)
            {
                var cell = (board[i].Owner == 0 ? ' ' : board[i].Owner == 1 ? 'x' : 'o').ToString();
                Console.Write(cell);
                if ((i + 1) % 3 != 0) Console.Write("|");
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine();
                    if (i < 6) Console.WriteLine("—+—+—");
                }
            }
        }
    }
}
