// See https://aka.ms/new-console-template for more information
using ITS2022_C.Paperino;

PaperinoFactory paperinoFactory = new PaperinoFactory();
Paperino? paperino = paperinoFactory.Create();
var c = paperino.GetColorShirt();
var c2 = paperino.GetColorLight();