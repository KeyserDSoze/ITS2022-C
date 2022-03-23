using ITS2022_C.CardGameFramework;

namespace ThePokerGame.Business
{
    internal class TwoOfAKind : SameValue
    {
        public TwoOfAKind() : base(10_000_000, 2) { }
    }
}