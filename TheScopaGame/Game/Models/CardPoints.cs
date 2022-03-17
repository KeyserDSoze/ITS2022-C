namespace TheScopaGame
{
    public static class CardPoints
    {
        public static readonly Dictionary<CardValue, int> Instance = new()
        {
            { CardValue.Seven, 21 },
            { CardValue.Six, 18 },
            { CardValue.Ace, 16 },
            { CardValue.Five, 15 },
            { CardValue.Four, 14 },
            { CardValue.Three, 13 },
            { CardValue.Two, 12 },
            { CardValue.Jack, 10 },
            { CardValue.Knight, 10 },
            { CardValue.King, 10 },
        };
    }
}