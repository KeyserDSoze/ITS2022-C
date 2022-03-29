using ITS2022_C.CardGameFramework;

namespace ThePokerGame.Business
{
    internal class RoyalFlushAndStraightFlush : IPointCalculator
    {
        public string Name => nameof(RoyalFlushAndStraightFlush);
        public int Span { get; } = 1_000_000_000;
        public List<PokerPoints> Find(List<Card> cards)
        {
            var allSuits = cards.GroupBy(x => x.Suit);
            var cardsWithTheSameColor = allSuits.OrderByDescending(x => x.Count()).First().ToList();
            //5 or more cards with the same color
            if (cardsWithTheSameColor.Count >= 5)
            {
                var hasScala = IPointCalculator.HasStraight(cardsWithTheSameColor);
                if (hasScala.IsOk)
                {
                    return new List<PokerPoints>
                    {
                        new PokerPoints(hasScala.ValidCards, 1)
                    };
                }
                else
                {
                    return PokerPoints.EmptyList;
                }
            }
            else
            {
                return PokerPoints.EmptyList;
            }
        }
    }
}