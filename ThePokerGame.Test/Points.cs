using ITS2022_C.CardGameFramework;
using System;
using ThePokerGame.Business;
using Xunit;

namespace ThePokerGame.Test
{
    public class Points
    {
        [Theory]
        [InlineData(1, 1, 1)]
        public void Winning(params int[] cards)
        {
            GameManager poker = new(new PokerGame(x => "2",
                x => { return true; }));
            poker.Play();
        }
    }
}