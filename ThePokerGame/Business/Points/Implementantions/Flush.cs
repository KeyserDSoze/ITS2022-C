using ITS2022_C.CardGameFramework;

namespace ThePokerGame.Business
{
    internal class Flush : IPointCalculator
    {
        public string Name => nameof(Flush);
        public int Span => 400_000_000;

        public List<PokerPoints> Find(List<Card> cards)
        {
            var allSuits = cards.GroupBy(x => x.Suit);
            var cardsWithTheSameColor = allSuits.OrderByDescending(x => x.Key).First().ToList();
            if (cardsWithTheSameColor.Count >= 5)
            {
                var bestCardsWithSameColor = cardsWithTheSameColor.OrderByDescending(x => x.Value).Take(5).ToList();
                return new List<PokerPoints> { new PokerPoints(bestCardsWithSameColor, 1) };
            }
            return PokerPoints.EmptyList;
        }
    }
}