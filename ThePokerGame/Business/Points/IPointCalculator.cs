using ITS2022_C.CardGameFramework;

namespace ThePokerGame.Business
{
    internal interface IPointCalculator
    {
        int Span { get; }
        List<PokerPoints> HasThatValue(List<Card> cards);
        public static (bool IsOk, List<Card> ValidCards) HasScala(List<Card> cards)
        {
            var aces = cards
                        .Where(x => x.Value == 1)
                        .Select(x => new Card(14, x.Value));
            var orderedCards = new List<Card>();
            orderedCards.AddRange(aces);
            orderedCards.AddRange(cards.OrderByDescending(x => x.Value));
            List<Card> validCards = new() { cards.First() };
            for (int i = 0; i < cards.Count - 1; i++)
            {
                if (orderedCards[i + 1].Value - orderedCards[i].Value != -1)
                {
                    validCards.Clear();
                    validCards.Add(cards[i]);
                }
                else
                    validCards.Add(cards[i + 1]);
                if (validCards.Count == 5)
                    return (true, validCards);
            }
            return (false, validCards);
        }
    }
}