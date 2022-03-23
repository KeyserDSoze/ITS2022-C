using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.CardGameFramework
{
    public abstract class Game
    {
        public Deck Deck { get; }
        public List<IPlayer> Players { get; } = new();
        public ITable Table { get; }
        private string LastPlayerNameThatHasTakenSomething;
        private readonly int NumberOfPlayers;
        private readonly Dictionary<int, string> KindOfPlayers;
        public Game(ITable table, Dictionary<int, string> kindOfPlayers, int numberOfPlayers = 2, int deckMaxValue = 10, int deckNumberOfSuits = 4, bool shuffle = true)
        {
            Deck = new Deck(deckMaxValue, deckNumberOfSuits, shuffle);
            NumberOfPlayers = numberOfPlayers;
            Table = table;
            KindOfPlayers = kindOfPlayers;
        }
        protected abstract IPlayer GetRightPlayer(int kind);
        public void OnStart()
        {
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Console.WriteLine("Do you want to play as ");
                for (int j = 1; j <= NumberOfPlayers; j++)
                    Console.Write($"{j} as {KindOfPlayers[j]}");
                Console.Write("?");
                AddPlayer();

                void AddPlayer()
                {
                    string value = Console.ReadLine();
                    int.TryParse(value, out int result);
                    if (result == 0 || result > KindOfPlayers.Count)
                    {
                        Console.WriteLine("Please insert a valid player.");
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
        public abstract void End();
    }
}