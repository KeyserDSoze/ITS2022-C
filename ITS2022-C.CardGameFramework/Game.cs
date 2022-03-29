using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.CardGameFramework
{
    public abstract class Game
    {
        protected Func<string, string> Input { get; }
        protected Func<string, bool> Output { get; }
        public Deck Deck { get; }
        public List<IPlayer> Players { get; } = new();
        public ITable Table { get; }
        private readonly int NumberOfPlayers;
        private readonly Dictionary<int, string> KindOfPlayers;
        public Game(ITable table, Dictionary<int, string> kindOfPlayers, Func<string, string> input, Func<string, bool> output,
            int numberOfPlayers = 2, int deckMaxValue = 10, int deckNumberOfSuits = 4, bool shuffle = true)
        {
            Deck = new Deck(deckMaxValue, deckNumberOfSuits, shuffle);
            NumberOfPlayers = numberOfPlayers;
            Table = table;
            KindOfPlayers = kindOfPlayers;
            Input = input;
            Output = output;
        }
        protected abstract IPlayer GetRightPlayer(int kind);
        public abstract void PrepareForTest(List<Card> deck);
        public void OnStart()
        {
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Output("Do you want to play as ");
                for (int j = 1; j <= KindOfPlayers.Count; j++)
                    Output($"{j} as {KindOfPlayers[j]}");
                AddPlayer();
                Output("------------------");
                void AddPlayer()
                {
                    string value = Input(string.Empty);
                    int.TryParse(value, out int result);
                    if (result == 0 || result > KindOfPlayers.Count)
                    {
                        Output("Please insert a valid player.");
                        AddPlayer();
                    }
                    Players.Add(GetRightPlayer(result));
                }
            }
            OnStart_();
        }
        protected abstract void OnStart_();
        public abstract void Turn();
        public abstract bool IsOver();
        public abstract void End(Dictionary<string, (int Value, string Name)> rank);
    }
}