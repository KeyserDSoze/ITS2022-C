namespace ITS2022_C.NoeFramework
{
    public abstract class Animal
    {
        protected string name;
        public abstract string Name { get; init; }
        public abstract void Eat();
        public virtual void Sleep() 
        {
            Console.WriteLine($"{Name} is sleeping.");
        }
    }
    public class Herbivore : Animal
    {
        public override string Name 
        {
            get => $"H. {name}";
            init => name = value; 
        }
        public override void Eat()
        {
            Console.WriteLine($"{Name} is eating herb.");
        }
    }
    public class Carnivore: Animal
    {
        public override string Name
        {
            get => $"C. {name}";
            init => name = value;
        }
        public override void Eat()
        {
            Console.WriteLine($"{Name} is eating meat.");
        }
    }
    public class HibernatedHerbivore : Herbivore
    {
        public override void Sleep()
        {
            Console.WriteLine($"{Name} is hibernating.");
        }
    }
   
}