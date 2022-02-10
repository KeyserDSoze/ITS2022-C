// See https://aka.ms/new-console-template for more information
using ITS2022_C.NoeFrameworkWithInterfaces.Models;

var animal = new Herbivore();
var animalManager = new AnimalManager();
animalManager.Run(animal);

var animal2 = new NoEatingAnimal();
animalManager.Run(animal2);

var animal3 = new HibernatedHerbivore();
animalManager.Run(animal3);
