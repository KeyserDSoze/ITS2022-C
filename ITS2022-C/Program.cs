// See https://aka.ms/new-console-template for more information
using ITS2022_C.Library;

Console.WriteLine("Hello, World!");
var x = new ItalianIdentityCard().NameSurname;
var identityCard = new ItalianIdentityCard();
identityCard.Check();


List<ItalianIdentityCard> cards = new();
cards.Any(ItalianIdentityCard.Check);
var allWithA = cards.Where(x => x.NameSurname.Contains("a"));