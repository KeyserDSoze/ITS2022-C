namespace ITS2022_C.Library
{
    public class ItalianIdentityCard : IdentityCard
    {
        public string Color;
        public void Something3()
        {
            Height = string.Empty;
            Number = string.Empty;
            Age = string.Empty;
            NameSurname = string.Empty;
            Something();
        }
        public static bool Check(ItalianIdentityCard card)
        {
            return string.IsNullOrWhiteSpace(card.NameSurname);
        }
        public List<ItalianIdentityCard> cards = new();
        public bool Any(Func<ItalianIdentityCard, bool> check)
        {
            foreach(var card in cards)
            {
                if (check(card))
                    return true;
            }
            return false;
        }
    }
}