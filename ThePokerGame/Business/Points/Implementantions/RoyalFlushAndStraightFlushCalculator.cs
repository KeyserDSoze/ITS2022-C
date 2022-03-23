using ITS2022_C.CardGameFramework;

namespace ThePokerGame.Business
{
    internal class RoyalFlushAndStraightFlushCalculator : IPointCalculator
    {
        public int Span { get; } = 1_000_000_000;
        public List<PokerPoints> HasThatValue(List<Card> cards)
        {
            var allSuits = cards.GroupBy(x => x.Suit);
            var cardsWithTheSameColor = allSuits.OrderByDescending(x => x.Key).First().ToList();
            //5 or more cards with the same color
            if (cardsWithTheSameColor.Count >= 5)
            {
                var hasScala = IPointCalculator.HasScala(cardsWithTheSameColor);
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