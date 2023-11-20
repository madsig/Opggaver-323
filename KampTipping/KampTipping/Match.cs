using System.Dynamic;

namespace KampTipping
{
    internal class Match
    {
        public int HomeGoals { get; private set; }
        public int AwayGoals { get; private set; }
        public bool MatchIsRunning { get; private set; } = true;

        private readonly string _bet;

        public Match(string bet)
        {
            _bet = bet;
        }

        public void Stop()
        {
            MatchIsRunning = false;
        }

        public void AddGoal(string side)
        {
            switch (side) //  >:)
            {
                case "H":
                    HomeGoals++;
                    break;
                case "B":
                    AwayGoals++;
                    break;
            }
        }

        public string GetResult()
        {
            var result = HomeGoals == AwayGoals ? "U" : HomeGoals > AwayGoals ? "H" : "B";
            var isBetCorrect = _bet.Contains(result);
            var isBetCorrectText = isBetCorrect ? "riktig" : "feil";
            return isBetCorrectText;
        }
    }
}
