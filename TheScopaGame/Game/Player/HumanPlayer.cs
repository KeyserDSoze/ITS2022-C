using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheScopaGame
{
    public class HumanPlayer : Player
    {
        private protected override Card ChooseACard(Table table)
        {
            Console.WriteLine($"On the surface you may find {string.Join(",", table.Surface)}");
            Console.WriteLine($"To play a card from your hand press ");
            foreach (var card in Hand)
                Console.WriteLine($"{Hand.IndexOf(card)}) for {card}");
            return Play();

            Card Play()
            {
                var value = Console.ReadLine();
                if (!int.TryParse(value, out int index))
                {
                    Console.WriteLine("Insert a correct value please!!!");
                    return Play();
                }
                return Hand[index];
            }
        }
    }
}