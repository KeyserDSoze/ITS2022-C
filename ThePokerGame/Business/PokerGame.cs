using ITS2022_C.CardGameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePokerGame.Business
{
    internal class PokerTable : ITable
    {
        public List<Card> Surface => throw new NotImplementedException();
        public List<Card> PlayACard(Card card)
        {
            throw new NotImplementedException();
        }
    }
    internal class BasePokerPlayer : IPlayer
    {
        private readonly string name = Naming.Get(Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N")[0..7]);
        public string Name => $"{name[0..1].ToUpper()}{name[1..]}";

        public int GetPoints()
        {
            throw new NotImplementedException();
        }

        public (Card Card, List<Card> Taken) Play(ITable table, Deck deck)
        {
            throw new NotImplementedException();
        }
    }
    internal class HumanPlayer : BasePokerPlayer { }
    internal class CpuPlayer : BasePokerPlayer { }
    internal class PokerGame : Game
    {
        public PokerGame(int numberOfPlayers = 2) : base(new PokerTable(),
                                                         new Dictionary<int, string> { { 1, "Human" }, { 2, "Cpu" } },
                                                         numberOfPlayers,
                                                         13, 4, true)
        {

        }

        public override void End()
        {
            throw new NotImplementedException();
        }

        public override bool IsOver()
        {
            throw new NotImplementedException();
        }

        public override void Turn()
        {
            throw new NotImplementedException();
        }

        protected override IPlayer GetRightPlayer(int kind)
        {
            throw new NotImplementedException();
        }

        protected override void OnStart_()
        {
            throw new NotImplementedException();
        }
    }
}
