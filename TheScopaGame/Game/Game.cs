namespace TheScopaGame
{
    public class Game
    {
        public Deck Deck { get; }
        public List<Player> Players { get; } = new();
        public Table Table { get; } = new();
        private string LastPlayerNameThatHasTakenSomething;
        public Game(int numberOfPlayers = 2, bool shuffle = true)
        {
            Deck = new Deck(shuffle);
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine("Do you want to play as (1) human or as (2) cpu?");
                AddPlayer();

                void AddPlayer()
                {
                    string value = Console.ReadLine();
                    switch (value)
                    {
                        case "1":
                            Players.Add(new HumanPlayer());
                            break;
                        case "2":
                            Players.Add(new RandomCpuPlayer());
                            break;
                        default:
                            Console.WriteLine("Please insert a valid player, (1) for human, (2) for cpu.");
                            AddPlayer();
                            break;
                    }
                }
            }
        }
        public void Start()
        {
            Table.Surface.AddRange(Deck.GetCards(4));
            foreach (var player in Players)
                player.RefillHand(Deck);
        }
        private int NumberOfTurn = 0;
        public void Turn()
        {
            int index = NumberOfTurn++ % Players.Count;
            var player = Players[index];
            var played = player.Play(Table, Deck);
            Console.WriteLine($"{NumberOfTurn} turn played by {player.Name} with {played.Card}.");
            if (played.HasTaken)
            {
                LastPlayerNameThatHasTakenSomething = player.Name;
                Console.WriteLine($"{player.Name} has taken {string.Join(',', played.Taken)}");
            }
            Console.WriteLine();
        }
        public bool IsOver()
            => Players.All(x => x.Hand.Count == 0);
        public void End()
        {
            var lastPlayerThatHasTakenSomething = Players.First(x => x.Name == LastPlayerNameThatHasTakenSomething);
            lastPlayerThatHasTakenSomething.Taken.AddRange(Table.Surface);
            Table.Surface.Clear();
            Dictionary<string, int> points = Players.ToDictionary(x => x.Name, x => x.GetPoints(Players.Where(t => t.Name != x.Name)));
            Console.WriteLine($"The game has ended. The winner is {points.OrderByDescending(x => x.Value).First().Key}");
            Console.WriteLine();
            Console.WriteLine("Ranking");
            foreach (var player in points.OrderByDescending(x => x.Value))
                Console.WriteLine($"{player.Key} with {player.Value} points");
        }
    }
}