using TheScopaGame;

Console.WriteLine("How many players?");
int.TryParse(Console.ReadLine(), out int numberOfPlayers);

Game game = new(numberOfPlayers, true);
Console.WriteLine();
game.Start();
Console.WriteLine();
while (!game.IsOver())
    game.Turn();

game.End();
