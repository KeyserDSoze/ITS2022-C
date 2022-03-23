namespace ITS2022_C.CardGameFramework
{
    public class Deck
    {
        public List<Card> Values { get; }
        public Deck(int maxValue = 10, int numberOfSuits = 4, bool shuffle = true)
        {
            Random random = new Random();
            Values = new();
            for (int i = 1; i <= maxValue; i++)
                for (int j = 1; j <= numberOfSuits; j++)
                    Values.Add(new Card(i, j));
            if (shuffle)
            {
                List<Card> shuffled = new();
                int count = Values.Count;
                for (int i = 0; i < count; i++)
                {
                    int index = random.Next(Values.Count);
                    var card = Values[index];
                    Values.Remove(card);
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