using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.CardGameFramework
{
    public class GameManager
    {
        public Game Game { get; }
        public Dictionary<string, (int Value, string Name)> Rank { get; } = new();
        public GameManager(Game game)
        {
            Game = game;
        }
        public void Play()
        {
            Game.OnStart();
            while (!Game.IsOver())
            {
                Game.Turn();
            }
            Game.End(Rank);
        }
    }
}
