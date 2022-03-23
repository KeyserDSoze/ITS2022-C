// See https://aka.ms/new-console-template for more information
using ITS2022_C.CardGameFramework;
using ThePokerGame.Business;
while (true)
{
    GameManager poker = new(new PokerGame(x => "2" /*Console.ReadLine()*/,
        x => { Console.WriteLine(x); return true; }));
    poker.Play();
    Console.WriteLine("Do you wanna play another game?");
    string value = Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine();
    if (value == "n")
        break;
    else
        continue;
}
