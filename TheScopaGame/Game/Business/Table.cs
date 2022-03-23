namespace TheScopaGame
{
    public class Table
    {
        public List<Card> Surface { get; } = new();
        private static readonly List<Card> Empty = new();
        public List<Card> PlayACard(Card card)
        {
            var possibleCard = Surface.OrderByDescending(x => x.Seed).FirstOrDefault(x => x.Value == card.Value);
            if (possibleCard != null)
            {
                Surface.Remove(possibleCard);
                return new List<Card> { card, possibleCard };
            }
            else
            {
                Surface.Add(card);
                return Empty;
            }
        }
    }
}