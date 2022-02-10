// See https://aka.ms/new-console-template for more information
using ITS2022_C.NoeFramework;

Animal? animal = new Herbivore()
{
    Name = "Turtle"
};
animal.Sleep();
animal.Eat();

Animal? animal2 = new HibernatedCarnivore();
animal2.Sleep();
animal2.Eat();
