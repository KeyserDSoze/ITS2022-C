namespace TheScopaGame
{
    public class Deck
    {
        private static readonly List<Card> Base = new();
        static Deck()
        {
            for (int i = 0; i < 40; i++)
                Base.Add(new Card((CardSeed)(i / 10), (CardValue)(i % 10)));
        }
        public List<Card> Values { get; }
        public Deck(bool shuffle = true)
        {
            Random random = new Random();
            List<Card> toShuffle = new();
            toShuffle.AddRange(Base);
            if (shuffle)
            {
                List<Card> shuffled = new();
                for (int i = 0; i < Base.Count; i++)
                {
                    int index = random.Next(toShuffle.Count);
                    var card = toShuffle[index];
                    toShuffle.Remove(card);
                    shuffled.Add(card);
                }
                Values = shuffled;
            }
        }
        public List<Card> GetCards(int numberOfCards)
        {
            var cards = Values.Take(numberOfCards).ToList();
            Values.RemoveRange(0, numberOfCards);
            return cards;
        }
        public bool IsOver => Values.Count == 0;
    }
}