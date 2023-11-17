using System.Dynamic;

namespace KampTipping
{
    internal class Match
    {
        public int HomeGoals { get; private set; }
        public int AwayGoals { get; private set; }
        public bool MatchIsRunning = true;

        private string _bet = "";
       
        public void SetBet(string bet)
        {
            _bet = bet;
        }

        public void AddGoal(string side)
        {
            if (side == "H") HomeGoals++;
            else if (side == "B") AwayGoals++;
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
