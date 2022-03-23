namespace ThePokerGame.Business
{
    internal abstract class SameValue : Pairs
    {
        public SameValue(int span, int numberOfAKind) : base(span, numberOfAKind, 0)
        {
        }
    }
}