namespace ITS2022_C.CardGameFramework
{
    public interface IPlayer
    {
        List<Card> Hand { get; }
        string Name { get; }
        public (Card Card, List<Card> Taken) Play(ITable table, Deck deck);
        int GetPoints(ITable table, IEnumerable<IPlayer> otherPlayers);
        void PutCardsInHand(List<Card> cards);
    }
}