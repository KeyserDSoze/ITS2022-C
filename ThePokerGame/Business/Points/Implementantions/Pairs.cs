using ITS2022_C.CardGameFramework;

namespace ThePokerGame.Business
{
    internal abstract class Pairs : IPointCalculator
    {
        public string Name => GetType().Name;
        public int Span { get; }
        public int FirstCount { get; }
        public int SecondCount { get; }
        public Pairs(int span, int firstCount, int secondCount = 0)
        {
            Span = span;
            FirstCount = firstCount;
            SecondCount = secondCount;
        }
        public List<PokerPoints> Find(List<Card> cards)
        {
            var cardsWithAces = new List<Card>();
            cardsWithAces.AddRange(cards.Where(x => x.Value > 1));
            cardsWithAces.AddRange(cards.Where(x => x.Value == 1).Select(x => new Card(14, x.Suit)));
            var sameValueCards = cardsWithAces.GroupBy(x => x.Value)
                .OrderByDescending(x => x.Count())
                .ThenByDescending(x => x.First().Value);
            if (sameValueCards.First().Count() >= FirstCount && 
                (SecondCount == 0 || sameValueCards.Skip(1).First().Count() >= SecondCount))
            {
                if (SecondCount > 0)
                {
                    var first = sameValueCards.First().ToList();
                    var second = sameValueCards.Skip(1).First().ToList();
                    var bestNextCard = FirstCount + SecondCount < 5 ?
                        sameValueCards.Skip(2).SelectMany(x => x)
                        .OrderByDescending(x => x.Value)
                        .ThenByDescending(x => x.Suit).First()
                        : Card.Empty;
                    return new List<PokerPoints> {
                        new PokerPoints(first.First().Value > second.First().Value ? first : second, 100),
                        new PokerPoints(first.First().Value > second.First().Value ? second : first, 10),
                        new PokerPoints(new List<Card>{ bestNextCard }, 1) };
                }
                else
                {
                    if (FirstCount + SecondCount > 1)
                    {
                        var bestNextCard = sameValueCards.Skip(1).SelectMany(x => x)
                            .OrderByDescending(x => x.Value)
                            .ThenByDescending(x => x.Suit).First();
                        return new List<PokerPoints> {
                            new PokerPoints(sameValueCards.First().ToList(), 10),
                            new PokerPoints(new List<Card>{ bestNextCard }, 1) };
                    }
                    else
                    {
                        var bestNextCard = cardsWithAces
                            .OrderByDescending(x => x.Value)
                            .ThenByDescending(x => x.Suit).First();
                        return new List<PokerPoints> {
                            new PokerPoints(new List<Card>{ bestNextCard }, 1) };
                    }
                }
            }
            return PokerPoints.EmptyList;
        }
    }
}