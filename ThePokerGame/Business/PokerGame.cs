using ITS2022_C.CardGameFramework;

namespace ThePokerGame.Business
{
    public class PokerGame : Game
    {
        public PokerGame(Func<string, string> input, Func<string, bool> output, int numberOfPlayers = 2) 
            : base(new PokerTable(),
                    new Dictionary<int, string> { { 1, "Human" }, { 2, "Cpu" } },
                    input, output,
                    numberOfPlayers,
                    13, 4, true)
        {

        }

        public override void End(Dictionary<string, int> rank)
        {
            var orderedPlayers = Players
                        .Select(x => new
                        {
                            Name = x.Name,
                            Points = x.GetPoints(Table, Players.Where(x => x.Name != x.Name))
                        })
                        .OrderByDescending(x => x.Points).ToList();
            var possibleWinners = orderedPlayers
                        .GroupBy(x => x.Points)
                        .First();
            Output($"Table: {string.Join(", ", Table.Surface)}");
            foreach (var player in Players)
                Output($"Player {player.Name}: {string.Join(", ", player.Hand)}");
            if (possibleWinners.Count() > 1)
                Output($"Draw between {string.Join(',', possibleWinners)} with {possibleWinners.First().Points} points");
            else
                Output($"The winner is {possibleWinners.First().Name} with {possibleWinners.First().Points} points");
            Output("Rank");
            foreach (var player in orderedPlayers)
            {
                rank.Add(player.Name, player.Points);
                Output($"Player {player.Name} with {player.Points} points");
            }
        }

        public override bool IsOver()
        {
            return true;
        }

        public override void Turn()
        {
        }

        protected override IPlayer GetRightPlayer(int kind)
        {
            switch (kind)
            {
                case 1:
                    return new HumanPlayer();
                case 2:
                    return new CpuPlayer();
                default:
                    return null;
            }
        }

        protected override void OnStart_()
        {
            Table.PutCardsOnSurface(Deck.GetCards(5));
            foreach (var player in Players)
                player.PutCardsInHand(Deck.GetCards(2));
        }
    }
}