namespace TheScopaGame
{
    public abstract class Player
    {
        private readonly string name = Naming.Get(Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N")[0..7]);
        public string Name => $"{name[0..1].ToUpper()}{name[1..]}";
        public List<Card> Hand { get; } = new();
        public List<Card> Taken { get; } = new();
        public int Scopa { get; private set; }
        public void RefillHand(Deck deck)
        {
            Hand.AddRange(deck.GetCards(3));
        }
        public (Card Card, List<Card> Taken, bool HasTaken) Play(Table table, Deck deck)
        {
            Card card = ChooseACard(table);
            var taken = table.PlayACard(card);
            if (table.Surface.Count == 0 && taken.Count > 0)
                Scopa++;
            if (taken.Count > 0)
                Taken.AddRange(taken);
            Hand.Remove(card);
            if (Hand.Count == 0 && !deck.IsOver)
                RefillHand(deck);
            return (card, taken, taken.Count > 0);
        }
        public int GetPoints(IEnumerable<Player> otherPlayers)
        {
            int points = 0;
            if (!otherPlayers.Any(x => x.Taken.Count >= Taken.Count))
            {
                points++;
                Console.WriteLine($"{Name} has more cards with {Taken.Count} cards.");
            }
            if (!otherPlayers.Any(x => x.Taken.Where(x => x.Seed == CardSeed.Coins).Count() >= Hand.Where(x => x.Seed == CardSeed.Coins).Count()))
            {
                points++;
                Console.WriteLine($"{Name} has more coins with {Taken.Where(x => x.Seed == CardSeed.Coins).Count()} coins.");
            }
            if (Taken.Any(x => x.Seed == CardSeed.Coins && x.Value == CardValue.Seven))
            {
                points++;
                Console.WriteLine($"{Name} has seven the beauty");
            }
            if (!otherPlayers.Any(x => x.Taken.Sum(x => CardPoints.Instance[x.Value]) >= Taken.Sum(x => CardPoints.Instance[x.Value])))
            {
                points++;
                Console.WriteLine($"{Name} has the Primiera with {Taken.Sum(x => CardPoints.Instance[x.Value])} points");
            }
            if (Scopa > 0)
                Console.WriteLine($"{Name} has {Scopa} scopa{(Scopa > 1 ? "s" : string.Empty)}");
            return points + Scopa;
        }
        private protected abstract Card ChooseACard(Table table);
    }
}