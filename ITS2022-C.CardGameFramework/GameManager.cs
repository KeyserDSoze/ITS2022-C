using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.CardGameFramework
{
    public class GameManager
    {
        private readonly Game Game;
        public GameManager(Game game)
        {
            Game = game;
        }
        public void Start()
        {
            Game.OnStart();
            while (!Game.IsOver())
            {
                Game.Turn();
            }
            Game.End();
        }
    }
}
