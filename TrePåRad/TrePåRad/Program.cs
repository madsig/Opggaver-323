namespace TrePåRad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var b = new Board();

            var running = true;
            while (running)
            {
                GameConsole.Show(b.board);
                Console.Write("Skriv inn hvor du vil sette kryss (indeks 0-8): ");
                string position = Console.ReadLine();
                Console.WriteLine();
                if (!int.TryParse(position, out var positionInt))
                {
                    Console.WriteLine("Feil med input");
                }
                else b.Mark(positionInt, 1);

                if (b.WinOrEnd(1))
                {
                    running = false;
                    continue;
                }

                Thread.Sleep(2000);
                b.MarkRandom(2);

                if (b.WinOrEnd(2))
                {
                    running = false;
                }
            }
        }
    }
}