using ITS2022_C.CardGameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using ThePokerGame.Business;
using Xunit;

namespace ThePokerGame.Test
{
    public class Points
    {
        [Theory]
        [InlineData(1, 1, 13, 13, 12, 11, 10, 1, 2, 1, 2, 1, 1, 1, "RoyalFlushAndStraightFlush", 1_000_000_060)]
        [InlineData(1, 1, 1, 1, 12, 11, 10, 1, 2, 3, 4, 1, 1, 1, "Poker", 900_000_572)]
        [InlineData(1, 1, 1, 2, 2, 2, 10, 1, 2, 3, 4, 3, 2, 1, "FullHouse", 500_004_260)]
        public void Winning(params object[] input)
        {
            List<Card> deck = new();
            for (int i = 0; i < 7; i++)
            {
                deck.Add(new Card((int)input[i], (int)input[i + 7]));
            }
            GameManager poker = new(new PokerGame(x => "2",
                x => { return true; }, 1));
            poker.Game.PrepareForTest(deck);
            poker.Play();
            Assert.Equal(input[14].ToString(), poker.Rank.First().Value.Name);
            Assert.Equal((int)input[15], poker.Rank.First().Value.Value);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void CheckDeck(int numberOfPlayers)
        {
            GameManager poker = new(new PokerGame(x => "2",
                x => { return true; }, numberOfPlayers));
            poker.Play();
            Assert.Equal(poker.Rank.Count, numberOfPlayers);
        }
        [Fact]
        public void Check()
        {
            GameManager poker = new(new PokerGame(x => "2",
                x => { return true; }, 1));
            poker.Play();
            Assert.True(!string.IsNullOrEmpty(poker.Rank.First().Value.Name));
        }
    }
}