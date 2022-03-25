using ITS2022_C.CardGameFramework;

namespace ThePokerGame.Business
{
    internal class Straight : IPointCalculator
    {
        public string Name => nameof(Straight);
        public int Span { get; } = 300_000_000;
        public List<PokerPoints> Find(List<Card> cards)
        {
            var orderedCards = cards.OrderByDescending(x => x.Value).ToList();
            var hasStraight = IPointCalculator.HasStraight(orderedCards);
            if (hasStraight.IsOk)
            {
                return new List<PokerPoints>
                    {
                        new PokerPoints(hasStraight.ValidCards, 1)
                    };
            }
            else
            {
                return PokerPoints.EmptyList;
            }
        }
    }
}