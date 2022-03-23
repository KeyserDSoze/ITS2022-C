using System.Reflection;
using System.Text;

namespace ITS2022_C.CardGameFramework
{
    public static class Naming
    {
        private static readonly string Start;
        private static readonly Dictionary<char, string[]> CharMapping = new();
        private const string VowelContainer = "aeiouy";
        private static bool IsVowel(char ch)
             => VowelContainer.Contains(ch);
        static Naming()
        {
            Dictionary<char, int> values = new();
            StringBuilder start = new();
            string path = string.Join(@"\", Assembly.GetExecutingAssembly().Location.Split('\\').SkipLast(1));
            foreach (var line in File.ReadAllLines($@"{path}\Player\letterfrequency.csv"))
            {
                var x = line.Split(',');
                char c = x[0][0];
                values.Add(c, int.Parse(x[1]));
                start.Append(new string(c, values.Last().Value));
            }
            Start = start.ToString();
            foreach (var line in File.ReadAllLines($@"{path}\Game\Player\letternextone.csv"))
            {
                var x = line.Split(',');
                StringBuilder vowels = new();
                StringBuilder consonants = new();
                start = new();
                foreach (var t in x[1])
                {
                    if (IsVowel(t))
                        vowels.Append(new string(t, values[t]));
                    else
                        consonants.Append(new string(t, values[t]));
                    start.Append(new string(t, values[t]));
                }
                CharMapping.Add(x[0][0], new string[3] { start.ToString(), vowels.ToString(), consonants.ToString() });
            }
        }
        public static string Get(string id)
        {
            id = id[2..];
            var firstPart = id[0..2];
            int length = int.Parse(firstPart, System.Globalization.NumberStyles.HexNumber);
            int calculation = length * 7 / 256 + 4;
            if (calculation < 4)
                calculation = 4;
            var secondPart = id[2..];
            var name = new StringBuilder();
            char lastOne = '\0';
            int counter = 0;
            for (int j = 0; j < calculation; j++)
            {
                var part = secondPart[(j * 3)..(j * 3 + 3)];
                int decValue = int.Parse(part, System.Globalization.NumberStyles.HexNumber);
                string theBase = string.Empty;
                if (j == 0)
                    theBase = Start;
                else if (Math.Abs(counter) <= 1 && j > 1)
                    theBase = CharMapping[lastOne][0];
                else
                {
                    if (counter > 0)
                        theBase = CharMapping[lastOne][2];
                    else
                        theBase = CharMapping[lastOne][1];
                    counter = 0;
                }
                int x = decValue * theBase.Length / 4096;
                var isVowelTheLastOne = IsVowel(lastOne);
                name.Append(lastOne = theBase[x]);
                if (IsVowel(lastOne))
                {
                    if (!isVowelTheLastOne)
                        counter = 0;
                    counter++;
                }
                else
                {
                    if (isVowelTheLastOne)
                        counter = 0;
                    counter--;
                }
            }

            return name.ToString();
        }
    }
}
