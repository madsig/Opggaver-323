namespace TrePåRad
{
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
}
