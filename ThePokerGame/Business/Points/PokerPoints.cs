using ITS2022_C.CardGameFramework;

namespace ThePokerGame.Business
{
    internal record PokerPoints(List<Card> Cards, int Multiplier)
    {
        public static readonly List<PokerPoints> EmptyList = new();
    }
}