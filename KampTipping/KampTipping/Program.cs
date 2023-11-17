namespace KampTipping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Gyldig tips: \n" +
                          " - H, U, B\n" + 
                          " - halvgardering: HU, HB, UB\n" + 
                          " - helgardering: HUB\n" + 
                          "Hva har du tippet for denne kampen? ");
            var bet = Console.ReadLine();
            var match = new Match(bet);

            while (match.MatchIsRunning)
            {
                Console.Write("Kommandoer: \n" + 
                              " - H = scoring hjemmelag\n" + 
                              " - B = scoring bortelag\n" + 
                              " - X = kampen er ferdig\n" + 
                              "Angi kommando: ");
                var command = Console.ReadLine();
                if (command == "X") match.Stop();
                match.AddGoal(command);
                Console.WriteLine($"Stillingen er {match.HomeGoals}-{match.AwayGoals}.");
            }

            
            Console.WriteLine($"Du tippet {match.GetResult()}");
        }
    }
}