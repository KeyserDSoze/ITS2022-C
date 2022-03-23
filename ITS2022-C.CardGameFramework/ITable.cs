namespace ITS2022_C.CardGameFramework
{
    public interface ITable
    {
        List<Card> Surface { get; }
        List<Card> PlayACard(Card card);
    }
}