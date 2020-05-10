using System;
using System.Threading;

namespace MultiThreadingA9
{
    class Program
    {
        static Semaphore battleField = new Semaphore(2, 2);

        // Pokemons for the Battle
        static string[] pokemons = { "pikachu", "bulbasaur", "squattle", "pigyotto", "charmendar" };
        static void Main(string[] args)
        {
            foreach (var pokemon in pokemons)
            {
                Thread pokemonThread = new Thread(fight);
                pokemonThread.Name = pokemon;
                pokemonThread.Start();
            }

            Console.WriteLine("Hello World!");
        }

        // Pokemons to be fighting 
        static void fight()
        {
            Console.WriteLine($"===> {Thread.CurrentThread.Name} is ready for battle");
            battleField.WaitOne();

            Console.WriteLine($"===> {Thread.CurrentThread.Name} is now in the Battle");
            Thread.Sleep(2000);

            Console.WriteLine($"===> {Thread.CurrentThread.Name} has won the fight but still the battle for next!!");
            Thread.Sleep(new Random().Next(3000, 5000));

            Console.WriteLine($"===> {Thread.CurrentThread.Name} is lost the battle and come back to pokemon");
            battleField.Release();

        }
    }
}
