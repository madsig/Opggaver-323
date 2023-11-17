namespace KampTipping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var match = new Match();
            Console.Write("Gyldig tips: \n" +
                          " - H, U, B\n" + 
                          " - halvgardering: HU, HB, UB\n" + 
                          " - helgardering: HUB\n" + 
                          "Hva har du tippet for denne kampen? ");
            match.SetBet(Console.ReadLine());
            while (match.MatchIsRunning)
            {
                Console.Write("Kommandoer: \n" + 
                              " - H = scoring hjemmelag\n" + 
                              " - B = scoring bortelag\n" + 
                              " - X = kampen er ferdig\n" + 
                              "Angi kommando: ");
                var command = Console.ReadLine();
                match.MatchIsRunning = command != "X";
                match.AddGoal(command);
                Console.WriteLine($"Stillingen er {match.HomeGoals}-{match.AwayGoals}.");
            }

            
            Console.WriteLine($"Du tippet {match.GetResult()}");
        }
    }
}