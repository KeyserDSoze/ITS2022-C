using ITS2022_C.CardGameFramework;

namespace ThePokerGame.Business
{
    internal class BasePokerPlayer : IPlayer
    {
        private readonly string name = Naming.Get(Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N")[0..7]);
        public string Name => $"{name[0..1].ToUpper()}{name[1..]}";

        public List<Card> Hand { get; } = new();
        private static readonly List<IPointCalculator> Calculators = new()
        {
            new RoyalFlushAndStraightFlushCalculator(),
            new PokerCalculator(),
            new FullHouse(),
            new Flush(),
            new Straight(),
            new ThreeOfAKind(),
            new TwoPairs(),
            new TwoOfAKind(),
            new HighCard()
        };

        public (int Value, string Name) GetPoints(ITable table, IEnumerable<IPlayer> otherPlayers)
        {
            List<Card> allCards = new();
            allCards.AddRange(Hand);
            allCards.AddRange(table.Surface);
            foreach (var calculator in Calculators)
            {
                var points = calculator.HasThatValue(allCards);
                if (points.Count > 0)
                {
                    int value = calculator.Span;
                    foreach (var point in points)
                    {
                        value += point.Multiplier * point.Cards.Sum(x => x.Value);
                    }
                    return (value, calculator.Name);
                }
            }
            return (0, string.Empty);
        }

        public (Card Card, List<Card> Taken) Play(ITable table, Deck deck)
            => (Card.Empty, Card.EmptyList);

        public void PutCardsInHand(List<Card> cards)
            => Hand.AddRange(cards);
    }
}