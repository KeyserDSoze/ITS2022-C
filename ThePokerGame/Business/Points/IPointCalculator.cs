using ITS2022_C.CardGameFramework;
using System.Collections;

namespace ThePokerGame.Business
{
    internal interface IPointCalculator
    {
        string Name { get; }
        int Span { get; }
        List<PokerPoints> HasThatValue(List<Card> cards);
        public static (bool IsOk, List<Card> ValidCards) HasStraight(List<Card> cards)
        {
            var aces = cards
                        .Where(x => x.Value == 1)
                        .Select(x => new Card(14, x.Value));
            var orderedCards = new List<Card>();
            orderedCards.AddRange(aces);
            orderedCards.AddRange(cards.OrderByDescending(x => x.Value));
            orderedCards = orderedCards
                            .GroupBy(x => x.Value)
                            .Select(x => x.First()).ToList();
            List<Card> validCards = new() { orderedCards.First() };
            for (int i = 0; i < orderedCards.Count - 1; i++)
            {
                if (orderedCards[i + 1].Value - orderedCards[i].Value != -1)
                {
                    validCards.Clear();
                    validCards.Add(orderedCards[i]);
                }
                else
                    validCards.Add(orderedCards[i + 1]);
                if (validCards.Count == 5)
                    return (true, validCards);
            }
            return (false, validCards);
        }
    }
}