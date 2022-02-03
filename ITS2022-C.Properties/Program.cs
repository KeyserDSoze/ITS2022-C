// See https://aka.ms/new-console-template for more information


using ITS2022_C.Properties;

OldPersona personaOld = new OldPersona();
string input = "Alessandro Rapiti";
personaOld.Nome = input.Replace(" ", string.Empty);
personaOld.Nome = input.Replace(" ", string.Empty);
personaOld.Nome = input.Replace(" ", string.Empty);
personaOld.Nome = input.Replace(" ", string.Empty);
Console.WriteLine(personaOld.Nome.Substring(0, 1).ToUpper() + personaOld.Nome.Substring(1).ToLower());
Console.WriteLine(personaOld.Nome.Substring(0, 1).ToUpper() + personaOld.Nome.Substring(1).ToLower());
Console.WriteLine(personaOld.Nome.Substring(0, 1).ToUpper() + personaOld.Nome.Substring(1).ToLower());
Console.WriteLine(personaOld.Nome.Substring(0, 1).ToUpper() + personaOld.Nome.Substring(1).ToLower());

Persona persona = new Persona();
persona.SetNome(input);
Console.WriteLine(persona.GetNome());



NewPersonaWithLambda a = new();
a.Nome = input;

ClassicPersona b = new();
b.Nome = input;

InitOnlyPersona ip = new()
{
    Nome = "Alessandro",
    Cognome = "Rapiti"
};
InitOnlyPersona ip2 = new()
{
    Nome = "Alessandro",
    Cognome = "Rapiti"
};
Console.WriteLine(ip.Equals(ip2));

ModelForPersona p = new("Alessandro", "Rapiti");
ModelForPersona p2 = new("Alessandro", "Rapiti");
Console.WriteLine(p == p2);