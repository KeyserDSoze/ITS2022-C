using ITS2022_C.CardGameFramework;

namespace ThePokerGame.Business
{
    internal class Straight : IPointCalculator
    {
        public int Span { get; } = 300_000_000;
        public List<PokerPoints> HasThatValue(List<Card> cards)
        {
            var orderedCards = cards.OrderByDescending(x => x.Value).ToList();
            //5 or more cards with the same color
            if (orderedCards.Count >= 5)
            {
                var hasScala = IPointCalculator.HasScala(orderedCards);
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