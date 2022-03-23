using ITS2022_C.CardGameFramework;

namespace ThePokerGame.Business
{
    internal class PokerTable : ITable
    {
        public List<Card> Surface { get; } = new();
        public List<Card> PlayACard(Card card) => new();
        public void PutCardsOnSurface(List<Card> cards) 
            => Surface.AddRange(cards);
    }
}