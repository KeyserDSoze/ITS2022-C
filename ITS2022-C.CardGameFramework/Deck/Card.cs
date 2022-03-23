using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.CardGameFramework
{
    public record Card(int Value, int Suit)
    {
        public static List<Card> EmptyList { get; } = new();
        public static Card Empty { get; } = new(0, 0);
        public override string ToString()
        {
            switch (Suit)
            {
                case 1:
                    return $"{Value}♠";
                case 2:
                    return $"{Value}♣";
                case 3:
                    return $"{Value}♦";
                case 4:
                    return $"{Value}♥";
                default:
                    return $"{Value} ({Suit})";
            }
        }
    }
}
