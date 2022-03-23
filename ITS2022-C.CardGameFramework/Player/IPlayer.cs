namespace ITS2022_C.CardGameFramework
{
    public interface IPlayer
    {
        public (Card Card, List<Card> Taken) Play(ITable table, Deck deck);
        int GetPoints();
    }
}