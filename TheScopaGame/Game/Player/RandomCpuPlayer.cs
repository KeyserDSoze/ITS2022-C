namespace TheScopaGame
{
    public class RandomCpuPlayer : Player
    {
        private protected override Card ChooseACard(Table table)
            => Hand[new Random().Next(Hand.Count)];
    }
   
}